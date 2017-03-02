using BasicApplication.Analysis;
using BasicApplication.Reader;
using BasicApplication.Tag;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicApplication
{
    public enum ReaderStatus
    {
        Ready,
        Connecting,
        Connected,
        Inventorying,
        TimedInventorying,
        Stop,
        Failed,
        Saved
    };

    public partial class 
        MainForm : Form
    {
        LLRPClient _reader;                    //Declear a LLRPClient instance
        ReaderSettings _readerSettings;        //Get or Set reader configurations
        TagsTable _tagsTable;                  //Store all tag reports from RFID reader to export to a CSV file
        DateTime _startTime;                   //Record Inventory time

        string _filepath;                      //File path of ReaderConfig.xml and ROSpec.xml
        string _filename;                      //Tag filename
        uint _currentSpecID;                   //Make sure all the ROSpec operations are in the same ROSpec
        static int _index;                     //Record the number of different tags in the whole inventorying process
        ulong _firstReportTime;                //Record first tag report time for calculating relative time

        Dictionary<string, SyntheticApertureRadar> _sar;     //Perform various sar localization methods
        HeatMap _heatmap;                      //Generate hologram for each round
        System.Timers.Timer _timers;           //Timer for simulation
        Thread _th;
        static int _simulationIndex;           //Index for calculating Wave Length and Tag Position in simulation
        static int _refreshTimeIndex;          //
        ConcurrentQueue<SARParameter> _sarParaQueue;

        public MainForm()
        {
            InitializeComponent();

            tssbtnSave.Enabled = false;
            tsbtnConnect.Enabled = true;
            tsbtnStart.Enabled = false;
            tsbtnStop.Enabled = false;
            tsbtnClear.Enabled = false;
            tsbtnMoreSettings.Enabled = false;

            cbResetToFactoryDefault.Enabled = false;
            tbxMAC1.Enabled = false;
            tbxMAC2.Enabled = false;
            tbxMAC3.Enabled = false;
            tbxDuration.Enabled = false;
            nudHop.Enabled = false;

            gbReadMode.Enabled = false;
            gbFrequencyInfo.Enabled = false;
            gbTagFilter.Enabled = false;

            btnHolographicsConfirm.Enabled = true;
            btnSimulationStart.Enabled = false;
            btnSimulationStop.Enabled = false;

            //Update Tag Filter
            cbMask.Items.Add(String.Empty);
            cbExtraMask.Items.Add(String.Empty);

            //Holographics
            cbAlgorithms.Items.Add("OriginSAR");
            cbAlgorithms.Items.Add("Tagoram");
            cbAlgorithms.Items.Add("MobiTagbot");

            cbAlgorithms.Text = "OriginSAR";
            SARParameter.SelectedSARAlgorithm = "OriginSAR";

            tbxRefreshInterval.Enabled = false;
            nudTagIndexForHologram.Enabled = false;

            _tagsTable = new TagsTable();
            _filename = "\\TagLog.csv";
            _index = 0;
        }

        /// <summary>
        /// Update toolstrip button status and basic settings panel when triggered by ROSpec event
        /// </summary>
        /// <param name="flag"></param>
        public void UpdateToolStrip(int flag)
        {
            if (flag == 0)
            {
                //Modify status in the Status Strip
                tsslblStatus.Text = ReaderStatus.Inventorying.ToString();
                tsslblStatus.Image = Properties.Resources.status_start;
                tsbtnStart.Enabled = false;
                tsbtnMoreSettings.Enabled = false;
                tssbtnSave.Enabled = false;

                //Modify Setting panel status
                cbResetToFactoryDefault.Enabled = false;
                gbAddress.Enabled = false;
                gbReadMode.Enabled = false;
                gbFrequencyInfo.Enabled = false;

                //counter reset
                ReaderSettings.TotalTagCount = 0;
                if (RFIDReaderParameter.ReadMode == "Manual")
                {
                    tsbtnStop.Enabled = true;
                    tsbtnClear.Enabled = true;
                    //start time for timer
                    _startTime = DateTime.Now;
                }
                else
                {
                    tsbtnStop.Enabled = false;
                    tsbtnClear.Enabled = false;
                    //start time for timer
                    _startTime = DateTime.Now.AddMilliseconds(RFIDReaderParameter.Duration);
                }
            }
            else if (flag == 1)
            {
                //Modify status in the Status Strip
                tsslblStatus.Text = ReaderStatus.Stop.ToString();
                tsslblStatus.Image = Properties.Resources.status_stop;
                tsbtnStart.Enabled = true;
                tsbtnStop.Enabled = false;
                tssbtnSave.Enabled = true;
                tsbtnMoreSettings.Enabled = true;

                //Modify Setting panel status
                cbResetToFactoryDefault.Enabled = true;
                gbAddress.Enabled = true;
                gbReadMode.Enabled = true;
                gbFrequencyInfo.Enabled = true;

                //tsslblCounter.Text = Convert.ToString(0);
                //_startTime = new DateTime(0);
                if (RFIDReaderParameter.ReadMode == "Timer")
                {
                    tssbtnSave.Enabled = false;
                    SaveCSV(_filename);
                    MessageBox.Show("Tag File Saved Successfully!", "Tag File Save");
                    ClearUI();
                }
            }
        }

        /// <summary>
        /// Update Run Time for Manual read mode and Timer read mode respectively
        /// </summary>
        public void UpdateRunTime()
        {
            if (RFIDReaderParameter.ReadMode == "Manual")
            {
                TimeSpan interval = DateTime.Now - _startTime;
                tsslRunTime.Text = interval.ToString().Substring(0, 12);
            }
            else
            {
                TimeSpan interval = _startTime - DateTime.Now;
                //Console.WriteLine("***_startTime " + _startTime);
                //Console.WriteLine("***DateTime.Now " + DateTime.Now);
                if (interval.TotalMilliseconds >= new TimeSpan(0, 0, 0, 0, 100).TotalMilliseconds)
                {
                    tsslRunTime.Text = interval.ToString().Substring(0, 12);
                }
                else
                {
                    tsslRunTime.Text = new TimeSpan(0, 0, 0, 0).ToString();
                }

            }
        }

        /// <summary>
        /// After getting capabilities from reader, initialize Frequency Information
        /// </summary>
        public void UpdateFreqSet()
        {
            for (int i = 0; i < RFIDReaderParameter.ReaderCapabilities.FixedFrequencyModeTable.Length; i++)
            {
                if (RFIDReaderParameter.ReaderCapabilities.FixedFrequencyModeTable[i] == "Disabled")
                    cbFreqMode.Text = "Disabled";
                cbFreqMode.Items.Add(RFIDReaderParameter.ReaderCapabilities.FixedFrequencyModeTable[i]);
            }
            foreach (KeyValuePair<ushort, double> freq in RFIDReaderParameter.ReaderCapabilities.FrequencyDic)
            {
                clbFreqSet.Items.Add(freq.Key + " - " + freq.Value + " MHz");
                if (freq.Key == 1)
                    clbFreqSet.SetItemChecked(clbFreqSet.Items.Count - 1, true);
            }

        }

        /// <summary>
        /// Update basic information ListView Once receiving a new tag report from RFID reader
        /// </summary>
        /// <param name="tagInfo">an object containing all information of a tag in one tag report</param>
        public void UpdateListView(TagInfo tagInfo)
        {
            //Update counter in status strip
            tsslblCounter.Text = tagInfo.TotalTagCount.ToString();
            //Update run time in status strip
            UpdateRunTime();

            _tagsTable.AddTagInfo(tagInfo);

            ListViewItem foundItem = lvBasicInfo.FindItemWithText(tagInfo.EPC);

            if (foundItem != null)
            {
                // Tag already exists
                foundItem.SubItems[2].Text = tagInfo.Antenna.ToString();
                foundItem.SubItems[3].Text = tagInfo.ChannelIndex.ToString();
                foundItem.SubItems[4].Text = tagInfo.RSSI.ToString();
                foundItem.SubItems[5].Text = tagInfo.AcutalPhaseInRadian.ToString();
                foundItem.SubItems[6].Text = tagInfo.DopplerShift.ToString();
                foundItem.SubItems[7].Text = tagInfo.Velocity.ToString();
                foundItem.SubItems[8].Text = Convert.ToString(Convert.ToInt32(foundItem.SubItems[8].Text) + 1);
                //if (tabControlChart.SelectedTab.Text != "Holographics")

                chartRSSI.Series[foundItem.Index].Points.AddXY((tagInfo.FirstSeenTime - _firstReportTime) / 1000, tagInfo.RSSI);
                chartPhase.Series[foundItem.Index].Points.AddXY((tagInfo.FirstSeenTime - _firstReportTime) / 1000, tagInfo.AcutalPhaseInRadian);

            }
            else
            {
                // New tag is coming
                if (tagInfo.TotalTagCount == 1)
                {
                    _firstReportTime = tagInfo.FirstSeenTime;
                }

                // Update Listview
                ListViewItem lvi = new ListViewItem(Convert.ToString(_index++));
                lvi.SubItems.Add(tagInfo.EPC);
                lvi.SubItems.Add(tagInfo.Antenna.ToString());
                lvi.SubItems.Add(tagInfo.ChannelIndex.ToString());
                lvi.SubItems.Add(tagInfo.RSSI.ToString());
                lvi.SubItems.Add(tagInfo.AcutalPhaseInRadian.ToString());
                lvi.SubItems.Add(tagInfo.DopplerShift.ToString());
                lvi.SubItems.Add(tagInfo.Velocity.ToString());
                lvi.SubItems.Add(Convert.ToString(1));
                lvBasicInfo.Items.Add(lvi);

                //Update Chart
                if (lvBasicInfo.Items.Count == 1)
                {
                    //Chart title for RSSI
                    Title titleRSSI = new Title("RSSI", Docking.Top);
                    titleRSSI.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                    titleRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                    chartRSSI.Titles.Add(titleRSSI);

                    Title titlePhase = new Title("Phase", Docking.Top);
                    titlePhase.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                    titlePhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                    chartPhase.Titles.Add(titlePhase);
                }

                //------RSSI------
                //Create a new curve
                Series seriesRSSI = new Series("RSSI:" + tagInfo.EPC);
                //Set chart type
                seriesRSSI.ChartType = SeriesChartType.FastLine;
                //Set different curve colors
                seriesRSSI.BorderDashStyle = (ChartDashStyle)lvBasicInfo.Items.Count;
                //Set curve width
                seriesRSSI.BorderWidth = 3;
                chartRSSI.Series.Add(seriesRSSI);

                //Create a new legend
                Legend legendRSSI = new Legend("RSSI:" + tagInfo.EPC);
                //Set legend propertities
                legendRSSI.Title = "EPC";
                legendRSSI.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
                legendRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

                legendRSSI.LegendStyle = LegendStyle.Table;
                legendRSSI.Alignment = System.Drawing.StringAlignment.Center;
                legendRSSI.IsDockedInsideChartArea = false;
                legendRSSI.Docking = Docking.Bottom;

                legendRSSI.BorderDashStyle = ChartDashStyle.Dash;
                legendRSSI.BorderColor = System.Drawing.Color.LightBlue;
                legendRSSI.BorderWidth = 3;
                chartRSSI.Legends.Add(legendRSSI);
                //Set Docking of the legend chart to the Default Chart Area
                chartRSSI.Legends["RSSI:" + tagInfo.EPC].DockedToChartArea = "RSSI";
                seriesRSSI.Points.AddXY((tagInfo.FirstSeenTime - _firstReportTime) / 1000, tagInfo.RSSI);
                //------RSSI------

                //------Phase------
                //Create a new curve
                Series seriesPhase = new Series("Phase:" + tagInfo.EPC);
                //Set chart type
                //seriesPhase.ChartType = SeriesChartType.FastPoint;
                seriesPhase.ChartType = SeriesChartType.FastLine;
                //Set different curve colors
                seriesPhase.BorderDashStyle = (ChartDashStyle)lvBasicInfo.Items.Count;
                //Set curve width
                seriesPhase.BorderWidth = 3;
                //seriesPhase.MarkerSize = 5;
                chartPhase.Series.Add(seriesPhase);

                //Create a new legend
                Legend legendPhase = new Legend("Phase:" + tagInfo.EPC);
                //Set legend propertities
                legendPhase.Title = "EPC";
                legendPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
                legendPhase.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);

                legendPhase.LegendStyle = LegendStyle.Table;
                legendPhase.Alignment = System.Drawing.StringAlignment.Center;
                legendPhase.IsDockedInsideChartArea = false;
                legendPhase.Docking = Docking.Bottom;

                legendPhase.BorderDashStyle = ChartDashStyle.Dash;
                legendPhase.BorderColor = System.Drawing.Color.LightBlue;
                legendPhase.BorderWidth = 3;

                chartPhase.Legends.Add(legendPhase);

                chartPhase.Legends["Phase:" + tagInfo.EPC].DockedToChartArea = "Phase";
                seriesPhase.Points.AddXY((tagInfo.FirstSeenTime - _firstReportTime) / 1000, tagInfo.AcutalPhaseInRadian);

                //------Phase------

                //Update Tag Filter
                if (!cbMask.Items.Contains(tagInfo.EPC))
                    cbMask.Items.Add(tagInfo.EPC);
                if (!cbExtraMask.Items.Contains(tagInfo.EPC))
                    cbExtraMask.Items.Add(tagInfo.EPC);
                
                SyntheticApertureRadar sar = new SyntheticApertureRadar();
                _sar.Add(tagInfo.EPC, sar);
            }

            SARParameter sarPara = new SARParameter();

            sarPara.AntennaX = Convert.ToDouble(tbxAntXStart.Text.Trim()) +
               _simulationIndex * Convert.ToDouble(tbxSamplingAntennaSpeed.Text.Trim()) * Convert.ToDouble(tbxSimulationSamplingTime.Text.Trim());
            sarPara.AntennaY = Convert.ToDouble(tbxAntYStart.Text.Trim());

            sarPara.TagInformation = new TagInfo();
            sarPara.TagInformation.EPC = tagInfo.EPC;
            sarPara.TagInformation.Frequency = 1000000 * RFIDReaderParameter.ReaderCapabilities.FrequencyDic[tagInfo.ChannelIndex];
            sarPara.TagInformation.AcutalPhaseInRadian = tagInfo.AcutalPhaseInRadian;
            sarPara.TagInformation.TotalTagCount = tagInfo.TotalTagCount;

            _sarParaQueue.Enqueue(sarPara);
        }

        /// <summary>
        /// Before starting inventorying, save settings in the mainform
        /// </summary>
        public bool SaveSettings()
        {
            RFIDReaderParameter.Reset = cbResetToFactoryDefault.Checked;
            RFIDReaderParameter.Mask = cbMask.Text;
            RFIDReaderParameter.ExtraMask = cbExtraMask.Text;

            if (rbtnManualReadMode.Checked)
            {
                RFIDReaderParameter.ReadMode = "Manual";
            }
            else
            {
                RFIDReaderParameter.ReadMode = "Timer";
                RFIDReaderParameter.Duration = Convert.ToUInt32(tbxDuration.Text);
            }


            RFIDReaderParameter.AntennaConfiguration.FixedFrequencyMode = cbFreqMode.Text;
            if (RFIDReaderParameter.AntennaConfiguration.FixedFrequencyMode != "Disabled")
            {
                RFIDReaderParameter.AntennaConfiguration.Hopping = true;
                RFIDReaderParameter.AntennaConfiguration.HoppingStep = Convert.ToUInt16(nudHop.Value);
                RFIDReaderParameter.AntennaConfiguration.FixedChannelList = new UInt16Array();
                UInt16Array channelList = new UInt16Array();

                if (clbFreqSet.CheckedIndices.Count < 2)
                {
                    MessageBox.Show("Must choose at least 2 frequencies");
                    return false;
                }
                else
                {
                    for (int i = 0; i < clbFreqSet.CheckedIndices.Count; i++)
                    {
                        channelList.Add((ushort)(clbFreqSet.CheckedIndices[i] + 1));
                    }

                    if (RFIDReaderParameter.AntennaConfiguration.HoppingStep <= 0)
                    {
                        MessageBox.Show("HoppingStep must be larger than 0");
                        return false;
                    }
                    else if (RFIDReaderParameter.AntennaConfiguration.HoppingStep >= channelList.Count)
                    {
                        MessageBox.Show("HoppingStep must be smaller than Chosen List");
                        return false;
                    }
                    else
                    {
                        int len = channelList.Count;
                        RFIDReaderParameter.AntennaConfiguration.FixedChannelList.Add(channelList[0]);
                        for (int i = 1; i < len; i++)
                        {
                            int nextIndex = (0 + i * RFIDReaderParameter.AntennaConfiguration.HoppingStep) % len;
                            if (nextIndex == 0) break;
                            RFIDReaderParameter.AntennaConfiguration.FixedChannelList.Add(channelList[nextIndex]);
                        }
                        return true;
                    }
                }
            }
            else
            {
                RFIDReaderParameter.AntennaConfiguration.Hopping = false;
                RFIDReaderParameter.AntennaConfiguration.HoppingStep = 0;
                if (clbFreqSet.CheckedIndices.Count < 1)
                {
                    MessageBox.Show("Please choose one frequency!");
                    return false;
                }
                else if (clbFreqSet.CheckedIndices.Count > 1)
                {
                    MessageBox.Show("Can only choose one frequency!");
                    return false;
                }
                else
                {
                    RFIDReaderParameter.AntennaConfiguration.ChannelIndex = (ushort)(clbFreqSet.CheckedIndices[0] + 1);
                    return true;
                }
            }
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
            }
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

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCSV(_filename);

            tssbtnSave.Text = "Save";
            tssbtnSave.Image = Properties.Resources.save;

            tsslblStatus.Text = ReaderStatus.Saved.ToString();
            tsslblStatus.Image = Properties.Resources.status_ready;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsCSV(_filename);

            tssbtnSave.Text = "Save As";
            tssbtnSave.Image = Properties.Resources.saveas;

            tsslblStatus.Text = ReaderStatus.Saved.ToString();
            tsslblStatus.Image = Properties.Resources.status_ready;
        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {
            string address = "";

            if (rbtnIP.Checked)
            {
                if (tbxIP.Text == String.Empty)
                {
                    MessageBox.Show("Please Input IP Address!");
                    return;
                }
                RFIDReaderParameter.IP = tbxIP.Text.Trim();
                address = RFIDReaderParameter.IP;
            }
            else if (rbtnHostname.Checked)
            {
                if (tbxMAC1.Text == String.Empty || tbxMAC2.Text == String.Empty || tbxMAC3.Text == String.Empty)
                {
                    MessageBox.Show("Please complete Hostname!");
                    return;
                }
                RFIDReaderParameter.Hostname = String.Format(@"speedwayr-{0}-{1}-{2}.local", tbxMAC1.Text.Trim(), tbxMAC2.Text.Trim(), tbxMAC3.Text.Trim());
                address = RFIDReaderParameter.Hostname;
            }

            Console.WriteLine("Connectting to Reader...");

            //Update Status
            tsslblStatus.Text = ReaderStatus.Connecting.ToString();
            tsslblStatus.Image = Properties.Resources.status_connecting;
            // Create a LLRPClient instance.
            _reader = new LLRPClient();
            //Impinj Best Practice! Always Install the Impinj extensions
            Impinj_Installer.Install();

            ENUM_ConnectionAttemptStatusType status;
            bool ret = _reader.Open(address, 2000, out status);

            // Check for a connection error
            if (!ret || status != ENUM_ConnectionAttemptStatusType.Success)
            {
                // Could not connect to the reader; Print out the error
                Console.WriteLine("Failed to Connect to Reader!");
                if (status.ToString() == "-1")
                {
                    tsslblStatus.Text = "Wrong Address";
                }
                else
                {
                    tsslblStatus.Text = status.ToString();
                }


                tsslblStatus.Image = Properties.Resources.status_stop;
                MessageBox.Show(tsslblStatus.Text, "Connection Error");
                RFIDReaderParameter.IsConnected = false;
                _reader.Close();
                return;
            }
            else
            {
                //Connect to the reader successfully
                Console.WriteLine("Succeeded to Connect to Reader!");

                tsslblStatus.Text = ReaderStatus.Connected.ToString();
                tsslblStatus.Image = Properties.Resources.status_ready;

                tsbtnConnect.Enabled = false;
                tsbtnStart.Enabled = true;
                tsbtnMoreSettings.Enabled = true;

                cbResetToFactoryDefault.Enabled = true;
                gbReadMode.Enabled = true;
                gbFrequencyInfo.Enabled = true;
                gbTagFilter.Enabled = true;
                RFIDReaderParameter.IsConnected = true;

                _readerSettings = new ReaderSettings(this, _reader);
                _readerSettings.AddEventHandler();
                _readerSettings.Enable_Impinj_Extensions();
                _readerSettings.GetReaderCapabilities();
                new RFIDReaderParameter();
                _readerSettings.UpdateUISettings();
            }
        }

        public void StartInventory()
        {
            if (!SaveSettings()) return;
            
            //if (btnHolographicsConfirm.Enabled)
            //{
            //    MessageBox.Show("Please confirm Holographics Settins before starting invenroty!", "Warning");
            //    return;
            //}
            //else
            //{
            //    _th = new Thread(SARThread);
            //    _th.IsBackground = true;
            //    _th.Start();
            //}


            _readerSettings.SetReaderConfiguration(_filepath);
            //_readerSettings.GetReaderConfigFromReader();

            //Send the messages 
            //_readerSettings.GetROSpecFromReader();
            _currentSpecID = _readerSettings.AddROSpec(_filepath);
            //_readerSettings.GetROSpecFromReader();
            _readerSettings.Enable_ROSpec(_currentSpecID);
            _readerSettings.Start_ROSpec(_currentSpecID);

        }

        private void tsbtnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start...");

            StartInventory();
        }

        public void StopInventory()
        {
            cbAlgorithms.Enabled = true;
            gbHologram.Enabled = true;
            gbSearchRegion.Enabled = true;
            gbAntennaTrack.Enabled = true;

            btnHolographicsConfirm.Enabled = true;
            
            //try
            //{
            //    _th.Abort();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            _readerSettings.Stop_ROSpec(_currentSpecID);

            ClearUI();
        }

        private void tsbtnStop_Click(object sender, EventArgs e)
        {
            StopInventory();
        }

        public void ClearUI()
        {
            _index = 0;

            lvBasicInfo.Items.Clear();
            chartRSSI.Titles.Clear();
            chartRSSI.Series.Clear();
            chartRSSI.Legends.Clear();
            chartPhase.Titles.Clear();
            chartPhase.Series.Clear();
            chartPhase.Legends.Clear();

            tbxLocalizationResult.Clear();
            pbHeatMap.Image = null;

            _sar.Clear();
            //_sarParaQueue

            _tagsTable.Clear();

            ReaderSettings.TotalTagCount = 0;
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            ClearUI();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reset();
            //Retrieve information from user's settings
            tbxIP.Text = Properties.Settings.Default.IP;
            if (Properties.Settings.Default.Hostname != String.Empty)
            {
                string[] macs = Properties.Settings.Default.Hostname.Split('-');
                tbxMAC1.Text = macs[1];
                tbxMAC2.Text = macs[2];
                tbxMAC3.Text = macs[3].Split('.')[0];
            }

            //Set rfid reader parameter from user's settings
            RFIDReaderParameter.IP = Properties.Settings.Default.IP;
            RFIDReaderParameter.MAC = Properties.Settings.Default.MAC;
            RFIDReaderParameter.Hostname = Properties.Settings.Default.Hostname;

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            _filepath = dir.Parent.Parent.FullName + "\\app";
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Store the user's settings to recover next time
            Properties.Settings.Default.IP = RFIDReaderParameter.IP;
            Properties.Settings.Default.MAC = RFIDReaderParameter.MAC;
            Properties.Settings.Default.Hostname = RFIDReaderParameter.Hostname;

            Properties.Settings.Default.Save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dispose objects
            if (_reader != null)
            {
                if (_readerSettings != null)
                {
                    //In case that users close the app without stopping ROSpec 
                    _readerSettings.Stop_ROSpec(_currentSpecID);
                    _readerSettings.DeleteEventHandler();
                }
                _reader.Close();
            }
        }

        private void tsbtnMoreSettings_Click(object sender, EventArgs e)
        {
            MoreSettingsForm setting = new MoreSettingsForm(this);
            setting.Show();
        }

        private void rbtnIP_CheckedChanged(object sender, EventArgs e)
        {
            tbxIP.Enabled = true;
            tbxMAC1.Enabled = false;
            tbxMAC2.Enabled = false;
            tbxMAC3.Enabled = false;
        }

        private void rbtnHostname_CheckedChanged(object sender, EventArgs e)
        {
            tbxIP.Enabled = false;
            tbxMAC1.Enabled = true;
            tbxMAC2.Enabled = true;
            tbxMAC3.Enabled = true;
        }

        private void rbtnManualReadMode_CheckedChanged(object sender, EventArgs e)
        {
            tbxDuration.Enabled = false;
        }

        private void rbtnTimerReadMode_CheckedChanged(object sender, EventArgs e)
        {
            tbxDuration.Enabled = true;
            if (tbxDuration.Text == "0")
            {
                MessageBox.Show("Duration should not be 0 ms!");
            }
        }

        private void cbFreqMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFreqMode.Text.Trim() != "Disabled")
            {
                for (int i = 0; i < clbFreqSet.Items.Count; i++)
                {
                    clbFreqSet.SetItemChecked(i, true);
                }

                if (cbFreqMode.Text.Trim() == "Channel_List")
                {
                    clbFreqSet.Enabled = true;
                    nudHop.Enabled = true;
                    nudHop.Value = 1;
                    if (nudHop.Value == 0)
                    {
                        MessageBox.Show("Hop step should not be 0!");
                    }
                }
                else
                {
                    clbFreqSet.Enabled = false;
                    nudHop.Enabled = false;
                    nudHop.Value = 4;
                }


            }
            else
            {
                for (int i = 1; i < clbFreqSet.Items.Count; i++)
                {
                    clbFreqSet.SetItemChecked(i, false);
                }
                nudHop.Enabled = false;
            }
        }

        private void btnSearchIP_Click(object sender, EventArgs e)
        {
            SearchReaderIPForm searchIP = new SearchReaderIPForm();
            if (searchIP.ShowDialog() == DialogResult.OK)
            {
                string selectedIP = searchIP.SelectedIP;
                if (selectedIP != null)
                {
                    tbxIP.Text = selectedIP;
                }
                else
                {
                    MessageBox.Show("Failed to search reader IP!");
                }
            }
        }

        private void cbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearUI();
            // In case that users have already clicked stop buttion to stop inventory
            if (tsbtnStop.Enabled == true)
            {
                StopInventory();
            }
            StartInventory();
        }

        private void cbExtraMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearUI();
            // In case that users have already clicked stop buttion to stop inventory
            if (tsbtnStop.Enabled == true)
            {
                StopInventory();
            }
            StartInventory();
        }

        //------SAR------
        /// <summary>
        /// Initialize SAR Parameter, like search region 
        /// </summary>
        public void InitializeSARParameter()
        {
            //------Search Region------
            int gridNumX = (int)((Convert.ToInt32(tbxSRXEnd.Text.Trim()) - Convert.ToInt32(tbxSRXStart.Text.Trim())) / Convert.ToDouble(tbxSRXInterval.Text.Trim())) + 1;
            int gridNumY = (int)((Convert.ToInt32(tbxSRYEnd.Text.Trim()) - Convert.ToInt32(tbxSRYStart.Text.Trim())) / Convert.ToDouble(tbxSRYInterval.Text.Trim())) + 1;

            SARParameter.GridX = new List<double>();
            for (int i = 0; i < gridNumX; i++)
            {
                SARParameter.GridX.Add(Convert.ToDouble(tbxSRXStart.Text.Trim()) + i * Convert.ToDouble(tbxSRXInterval.Text.Trim()));
                //Console.WriteLine("****X" + SARParameter.GridX[i]);
            }

            SARParameter.GridY = new List<double>();
            for (int i = 0; i < gridNumY; i++)
            {
                SARParameter.GridY.Add(Convert.ToDouble(tbxSRYStart.Text.Trim()) + i * Convert.ToDouble(tbxSRYInterval.Text.Trim()));
                //Console.WriteLine("****Y" + SARParameter.GridY[i]);
            }
            //------Search Region------

            if (dgvSimulationTagPosition.RowCount <= 1)
            {
                dgvSimulationTagPosition.Rows.Add();
                dgvSimulationTagPosition.Rows[0].Cells[0].Value = "1";
                dgvSimulationTagPosition.Rows[0].Cells[1].Value = "0";
                dgvSimulationTagPosition.Rows[0].Cells[2].Value = "0";
                dgvSimulationTagPosition.Rows[0].Cells[3].Value = "0";
            }

            _sarParaQueue = new ConcurrentQueue<SARParameter>();
        }

        private void btnHolographicsConfirm_Click(object sender, EventArgs e)
        {
            tbxLocalizationResult.Clear();
            pbHeatMap.Image = null;

            InitializeSARParameter();
            _sar = new Dictionary<string, SyntheticApertureRadar>();
            _heatmap = new HeatMap(pbHeatMap, SARParameter.GridY.Count, SARParameter.GridX.Count);

            _simulationIndex = 0;
            _refreshTimeIndex = 0;

            btnHolographicsConfirm.Enabled = false;
            btnSimulationStart.Enabled = true;

            cbAlgorithms.Enabled = false;
            gbHologram.Enabled = false;
            gbSearchRegion.Enabled = false;
            gbAntennaTrack.Enabled = false;
        }

        private void btnSimulationStart_Click(object sender, EventArgs e)
        {
            if ((int)nudTagIndexForHologram.Value >= dgvSimulationTagPosition.RowCount - 1)
            {
                MessageBox.Show("Tag Index is out of range!");

                btnHolographicsConfirm.Enabled = true;
                btnSimulationStart.Enabled = false;

                cbAlgorithms.Enabled = true;
                gbHologram.Enabled = true;
                gbSearchRegion.Enabled = true;
                gbAntennaTrack.Enabled = true;

                return;
            }

            SARParameter.Simulation.Tags = new List<string>();
            SARParameter.Simulation.TagXs = new List<double>();
            SARParameter.Simulation.TagYs = new List<double>();
            SARParameter.Simulation.TagZs = new List<double>();

            if (dgvSimulationTagPosition.RowCount == 1)
            {
                MessageBox.Show("Please at least input one tag information!");
                return;
            }

            for (int i = 0; i < dgvSimulationTagPosition.RowCount; i++)
            {
                string tagEPC = (string)dgvSimulationTagPosition.Rows[i].Cells[0].Value;
                if (tagEPC != null)
                {
                    SARParameter.Simulation.Tags.Add(tagEPC);

                    SARParameter.Simulation.TagXs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[1].Value));
                    SARParameter.Simulation.TagYs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[2].Value));
                    SARParameter.Simulation.TagZs.Add(Convert.ToDouble(dgvSimulationTagPosition.Rows[i].Cells[3].Value));

                    SyntheticApertureRadar sar = new SyntheticApertureRadar();
                    _sar.Add(tagEPC, sar);
                }
            }


            // Define a timer to simulate the online situation
            _timers = new System.Timers.Timer();
            _timers.Enabled = true;
            _timers.Interval = Convert.ToDouble(tbxSimulationSamplingTime.Text.Trim()) * 1000;
            _timers.Elapsed += new System.Timers.ElapsedEventHandler(Timers_Elapsed);
            _timers.Start();

            _th = new Thread(SARThread);
            _th.IsBackground = true;
            _th.Start();

            gbSimulationTagPosition.Enabled = false;
            gbSimulationFrequncy.Enabled = false;

            btnSimulationStart.Enabled = false;
            btnSimulationStop.Enabled = true;
        }

        private void SARThread()
        {
            while (true)
            {
                if (!_sarParaQueue.IsEmpty)
                {
                    SARParameter temp;
                    _sarParaQueue.TryDequeue(out temp);
                    if (SARParameter.SelectedSARAlgorithm == "OriginSAR")
                    {
                        _sar[temp.TagInformation.EPC].OriginSAR(temp.AntennaX, temp.AntennaY, (int)temp.TagInformation.Frequency, temp.TagInformation.AcutalPhaseInRadian);
                        Console.WriteLine(temp.AntennaX + " " + temp.AntennaY + " " + (int)temp.TagInformation.Frequency + " " + temp.TagInformation.AcutalPhaseInRadian);
                    }
                    else if (SARParameter.SelectedSARAlgorithm == "Tagoram")
                        _sar[temp.TagInformation.EPC].Tagoram(temp.AntennaX, temp.AntennaY, (int)temp.TagInformation.Frequency, temp.TagInformation.AcutalPhaseInRadian);
                    else if (SARParameter.SelectedSARAlgorithm == "MobiTagbot")
                        _sar[temp.TagInformation.EPC].MobiTagbot();

                    this.Invoke(method: new Action(() =>
                    {
                        this.UpdateResultTextBox(temp.TagInformation.TotalTagCount, temp.TagInformation.EPC);
                    }));

                    if (cbDisplayHologram.Checked)
                    {
                        //Reduce the time for refreshing UI to enhance app performance

                        if (temp.TagInformation.EPC == (string)dgvSimulationTagPosition.Rows[(int)nudTagIndexForHologram.Value].Cells[0].Value
                            && ++_refreshTimeIndex >= Convert.ToDouble(tbxRefreshInterval.Text.Trim()) / Convert.ToDouble(tbxSimulationSamplingTime.Text.Trim()))
                        {

                            this.Invoke(method: new Action(() =>
                            {
                                this.UpdateHologram(SARParameter.Hologram);
                            }));

                            //using (Graphics g = Graphics.FromImage(pbHeatMap.Image))
                            //{
                            //    int width = pbHeatMap.Size.Width;
                            //    int hieght = pbHeatMap.Size.Height;
                            //    Pen penX = new Pen(Color.Black, 2);
                            //    g.DrawLine(penX, 0, hieght, width, hieght);

                            //    Pen penY = new Pen(Color.Black, 2);
                            //    g.DrawLine(penX, 0, hieght, 0, 0);

                            //}
                            _refreshTimeIndex = 0;
                        }
                    }
                }
            }
        }

        private void Timers_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SARParameter sarPara = new SARParameter();

            sarPara.AntennaX = Convert.ToDouble(tbxAntXStart.Text.Trim()) +
                _simulationIndex * Convert.ToDouble(tbxSamplingAntennaSpeed.Text.Trim()) * Convert.ToDouble(tbxSimulationSamplingTime.Text.Trim());
            sarPara.AntennaY = Convert.ToDouble(tbxAntYStart.Text.Trim());

            int freq = (int)(1000000 * Convert.ToDouble(tbxSimulationInitialFrequency.Text.Trim()) +
                (_simulationIndex % Convert.ToInt32(tbxSimulationHoppingNumber.Text.Trim())) * SARParameter.FrequencyHoppingInterval);
            
            // Simulate several tags in the search region
            string tagEPC = SARParameter.Simulation.Tags[_simulationIndex % SARParameter.Simulation.Tags.Count];
            double tagX = SARParameter.Simulation.TagXs[_simulationIndex % SARParameter.Simulation.TagXs.Count];
            double tagY = SARParameter.Simulation.TagYs[_simulationIndex % SARParameter.Simulation.TagYs.Count];
            double measuredPhase = _sar[tagEPC].CaculatingSimulationMeasuredPhase(sarPara.AntennaX, sarPara.AntennaY, tagX, tagY, freq);

            sarPara.TagInformation = new TagInfo();
            sarPara.TagInformation.EPC = tagEPC;
            sarPara.TagInformation.Frequency = freq;
            sarPara.TagInformation.AcutalPhaseInRadian = measuredPhase;
            sarPara.TagInformation.TotalTagCount = _simulationIndex++;

            _sarParaQueue.Enqueue(sarPara);
        }

        private void UpdateHologram(List<List<double>> data)
        {
            _heatmap.DrawHeatMap(data);
        }

        private void UpdateResultTextBox(int round, string epc)
        {
            tbxLocalizationResult.AppendText("Round " + round + ": " + epc + " (" + SARParameter.PredictedX + "," + SARParameter.PredictedY + ")" + "\r\n");
            //Scroll to the last line
            tbxLocalizationResult.SelectionStart = tbxLocalizationResult.Text.Length;
            tbxLocalizationResult.ScrollToCaret();
        }

        private void btnSimulationStop_Click(object sender, EventArgs e)
        {
            cbAlgorithms.Enabled = true;
            gbHologram.Enabled = true;
            gbSearchRegion.Enabled = true;
            gbAntennaTrack.Enabled = true;

            _timers.Stop();
            _th.Abort();

            gbSimulationTagPosition.Enabled = true;
            gbSimulationFrequncy.Enabled = true;
            btnHolographicsConfirm.Enabled = true;
            btnSimulationStop.Enabled = false;
        }

        private void cbAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            SARParameter.SelectedSARAlgorithm = cbAlgorithms.Text;
        }

        private void dgvSimulationTagPosition_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index);
        }

        private void cbDisplayHologram_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayHologram.Checked)
            {
                tbxRefreshInterval.Enabled = true;
                nudTagIndexForHologram.Enabled = true;
            }
            else
            {
                tbxRefreshInterval.Enabled = false;
                nudTagIndexForHologram.Enabled = false;
            }
        }


        //------SAR------
    }
}
