using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.Impinj;
using RFIDIntegratedApplication.Analysis;
using RFIDIntegratedApplication.HolographicsForms;
using RFIDIntegratedApplication.Reader;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using RFIDIntegratedApplication.ServiceReference1;
using RFIDIntegratedApplication.service;
using RFIDIntegratedApplication.ServiceReference3;
using RFIDIntegratedApplication.Forms;

namespace RFIDIntegratedApplication
{
    public partial class MainForm : Form, IFormable
    {

        public ReaderSettingsForm _readerSettingsForm;
        TagTableForm _tagTableForm;
        RSSIGraphFrom _rssiGraphForm;
        PhaseGraphForm _phaseGraphForm;
        UpdateEpcForm _updateEpcForm;
        SearchRegionForm _searchRegionForm;
        SimulationForm _simulationForm;
        SystemInfoForm _systemInfoForm;
        LinearGuideForm _linearGuideForm;
        SortingBooksForm _sortingBooksForm;

        TagsTable _tagsTable;                  //Store all tag reports from RFID reader to export to a CSV file
        DateTime _startTime;                   //Record Inventory time

        string _filepath;                      //The filepath of App related file
        string _filename;                      //The filename of storing tags
        ulong _firstReportTime;                //Record first tag report time for calculating relative time

        static ConcurrentQueue<TagInfo> _tagsQueue;  // Queue for storing taginfo
        Thread _dequeueThread;                       // Dequeue Thread for dequeue taginfo and then update forms
        Thread _dequeueTagPosThread;                 // Dequeue thread for dequeue tagPos and then updateForms
        public MainForm()
        {
            InitializeComponent();
            _filename = "\\TagLog.csv";
            _tagsQueue = new ConcurrentQueue<TagInfo>();
            _tagsTable = new TagsTable();
        }

        /// <summary>
        /// Initialize DockPanel according to DockPanel.config or Default Settings in AppConfig
        /// </summary>
        private void InitializeDockPanel()
        {
            _readerSettingsForm = new ReaderSettingsForm(this);
            _tagTableForm = new TagTableForm();
            _rssiGraphForm = new RSSIGraphFrom();
            _phaseGraphForm = new PhaseGraphForm();
            _systemInfoForm = new SystemInfoForm();
            _sortingBooksForm = new SortingBooksForm();
            _linearGuideForm = new LinearGuideForm();
            _updateEpcForm = new UpdateEpcForm();
            _searchRegionForm = new SearchRegionForm();

            _simulationForm = new SimulationForm(this, _linearGuideForm);

            if (File.Exists(Path.Combine(_filepath, "DockPanel.config")))
            {
                // If DockPanel.config exists, load forms dynamicly
                this.dockPanelMain.LoadFromXml(Path.Combine(_filepath, "DockPanel.config"), delegate (string persistString)
                {
                    if (persistString == typeof(ReaderSettingsForm).ToString())
                    {
                        return _readerSettingsForm;
                    }

                    if (persistString == typeof(UpdateEpcForm).ToString())
                    {
                        return _updateEpcForm;
                    }

                    if (persistString == typeof(TagTableForm).ToString())
                    {
                        return _tagTableForm;
                    }

                    if (persistString == typeof(RSSIGraphFrom).ToString())
                    {
                        return _rssiGraphForm;
                    }

                    if (persistString == typeof(PhaseGraphForm).ToString())
                    {
                        return _phaseGraphForm;
                    }

                    if (persistString == typeof(SearchRegionForm).ToString())
                    {
                        return _searchRegionForm;
                    }

                    if (persistString == typeof(SimulationForm).ToString())
                    {
                        return _simulationForm;
                    }

                    if (persistString == typeof(LinearGuideForm).ToString())
                    {
                        return _linearGuideForm;
                    }

                    if (persistString == typeof(SortingBooksForm).ToString())
                    {
                        return _sortingBooksForm;
                    }

                    // Undefined forms
                    return null;
                });

                // Record original DockState
                if (_readerSettingsForm.DockState != DockState.Unknown && _readerSettingsForm.DockState != DockState.Hidden)
                    AppConfig.readerSettingsDockState = _readerSettingsForm.DockState;

                if (_tagTableForm.DockState != DockState.Unknown && _tagTableForm.DockState != DockState.Hidden)
                    AppConfig.tagTableDockState = _tagTableForm.DockState;

                if (_rssiGraphForm.DockState != DockState.Unknown && _rssiGraphForm.DockState != DockState.Hidden)
                    AppConfig.rssiGraphDockState = _rssiGraphForm.DockState;

                if (_phaseGraphForm.DockState != DockState.Unknown && _phaseGraphForm.DockState != DockState.Hidden)
                    AppConfig.phaseGraphDockState = _phaseGraphForm.DockState;

                if (_searchRegionForm.DockState != DockState.Unknown && _searchRegionForm.DockState != DockState.Hidden)
                    AppConfig.searchRegionDockState = _searchRegionForm.DockState;

                if (_updateEpcForm.DockState != DockState.Unknown && _updateEpcForm.DockState != DockState.Hidden)
                    AppConfig.updateEpcDockState = _updateEpcForm.DockState;

                if (_simulationForm.DockState != DockState.Unknown && _simulationForm.DockState != DockState.Hidden)
                    AppConfig.simulationDockState = _simulationForm.DockState;

                if (_linearGuideForm.DockState != DockState.Unknown && _linearGuideForm.DockState != DockState.Hidden)
                    AppConfig.linearGuideDockState = _linearGuideForm.DockState;

                if (_sortingBooksForm.DockState != DockState.Unknown && _sortingBooksForm.DockState != DockState.Hidden)
                    AppConfig.sortingBooksDockState = _sortingBooksForm.DockState;
            }
            else
            {
                // If DockPanel.config does not exists, load forms according to AppConfig
                _readerSettingsForm = new ReaderSettingsForm(this);
                _readerSettingsForm.Show(this.dockPanelMain, AppConfig.readerSettingsDockState);

                _tagTableForm = new TagTableForm();
                _tagTableForm.Show(this.dockPanelMain, AppConfig.tagTableDockState);
            }
        }

