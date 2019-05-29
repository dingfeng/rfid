using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.Analysis
{
    class AppMath
    {
        double _count;
        double _sum;
        double _square;
        double _average;

        public AppMath()
        {
            _count = 0;
            _sum = 0;
            _square = 0;
            _average = 0;
        }

        public double CalculateVariance(double data)
        {
            _count += 1;
            _sum += data;
            _square += data * data;
            _average = _sum / _count;

            return _square / _count - _average * _average;
        }

        /// <summary>
        /// Generate Normal distribution
        /// </summary>
        /// <param name="x">variable</param>
        /// <param name="mu">mean value</param>
        /// <param name="sigma">standard deviation</param>
        /// <returns></returns>
        public static double NormCDF(double x, double mu, double sigma)
        {
            return 1.0 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(x - mu, 2) / (2 * Math.Pow(sigma, 2)));
        }

        public static double GetNormalDistribution(double mu, double sigma)
        {
            double result = Double.MinValue;
            Random rand = new Random();
            double u1;
            double u2;

            u1 = rand.NextDouble();
            u2 = rand.NextDouble();

            try
            {
                result = mu + Math.Sqrt(sigma) * Math.Sqrt((-2) * (Math.Log(u1) / Math.Log(Math.E))) * Math.Sin(2 * Math.PI * u2);
            }
            catch (Exception)
            {
                result = Double.MinValue;
                throw;
            }

            return result;
        }
    }
}
