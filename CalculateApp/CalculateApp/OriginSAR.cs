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
        public new void calculate(double antX, double antY, double antZ, int freq, double measuredPhase)
        {
            base.calculate(antX, antY, antZ, freq, measuredPhase);
            double gridValueMax = double.MinValue;
            double waveLength = LIGHT_SPEED / Convert.ToDouble(freq);
            double distance = 0;
            double idealPhase = 0;
            double deltaPhase = 0;
            for (int k = 0; k < this._sar.Count; k++)
            {
                //Grid Row
                for (int i = 0; i < this._sar[k].Count; i++)
                {
                    //Grid Column
                    for (int j = 0; j < this._sar[k][i].Count; j++)
                    {
                        distance = Math.Sqrt(Math.Pow(antX - gridX[j], 2) + Math.Pow(antY - gridY[i], 2) + Math.Pow(antZ - gridZ[k], 2));
                        idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);

                        deltaPhase = (idealPhase - measuredPhase) % (2 * Math.PI);
                        this._sar[k][i][j] = this._sar[k][i][j] + Complex.Exp(Complex.ImaginaryOne * deltaPhase);
                        double sarAbsValue = Complex.Abs(this._sar[k][i][j]);
                        if (sarAbsValue > gridValueMax)
                        {
                            gridValueMax = sarAbsValue;
                            Console.WriteLine("X: "+gridX[j]+" Y: "+gridY[i]+" Z: "+gridZ[k]);
                        //    SARParameter.PredictedX = SARParameter.GridX[j];
                        //    SARParameter.PredictedY = SARParameter.GridY[i];
                        //    SARParameter.PredictedZ = SARParameter.GridZ[k];
                        }
                    }
                }
            }
           
        }
    }
}