        /// <summary>
        /// Update the status of components in the panel
        /// </summary>
        /// <param name="flag">Indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        public void UpdateComponentStatus(int flag, bool isSimulation)
        {
            if (flag == 0)
            {
                //------Start inventorying------
                if (!isSimulation)
                {
                    // Modify button status in the Tool Strip
                    tsbtnStart.Enabled = false;
                    tsbtnStop.Enabled = true;

                    // Modify the status of components in ReaderSettingsForm when starting inventorying
                    if (_readerSettingsForm.Visible)
                        _readerSettingsForm.UpdateComponentStatus(flag, false);

                    if (RFIDReaderParameter.ReadMode == "Manual")
                    {
                        // Start time for timer
                        _startTime = DateTime.Now;
                    }
                    else
                    {
                        // Start time for timer
                        _startTime = DateTime.Now.AddMilliseconds(RFIDReaderParameter.Duration);
                    }
                }
                else
                {
                    tsbtnStart.Enabled = true;
                    tsbtnStop.Enabled = false;
                }

                // Modify button status in the Tool Strip
                tssbtnAddWindow.Enabled = false;
                tssbtnSave.Enabled = false;

                // Modify label status in the Status Strip
                tsslblStatus.Text = ReaderStatus.Inventorying.ToString();
                tsslblStatus.Image = Properties.Resources.status_start;
            }
            else if (flag == 1)
            {
                //------Stop inventorying------
                if (!isSimulation)
                {
                    // Modify button status in the Tool Strip
                    tsbtnStart.Enabled = true;
                    tsbtnStop.Enabled = false;

                    // Modify the status of components in ReaderSettingsForm when stoping inventorying
                    if (_readerSettingsForm.Visible)
                        _readerSettingsForm.UpdateComponentStatus(flag, false);

                    if (RFIDReaderParameter.ReadMode == "Timer")
                    {
                        tssbtnSave.Enabled = false;
                        if (tsslRunTime.Text == new TimeSpan(0, 0, 0, 0).ToString())
                            SaveAsCSV(_filename);
                    }
                }
                else
                {
                    tsbtnStart.Enabled = false;
                    tsbtnStop.Enabled = false;
                }

                // Modify button status in the Tool Strip
                tssbtnSave.Enabled = true;
                tssbtnAddWindow.Enabled = true;

                // Modify label status in the Status Strip
                tsslblStatus.Text = ReaderStatus.Stop.ToString();
                tsslblStatus.Image = Properties.Resources.status_stop;
            }

            // Modify the status of components in RSSIGraphForm when starting inventorying
            if (_rssiGraphForm.Visible)
                _rssiGraphForm.UpdateComponentStatus(flag, isSimulation);

            // Modify the status of components in PhaseGraphForm when starting inventorying
            if (_phaseGraphForm.Visible)
                _phaseGraphForm.UpdateComponentStatus(flag, isSimulation);

            // Modify the status of components in SearchRegionForm when starting inventorying
            if (_searchRegionForm.Visible)
                _searchRegionForm.UpdateComponentStatus(flag, isSimulation);



            // Modify the status of components in LinearGuideForm when starting inventorying
            if (_linearGuideForm.Visible)
                _linearGuideForm.UpdateComponentStatus(flag, isSimulation);

            // Modify the status of components in SimulationForm when starting inventorying
            if (_simulationForm.Visible)
                _simulationForm.UpdateComponentStatus(flag, isSimulation);

            // Modify the status of components in SortingBooksForm when starting inventorying
            if (_sortingBooksForm.Visible)
                _sortingBooksForm.UpdateComponentStatus(flag, isSimulation);
        }

