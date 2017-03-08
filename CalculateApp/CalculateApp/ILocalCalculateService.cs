using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateApp
{
    public interface ILocalCalculateService
    {
        void calculate( double antX, double antY, double Z, int freq, double measuredPhase);
    }
}
