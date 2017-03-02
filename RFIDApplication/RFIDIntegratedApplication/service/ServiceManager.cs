using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.ServiceReference1;
using RFIDIntegratedApplication.ServiceReference2;
namespace RFIDIntegratedApplication.service
{
    public class ServiceManager
    {
        public static IImpinjControlService getOneImpinjControlService()
        {
            return new ImpinjControlServiceClient();
        }

        public static void  closeService(IImpinjControlService service)
        {
            ((ImpinjControlServiceClient)service).Close();
        }

        public static IDmcControlService getOneDmcControlService()
        {
            return new DmcControlServiceClient();
        }

        public static void closeService(IDmcControlService service)
        {
            ((DmcControlServiceClient)service).Close();
        }
    }
}