        /// <summary>
        /// Update Status Strip for counter and run time
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdateStatusStrip(TagInfo tagInfo, bool isSimulation)
        {
            // Update Counter
            // tsslblCounter.Text = tagInfo.TotalTagCount.ToString();

            // Update Run Time for Manual read mode and Timer read mode respectively
            if (!isSimulation)
            {
                if (RFIDReaderParameter.ReadMode == "Manual")
                {
                    TimeSpan interval = DateTime.Now - _startTime;
                    //  tsslRunTime.Text = interval.ToString().Substring(0, 12);
                    this.BeginInvoke(method: new Action(() =>
                   {
                       tsslRunTime.Text = interval.ToString().Substring(0, 12);
                   }));
                }
                else
                {
                    TimeSpan interval = _startTime - DateTime.Now;
                    if (interval.TotalMilliseconds >= new TimeSpan(0, 0, 0, 0, 100).TotalMilliseconds)
                    {
                        this.BeginInvoke(method: new Action(() =>
                        {
                            tsslRunTime.Text = interval.ToString().Substring(0, 12);
                        }));
                    }
                    else
                    {
                        this.BeginInvoke(method: new Action(() =>
                        {
                            tsslRunTime.Text = new TimeSpan(0, 0, 0, 0).ToString();
                        }));
                    }
                }
            }
            else
            {
                this.BeginInvoke(method: new Action(() =>
                {
                    tsslRunTime.Text = new TimeSpan(0, 0, 0, (int)(tagInfo.FirstSeenTime / 1000000)).ToString();
                }));
            }
        }


        /// <summary>
        /// Enqueue tagInfo from tag report in case that main thread cannot process it immediately
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void EnqueueTagInfo(TagInfo tagInfo)
        {
            ulong tagTime = tagInfo.FirstSeenTime;
            long systemTime = CurrentMillis.MicroSeconds;
            Console.WriteLine("tagTime: " + tagTime);
            Console.WriteLine("systemTime: " + systemTime);
            //添加位置信息
            _tagsQueue.Enqueue(tagInfo);
        }

        /// <summary>
        /// Dequeue tagInfo from tags queue
        /// </summary>
        public void DequeueTagInfo()
        {
            while (true)
            {
                List<TagInfo> tagInfoList = null;
                TagInfo tagInfo = null;
                if (SARParameter.IsSimulation)
                {
                    if (_tagsQueue.TryDequeue(out tagInfo))
                    {
                        tagInfoList = new List<TagInfo>();
                        tagInfoList.Add(tagInfo);
                    }
                }
                else
                {
                    try
                    {
                        IImpinjControlService impinjControlService = ServiceManager.getOneImpinjControlService();
                        TagInfo[] tagInfoArray = impinjControlService.tryDeque();
                        ServiceManager.closeService(impinjControlService);
                        tagInfoList = new List<TagInfo>(tagInfoArray);
                    }
                    catch
                    {

                    }
                }
                if (tagInfoList != null && tagInfoList.Count > 0)
                {
                    foreach (TagInfo tagInfoInList in tagInfoList)
                    {
                        PhaseLocating.getInstance().addPhaseRecord(tagInfoInList);
                        this.BeginInvoke(method: new Action(() =>
                        {
                            this.UpdateDisplayForms(tagInfoInList, SARParameter.IsSimulation);
                        }));

                        if (_sortingBooksForm.Visible)
                        {
                            if (SARParameter.IsSimulation)
                            {
                                //处于模拟中，使用SAR(tagInfo)
                                _sortingBooksForm.SAR(tagInfoInList);
                            }
                        }

                    }
                    TagInfo lastTagInfo = tagInfoList.Last();
                    UpdateStatusStrip(lastTagInfo, false);
                    this._systemInfoForm.updateTime((long)lastTagInfo.FirstSeenTime);
                }
                Thread.Sleep(10);
            }
        }


