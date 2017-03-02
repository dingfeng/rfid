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
    }
}
