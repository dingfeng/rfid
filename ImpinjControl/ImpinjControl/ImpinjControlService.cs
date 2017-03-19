using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.Impinj;
using System.IO;
using System.ServiceModel;
namespace ImpinjControl
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                 ConcurrencyMode = ConcurrencyMode.Single)]
    public class ImpinjControlService : IImpinjControlService
    {
        volatile   LLRPClient _reader;
        volatile   ReaderSettings _readerSettings;
        volatile   string _filepath = ".";         //The filepath of App related file
        volatile   uint _currentSpecID;      //Make sure all the ROSpec operations are in the same ROSpec
        volatile   bool started;  //是否已经start
        volatile   bool connected; //是否已经建立连接
        volatile   bool impinjInstalled;
        public ConnectResponse connect(string address)
        {
            try
            {
                if (this.connected)
                {
                    Console.WriteLine("已存在连接 status: connected");
                    return new ConnectResponse(_readerSettings.antennaConfiguration, _readerSettings.readerCapabilities, _readerSettings.rOReportSpec);
                }
                _reader = new LLRPClient();
                if(impinjInstalled == false)
                { 
                    Impinj_Installer.Install();
                    impinjInstalled = true;
                }

                ENUM_ConnectionAttemptStatusType status;
                bool ret = _reader.Open(address, 2000, out status);
                AntennaConfiguration antennaConfiguration;
                ReaderCapabilities readerCapabilities;
                if (!ret || status != ENUM_ConnectionAttemptStatusType.Success)
                {
                    Console.WriteLine("Failed to Connect to Reader!");
                    if (status.ToString().Equals("-1"))
                    {
                        Console.WriteLine("Wrong Address");
                    }
                    else
                    {
                        Console.WriteLine(status.ToString());
                    }
                    connected = false;
                    _reader.Close();
                    return null;
                }
                else
                {
                    Console.WriteLine("Succeeded to Connect to Reader!");
                    _readerSettings = new ReaderSettings(_reader);
                    _readerSettings.AddEventHandler();
                    _readerSettings.Enable_Impinj_Extensions();
                    readerCapabilities = _readerSettings.GetReaderCapabilities();
                    if (readerCapabilities == null)
                    {
                        _reader.Close();
                        connected = false;
                        return null;
                    }
                    antennaConfiguration = new AntennaConfiguration();
                    antennaConfiguration.init(readerCapabilities);
                    antennaConfiguration = _readerSettings.getRFIDReaderPara(antennaConfiguration, readerCapabilities.MaxNumberOfAntennaSupported);
                    _readerSettings.antennaConfiguration = antennaConfiguration;
                    _readerSettings.rOReportSpec = new ROReportSpec();
                    ConnectResponse connectResponse = new ConnectResponse(antennaConfiguration, readerCapabilities, _readerSettings.rOReportSpec);
                    connected = true;
                    Console.WriteLine("status: connected");
                    return connectResponse;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        public void startInventory(AntennaConfiguration antennaConfiguration, ROReportSpec rOReportSpec)
        {
            try
            {
                if (connected && !started)
                {
                    _readerSettings.clearTagInfoQueue();
                    _readerSettings.SetReaderConfiguration(_filepath, antennaConfiguration, rOReportSpec);
                    _currentSpecID = _readerSettings.AddROSpec(_filepath);
                    _readerSettings.Enable_ROSpec(_currentSpecID);
                    _readerSettings.Start_ROSpec(_currentSpecID);
                    started = true;
                    _readerSettings.TotalTagCount = 0;
                    Console.WriteLine("status: started");
                }
            }
            catch (Exception e )
            {
                Console.WriteLine(e.ToString());
            }
        }



        public void stopInventory()
        {
            try
            {
                if (connected && started)
                {
                    _readerSettings.Stop_ROSpec(_currentSpecID);
                    started = false;
                    Console.WriteLine("status:connected");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<TagInfo> tryDeque()
        {
            List<TagInfo> tagInfoList = new List<TagInfo>();
            try
            {

                TagInfo tagInfo;
                while (_readerSettings.tagInfoQueue.TryDequeue(out tagInfo))
                {
                    tagInfoList.Add(tagInfo);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return tagInfoList;
        }

        public void disconnect()
        {
            try
            {
                if (this.connected)
                {
                    if (started)
                    {
                        _readerSettings.Stop_ROSpec(_currentSpecID);
                        started = false;
                    }
                    _readerSettings.DeleteEventHandler();
                    _reader.Close();
                    this.connected = false;
                    Console.WriteLine("status: disconnected");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