        public void dequeTagPos()
        {
            TagPos tagPos;
            if (_sortingBooksForm.Visible)
            {
                while (true)
                {
                    if (SARParameter.tagPosQueue.TryDequeue(out tagPos))
                    {
                        _sortingBooksForm.SAR(tagPos);
                    }
                }
            }
        }


        /// <summary>
        /// Update display forms(TagTableForm, RSSIGraphForm...) once receiving a new tag report from RFID reader
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdateDisplayForms(TagInfo tagInfo, bool isSimulation)
        {
            if (tagInfo.TotalTagCount == 1)
            {
                _firstReportTime = tagInfo.FirstSeenTime;
            }
            tagInfo.TimeStamp = tagInfo.FirstSeenTime - _firstReportTime;

            // Update status strip in MainForm
            UpdateStatusStrip(tagInfo, isSimulation);

            // Update Tag Filter in ReaderSettingsFrom
            if (_readerSettingsForm.Visible)
            {
                _readerSettingsForm.UpdateTagFilter(tagInfo);
            }

            // Update TagTableForm
            if (_tagTableForm.Visible)
            {
                _tagTableForm.UpdateTagTable(tagInfo);
            }

            // Update RSSIGraphForm
            if (_rssiGraphForm.Visible)
            {
                _rssiGraphForm.UpdateRSSIGraph(tagInfo);
            }

            // Update PhaseGraphForm
            if (_phaseGraphForm.Visible)
            {
                _phaseGraphForm.UpdatePhaseGraph(tagInfo);
            }

            _tagsTable.AddTagInfo(tagInfo);
        }

        /// <summary>
        /// Save tag file automatically
        /// </summary>
        /// <param name="filename">tag file name</param>
        public void SaveCSV(string filename)
        {
            CSVFileHelper.SaveCSV(_tagsTable.Tags, _filepath + filename);
        }

        /// <summary>
        /// Save tag file Manually
        /// </summary>
        /// <param name="filename">tag file name</param>
        public void SaveAsCSV(string filename)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.InitialDirectory = _filepath;
            fileDialog.Filter = "CSV文件|*.csv*|XML文件|*.xml";
            fileDialog.FileName = filename.Substring(1, filename.Length - 1);
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                CSVFileHelper.SaveCSV(_tagsTable.Tags, fileDialog.FileName);
                //TagsWithPosTable tagsWithPosTable = PhaseLocating.getInstance().tagsWithPosTable;
               // CSVFileHelper.SaveCSV(tagsWithPosTable.tags, fileDialog.FileName + "WithPos.csv");
            }
        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {

        }

        public Boolean connect()
        {
            string address = _readerSettingsForm.GetReaderAddress();
            if (address == String.Empty) return false;

            Console.WriteLine("Connectting to Reader...");

            // Modify label status in the Status Strip
            tsslblStatus.Text = ReaderStatus.Connecting.ToString();
            tsslblStatus.Image = Properties.Resources.status_connecting;
            ConnectResponse connectResponse = null;
            try
            {
                IImpinjControlService impinjControlService = ServiceManager.getOneImpinjControlService();
                connectResponse = impinjControlService.connect(address);
                ServiceManager.closeService(impinjControlService);
                this.tsbtnStart.Enabled = true;
                this.toolStripButton1.Enabled = true;
            }
            catch
            {

            }
            // Check for a connection error
            if (connectResponse == null)
            {
                // Could not connect to the reader; Print out the error
                Console.WriteLine("Failed to Connect to Reader!");
                tsslblStatus.Text = "失败！";
                tsslblStatus.Image = Properties.Resources.status_stop;

                MessageBox.Show(tsslblStatus.Text, "Connection Error");
                //    RFIDReaderParameter.IsConnected = false;
                return false;
            }
            else
            {
                // Connect to the reader successfully
                Console.WriteLine("Succeeded to Connect to Reader!");
                RFIDReaderParameter.antennaConfiguration = connectResponse.antennaConfiguration;
                RFIDReaderParameter.readerCapabilities = connectResponse.readerCapabilities;
                RFIDReaderParameter.rOReportSpec = connectResponse.rOReportSpec;
                // Display settings in ReaderSettingsForm
                //  _readerSettingsForm.ReceiveConfigFromRFIDReaderPara();

                // Modify label status in the Status Strip


                // Modify Setting panel status

                //     RFIDReaderParameter.IsConnected = true;
                return true;
            }
        }

