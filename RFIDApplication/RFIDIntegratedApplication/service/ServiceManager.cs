using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.ServiceReference1;
using RFIDIntegratedApplication.ServiceReference2;
using RFIDIntegratedApplication.ServiceReference3;
using System.ServiceModel;
using System.Reflection;

namespace RFIDIntegratedApplication.service
{
    public class ServiceManager
    {
        public static IImpinjControlService getOneImpinjControlService()
        {
            return new ImpinjControlServiceClient();
        }

        public static void closeService(IImpinjControlService service)
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

        /**
         * 根据算法的枚举获得算法的远程代理对象
         */
        public static ICalculateService getCalculateService (CalculateType calculateType)
        {
            string className = getStringValue(calculateType);
            if (className == null)
            {
                return null;
            }
            Type type = Type.GetType(className);
            object obj = Activator.CreateInstance(type);
            return (ICalculateService)obj;
        }

        public static void closeService(ICalculateService calculateService)
        {
            //关闭服务
            ((ClientBase<ICalculateService>)calculateService).Close();
        }

        private static string getStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }
    }
}  
