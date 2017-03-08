using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using System.Collections.Concurrent;
using System.ServiceModel;
namespace CalculateApp
{

    public class OriginSAR : AbstractCalculate, ILocalCalculateService
    {
        /**
         * 覆盖父类方法
         */
        private const double THRESHOLD = 0;
        public new void calculate(double antX, double antY, double antZ, int freq, double measuredPhase)
        {
            base.calculate(antX, antY, antZ, freq, measuredPhase);
            double gridValueMax = double.MinValue;
            double waveLength = LIGHT_SPEED / Convert.ToDouble(freq);
            double distance = 0;
            double idealPhase = 0;
            double deltaPhase = 0;
            double sum = 0;
            Tuple<int, int, int>[] tuples = this.pfMap.Keys.ToArray<Tuple<int, int, int>>();
            foreach (Tuple<int,int,int> tuple in tuples)
            {
                int k = tuple.Item1;
                int i = tuple.Item2;
                int j = tuple.Item3;
                distance = Math.Sqrt(Math.Pow(antX - gridX[j], 2) + Math.Pow(antY - gridY[i], 2) + Math.Pow(antZ - gridZ[k], 2));
                idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);
                deltaPhase = (idealPhase - measuredPhase) % (2 * Math.PI);
                Complex value = this.pfMap[tuple] + Complex.Exp(Complex.ImaginaryOne * deltaPhase);
                pfMap[tuple] = value;
                double sarAbsValue = Complex.Abs(value);
                this.absValueMap[tuple] = sarAbsValue;
                sum += sarAbsValue;
                if (sarAbsValue > gridValueMax)
                {
                    gridValueMax = sarAbsValue;
                    Console.WriteLine("X: " + gridX[j] + " Y: " + gridY[i] + " Z: " + gridZ[k]);
                }
            }
            Dictionary<Tuple<int, int, int>, double> newAbsValueMap = new Dictionary<Tuple<int, int, int>, double>();
            foreach (KeyValuePair<Tuple<int, int, int>, double> kvp in this.absValueMap)
            {
                Tuple<int, int, int> tuple = kvp.Key;
                double proportion = kvp.Value / sum;
                if (proportion > THRESHOLD)
                {
                    newAbsValueMap.Add(tuple,kvp.Value);
                }
                else
                {
                    this.pfMap.Remove(tuple);
                }
            }
            this.absValueMap = newAbsValueMap;
        }
    }
}