        /// <summary>
        /// Clear parameters and start dequeue thread
        /// </summary>
        public void StartDequeueThread()
        {
            Clear();
            _dequeueThread = new Thread(DequeueTagInfo);
            _dequeueThread.IsBackground = true;
            _dequeueThread.Start();

            _dequeueTagPosThread = new Thread(dequeTagPos);
            _dequeueTagPosThread.IsBackground = true;
            _dequeueTagPosThread.Start();
        }

        public void StartInventory()
        {
            SARParameter.IsSimulation = false;
            PhaseLocating.getInstance().started = true;
            IImpinjControlService impinjControlService = ServiceManager.getOneImpinjControlService();
            impinjControlService.startInventory(RFIDReaderParameter.antennaConfiguration, RFIDReaderParameter.rOReportSpec);
            ServiceManager.closeService(impinjControlService);
            //    this.UpdateComponentStatus((int)ENUM_ROSpecEventType.Start_Of_ROSpec, SARParameter.IsSimulation);
            StartDequeueThread();
        }

        private void tsbtnStart_Click(object sender, EventArgs e)
        {
            start();
            this.tssbtnSave.Enabled = false;
        }

        public void start()
        {
            this._readerSettingsForm.SendConfigToRFIDReaderPara();
            StartInventory();
            this.tsbtnStart.Enabled = false;
            this.tsbtnStop.Enabled = true;

        }

