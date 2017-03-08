using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace CalculateApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
     ConcurrencyMode = ConcurrencyMode.Single)]
    public class OriginSarService : ICalculateService
    {
        private Dictionary<string, ILocalCalculateService> map = new Dictionary<string, ILocalCalculateService>();

        public void calculate(string epc, double antX, double antY, double Z, int freq, double measuredPhase)
        {
            ILocalCalculateService iLocalCalculateService = map[epc];
            iLocalCalculateService.calculate(antX, antY, Z, freq, measuredPhase);
        }

        public void clear(string epc)
        {
            map.Remove(epc);
        }

        public void clearAll()
        {
            map.Clear();
        }

        public void init(string epc, ConfParam confParam)
        {
            AbstractCalculate localCalculateService = new OriginSAR();
            localCalculateService.init(confParam);
            if (!map.ContainsKey(epc))
            {
                map.Add(epc, localCalculateService);
            }
        }
    }
}
