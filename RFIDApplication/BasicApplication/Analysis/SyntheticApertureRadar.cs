using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BasicApplication.Analysis
{
    public class SyntheticApertureRadar
    {
        List<List<Complex>> _sar;
        bool _firstPhaseFlag = true;
        List<List<double>> _firstIdealPhase;
        double _firstMeasuredPhase;

        public SyntheticApertureRadar()
        {
            this._sar = new List<List<Complex>>();
            this._firstIdealPhase = new List<List<double>>();
            SARParameter.Hologram = new List<List<double>>();
            for (int i = 0; i < SARParameter.GridY.Count; i++)
            {
                this._sar.Add(new List<Complex>());
                this._firstIdealPhase.Add(new List<double>());
                SARParameter.Hologram.Add(new List<double>());
                for (int j = 0; j < SARParameter.GridX.Count; j++)
                {
                    this._sar[i].Add(0);
                    this._firstIdealPhase[i].Add(0);
                    SARParameter.Hologram[i].Add(0);
                }
            }

            SARParameter.PredictedX = double.MinValue;
            SARParameter.PredictedY = double.MinValue;
        }

        public double CaculatingSimulationMeasuredPhase(double antX, double antY, double tagX, double tagY, int freq)
        {
            double waveLength = SARParameter.C / Convert.ToDouble(freq);
            double distance = Math.Sqrt(Math.Pow(antX - tagX, 2) + Math.Pow(antY - tagY, 2));
            double simulationMeasuredPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);
            return simulationMeasuredPhase;
        }

        public void OriginSAR(double antX, double antY, int freq, double measuredPhase)
        {
            double gridValueMax = double.MinValue;

            double waveLength = SARParameter.C / Convert.ToDouble(freq);
            double distance = 0;
            double idealPhase = 0;
            double deltaPhase = 0;

            //Grid Row
            for (int i = 0; i < SARParameter.GridY.Count; i++)
            {
                //Grid Column
                for (int j = 0; j < SARParameter.GridX.Count; j++)
                {
                    distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2));
                    idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);

                    deltaPhase = idealPhase - measuredPhase;
                    //deltaPhase = idealPhase - CaculatingSimulationMeasuredPhase(antX, antY, waveLength);

                    this._sar[i][j] = this._sar[i][j] + Complex.Exp(Complex.ImaginaryOne * deltaPhase);

                    SARParameter.Hologram[i][j] = Complex.Abs(this._sar[i][j]);

                    if (SARParameter.Hologram[i][j] > gridValueMax)
                    {
                        gridValueMax = SARParameter.Hologram[i][j];
                        SARParameter.PredictedX = SARParameter.GridX[j];
                        SARParameter.PredictedY = SARParameter.GridY[i];
                    }
                }
            }

            //Normalization
            //Grid Row
            for (int i = 0; i < SARParameter.GridY.Count; i++)
            {
                //Grid Column
                for (int j = 0; j < SARParameter.GridX.Count; j++)
                {
                    SARParameter.Hologram[i][j] = SARParameter.Hologram[i][j] / gridValueMax;

                }
            }
        }

        public void Tagoram(double antX, double antY, int freq, double measuredPhase)
        {
            double gridValueMax = double.MinValue;
            double waveLength = SARParameter.C / Convert.ToDouble(freq);
            double distance = 0;
            double idealPhase = 0;
            double deltaPhase = 0;

            double cdf = 0;

            if (_firstPhaseFlag)
            {
                for (int i = 0; i < SARParameter.GridY.Count; i++)
                {
                    for (int j = 0; j < SARParameter.GridX.Count; j++)
                    {
                        distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2));
                        _firstIdealPhase[i][j] = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);
                    }
                }
                _firstMeasuredPhase = measuredPhase;
                _firstPhaseFlag = false;
                return;
            }
            else
            {

                //Grid Row
                for (int i = 0; i < SARParameter.GridY.Count; i++)
                {
                    //Grid Column
                    for (int j = 0; j < SARParameter.GridX.Count; j++)
                    {
                        distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2));
                        idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);

                        deltaPhase = idealPhase - measuredPhase - (_firstIdealPhase[i][j] - _firstMeasuredPhase);
                        cdf = 2 * NormCDF(-Complex.Abs(deltaPhase), 0, 1.0 * Math.Sqrt(2));
                        this._sar[i][j] = this._sar[i][j] + cdf * Complex.Exp(Complex.ImaginaryOne * deltaPhase);

                        SARParameter.Hologram[i][j] = Complex.Abs(this._sar[i][j]);

                        if (SARParameter.Hologram[i][j] > gridValueMax)
                        {
                            gridValueMax = SARParameter.Hologram[i][j];
                            SARParameter.PredictedX = SARParameter.GridX[j];
                            SARParameter.PredictedY = SARParameter.GridY[i];
                        }
                    }
                }

                //Normalization
                //Grid Row
                for (int i = 0; i < SARParameter.GridY.Count; i++)
                {
                    //Grid Column
                    for (int j = 0; j < SARParameter.GridX.Count; j++)
                    {
                        SARParameter.Hologram[i][j] = SARParameter.Hologram[i][j] / gridValueMax;
                    }
                }

            }

        }

        public void MobiTagbot()
        {

        }

        public double NormCDF(double x, double mu, double sigma)
        {
            return 1.0 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(x - mu, 2) / (2 * Math.Pow(sigma, 2)));
        }
    }
}