        public void StopDequeueThread()
        {
            try
            {
                _dequeueThread.Abort();
            }
            catch (Exception)
            {
                // throw;
            }
            try
            {
                _dequeueTagPosThread.Abort();
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        public void StopInventory()
        {
            PhaseLocating.getInstance().started = false;
            StopDequeueThread();

            if (tsbtnStop.Enabled)
            {
                IImpinjControlService impinjControlService = ServiceManager.getOneImpinjControlService();
                impinjControlService.stopInventory();
                ServiceManager.closeService(impinjControlService);
                // this.UpdateComponentStatus((int)ENUM_ROSpecEventType.End_Of_ROSpec, SARParameter.IsSimulation);
            }
        }

        private void tsbtnStop_Click(object sender, EventArgs e)
        {
            stop();
            this.tssbtnSave.Enabled = true;
        }

        /// <summary>
        /// Clear all holographics-related parameters
        /// </summary>
        public void ClearHolographics()
        {
            // Clear all the components before inventorying
            if (_searchRegionForm.Visible)
            {
                _searchRegionForm.Clear();
                _searchRegionForm.InitializeSearchRegion();
            }

            if (_sortingBooksForm.Visible)
                _sortingBooksForm.Clear();

            if (_linearGuideForm.Visible)
                _linearGuideForm.Clear();

            if (_simulationForm.Visible)
                _simulationForm.Clear();
        }

        /// <summary>
        /// Clear taginfo queue
        /// </summary>
        /// <param name="cq"></param>
        public void ClearTagInfo(ConcurrentQueue<TagInfo> tagInfo)
        {
            TagInfo garbage;
            while (tagInfo.TryDequeue(out garbage))
            {

            }
        }

        /// <summary>
        /// Clear all components created by this form before Inventroring 
        /// </summary>
        public void Clear()
        {
            // Clear Mainform
            tsslblCounter.Text = "0";
            tsslRunTime.Text = new TimeSpan(0, 0, 0, 0).ToString();
            _startTime = DateTime.Now;

            // Clear TagTableForm
            if (_tagTableForm.Visible)
                _tagTableForm.ClearDataGridView();

            // Clear RSSIGraphForm
            if (_rssiGraphForm.Visible)
                _rssiGraphForm.Clear();

            // Clear PhaseGraphForm
            if (_phaseGraphForm.Visible)
                _phaseGraphForm.Clear();

            ClearHolographics();

            _tagsTable.Clear();
            PhaseLocating.getInstance().Clear();
            ClearTagInfo(_tagsQueue);
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsmiReaderSettings_Click(object sender, EventArgs e)
        {
            _readerSettingsForm.Show(this.dockPanelMain, AppConfig.readerSettingsDockState);
        }

        private void tsmiTagTable_Click(object sender, EventArgs e)
        {
            _tagTableForm.Show(this.dockPanelMain, AppConfig.tagTableDockState);
        }

        private void tsmiRSSIGraph_Click(object sender, EventArgs e)
        {
            _rssiGraphForm.Show(this.dockPanelMain, AppConfig.rssiGraphDockState);
        }

        private void tsmiPhaseGraph_Click(object sender, EventArgs e)
        {
            _systemInfoForm.Show(this.dockPanelMain, AppConfig.phaseGraphDockState);
        }

        private void tsmiDemoSortingBooks_Click(object sender, EventArgs e)
        {
            _searchRegionForm.Show(this.dockPanelMain, AppConfig.searchRegionDockState);
            _simulationForm.Show(this.dockPanelMain, AppConfig.simulationDockState);
            _linearGuideForm.Show(this.dockPanelMain, AppConfig.linearGuideDockState);
            _sortingBooksForm.Show(this.dockPanelMain, AppConfig.sortingBooksDockState);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //  DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            _filepath = "./";

            this.InitializeDockPanel();

            //------Initialize status of buttons------
            //Tool Strip
            tssbtnSave.Enabled = false;
            tsbtnStart.Enabled = false;
            tsbtnStop.Enabled = false;
            tssbtnAddWindow.Enabled = true;

            // Modify the status of components in ReaderSettingsForm when initializing components
            _readerSettingsForm.UpdateComponentStatus(0, true);

            //btnHolographicsConfirm.Enabled = true;
            //btnSimulationStart.Enabled = false;
            //btnSimulationStop.Enabled = false;
            //------Initialize status of buttons------
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IP = RFIDReaderParameter.IP;
            Properties.Settings.Default.MAC = RFIDReaderParameter.MAC;
            Properties.Settings.Default.Hostname = RFIDReaderParameter.Hostname;

            Properties.Settings.Default.Save();
            _linearGuideForm.stopDmc();
            //Dispose objects
            if (tsbtnStop.Enabled)
            {
                try
                {
                    _dequeueThread.Abort();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            try
            {
                IImpinjControlService impinjControlService = ServiceManager.getOneImpinjControlService();
                impinjControlService.disconnect();
                ServiceManager.closeService(impinjControlService);
            }
            catch
            {

            }
            // Save DockPanel.config
            try
            {
                this.dockPanelMain.SaveAsXml(Path.Combine(_filepath, "DockPanel.config"));
            }
            catch (Exception)
            {
                MessageBox.Show("Fail to save DockPanel.config!", "File Save Error");
                return;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveCSV(_filename);

            tssbtnSave.Text = "Save";
            tssbtnSave.Image = Properties.Resources.save;

            tsslblStatus.Text = ReaderStatus.Saved.ToString();
            tsslblStatus.Image = Properties.Resources.status_ready;
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsCSV(_filename);

            tssbtnSave.Text = "Save As";
            tssbtnSave.Image = Properties.Resources.saveas;

            tsslblStatus.Text = ReaderStatus.Saved.ToString();
            tsslblStatus.Image = Properties.Resources.status_ready;
        }

        private void tssbtnSave_ButtonClick(object sender, EventArgs e)
        {
            if (tssbtnSave.Text == "Save")
            {
                SaveCSV(_filename);
            }
            else
            {
                SaveAsCSV(_filename);
            }
            tsslblStatus.Text = ReaderStatus.Saved.ToString();
            tsslblStatus.Image = Properties.Resources.status_ready;
        }

        private void tsslRunTime_Click(object sender, EventArgs e)
        {

        }

        private void tssbtnAddWindow_ButtonClick(object sender, EventArgs e)
        {
           
        }

        private void tsbtnDisconnect_Click(object sender, EventArgs e)
        {

        }

        public void stop()
        {
            StopInventory();
            //Tool Strip
            tsbtnStart.Enabled = true;
            tsbtnStop.Enabled = false;
            tssbtnAddWindow.Enabled = true;

            // Modify the status of components in ReaderSettingsForm when initializing components
            // _readerSettingsForm.UpdateComponentStatus(0, true);
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            stop();
            start();
            this.tssbtnSave.Enabled = false;
        }

        private void tsmiUpdateEpc_Click(object sender, EventArgs e)
        {
            this._updateEpcForm.Show(this.dockPanelMain, AppConfig.updateEpcDockState);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _phaseGraphForm.Show(this.dockPanelMain, AppConfig.phaseGraphDockState);
        }
    }

}
