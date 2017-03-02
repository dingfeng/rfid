using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.Analysis
{
    class SyntheticApertureRadar
    {
        List<List<List<Complex>>> _sar;                // sar value for a grid for each round
        bool _firstPhaseFlag = true;             // Used for difference in Tagoram
        List<List<List<double>>> _firstIdealPhase;     // Used for difference in Tagoram
        double _firstMeasuredPhase;              // Used for difference in Tagoram

        int _count;
        List<List<List<double>>> _sum;
        List<List<List<double>>> _square;
        List<List<List<double>>> _average;

        public SyntheticApertureRadar()
        {
            this._sar = new List<List<List<Complex>>>();
            this._firstIdealPhase = new List<List<List<double>>>();
            this._sum = new List<List<List<double>>>();
            this._square = new List<List<List<double>>>();
            this._average = new List<List<List<double>>>();

            _count = 0;
            for (int k = 0; k < SARParameter.GridZ.Count; k++)
            {
                this._sar.Add(new List<List<Complex>>());
                this._firstIdealPhase.Add(new List<List<double>>());
                this._sum.Add(new List<List<double>>());
                this._square.Add(new List<List<double>>());
                this._average.Add(new List<List<double>>());
                for (int i = 0; i < SARParameter.GridY.Count; i++)
                {
                    this._sar[k].Add(new List<Complex>());
                    this._firstIdealPhase[k].Add(new List<double>());

                    this._sum[k].Add(new List<double>());
                    this._square[k].Add(new List<double>());
                    this._average[k].Add(new List<double>());
                    for (int j = 0; j < SARParameter.GridX.Count; j++)
                    {
                        this._sar[k][i].Add(0);
                        this._firstIdealPhase[k][i].Add(0);

                        this._sum[k][i].Add(0);
                        this._square[k][i].Add(0);
                        this._average[k][i].Add(0);
                    }
                }
            }

            SARParameter.PredictedX = double.MinValue;
            SARParameter.PredictedY = double.MinValue;
        }

        /// <summary>
        /// Origin Synthetic Aperture Radar techniuqe
        /// </summary>
        /// <param name="antX">Antenna position x</param>
        /// <param name="antY">Antenna position y</param>
        /// <param name="freq">Frequency</param>
        /// <param name="measuredPhase">Measured phase</param>
        public void OriginSAR(double antX, double antY, double antZ, int freq, double measuredPhase)
        {
            _count++;

            double gridValueMax = double.MinValue;

            double waveLength = SARParameter.C / Convert.ToDouble(freq);
            double distance = 0;
            double idealPhase = 0;
            double deltaPhase = 0;
            for (int k = 0; k < SARParameter.GridZ.Count; k++)
            {
                //Grid Row
                for (int i = 0; i < SARParameter.GridY.Count; i++)
                {
                    //Grid Column
                    for (int j = 0; j < SARParameter.GridX.Count; j++)
                    {
                        distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2) + Math.Pow(antZ - SARParameter.GridZ[k], 2));
                        idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);

                        deltaPhase = (idealPhase - measuredPhase) % (2 * Math.PI);
                        //Console.WriteLine("delta-(" + SARParameter.GridX[j] + ", " + SARParameter.GridY[i] + ") " + Math.Round(deltaPhase, 3));

                        //_sum[i][j] += deltaPhase;
                        //_square[i][j] += deltaPhase * deltaPhase;
                        //_average[i][j] = _sum[i][j] / _count;

                        this._sar[k][i][j] = this._sar[k][i][j] + Complex.Exp(Complex.ImaginaryOne * deltaPhase);

                        //  SARParameter.Hologram[i][j] = Complex.Abs(this._sar[i][j]);
                        //Console.WriteLine("holo-(" + SARParameter.GridX[j] + ", " + SARParameter.GridY[i] + ") " + Math.Round(SARParameter.Hologram[i][j],3));

                        // Console.WriteLine("var-(" + SARParameter.GridX[j] + ", " + SARParameter.GridY[i] + ") " + Math.Round(_square[i][j] / _count - _average[i][j] * _average[i][j], 3));
                        double sarAbsValue = Complex.Abs(this._sar[k][i][j]);
                        if (sarAbsValue > gridValueMax)
                        {
                            gridValueMax = sarAbsValue;
                            SARParameter.PredictedX = SARParameter.GridX[j];
                            SARParameter.PredictedY = SARParameter.GridY[i];
                            SARParameter.PredictedZ = SARParameter.GridZ[k];
                        }
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

        /// <summary>
        /// Reference: Tagoram: Real-time tracking of mobile RFID tags to high precision using COTS devices
        /// </summary>
        /// <param name="antX">Antenna position x</param>
        /// <param name="antY">Antenna position y</param>
        /// <param name="freq">Frequency</param>
        /// <param name="measuredPhase">Measured phase</param>
        /// /
        public void Tagoram(double antX, double antY, int freq, double measuredPhase)
        {
            /*
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
                        distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2)+1);
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
                        distance = Math.Sqrt(Math.Pow(antX - SARParameter.GridX[j], 2) + Math.Pow(antY - SARParameter.GridY[i], 2) + 1);
                        idealPhase = (4 * Math.PI * distance / waveLength) % (2 * Math.PI);

                        // AH
                        deltaPhase = idealPhase - measuredPhase - (_firstIdealPhase[i][j] - _firstMeasuredPhase);
                        // DAH
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
            */
        }

        public void MobiTagbot()
        {

        }

        /// <summary>
        /// Generate Normal distribution
        /// </summary>
        /// <param name="x">variable</param>
        /// <param name="mu">mean value</param>
        /// <param name="sigma">standard deviation</param>
        /// <returns></returns>
        public double NormCDF(double x, double mu, double sigma)
        {
            return 1.0 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(x - mu, 2) / (2 * Math.Pow(sigma, 2)));
        }

    }
}
