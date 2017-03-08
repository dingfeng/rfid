using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateApp
{
    public abstract class AbstractCalculate : ILocalCalculateService
    {
        public const int LIGHT_SPEED = 299792458;  //光速
        protected List<List<List<Complex>>> _sar;
        protected int count;
        protected List<List<List<double>>> _sum;
        protected List<List<List<double>>> _square;
        protected List<List<List<double>>> _average;
        protected List<double> gridX;
        protected List<double> gridY;
        protected List<double> gridZ;
        protected int _count;

        /**
         * 对一条数据进行计算
         */
        public void calculate(double antX, double antY, double Z, int freq, double measuredPhase)
        {
            count++;
        }

        /**
         * 清空
         */
        public void clear()
        {
            this._sar = null;
            this._sum = null;
            this._square = null;
            this._average = null;
            this._count = 0;
        }

        /**
         *初始化，三维坐标系上分配网格
         */
        public void init(ConfParam confParam)
        {
            clear();
            this._count++;
            this._sar = new List<List<List<Complex>>>();
            this._sum = new List<List<List<double>>>();
            this._square = new List<List<List<double>>>();
            this._average = new List<List<List<double>>>();
            int xCount = Convert.ToInt32((confParam.xEnd - confParam.xStart) / confParam.xInterval) + 1;
            int yCount = Convert.ToInt32((confParam.yEnd - confParam.yStart) / confParam.yInterval) + 1;
            int zCount = Convert.ToInt32((confParam.zEnd - confParam.zStart) / confParam.zInterval) + 1;
            gridX = new List<double>();
            fillList(gridX, confParam.xStart, confParam.xInterval, xCount);
            gridY = new List<double>();
            fillList(gridY, confParam.yStart, confParam.yInterval, yCount);
            gridZ = new List<double>();
            fillList(gridZ, confParam.zStart, confParam.zInterval, zCount);
            for (int k = 0; k < zCount; k++)
            {
                this._sar.Add(new List<List<Complex>>());
                this._sum.Add(new List<List<double>>());
                this._square.Add(new List<List<double>>());
                this._average.Add(new List<List<double>>());
                for (int i = 0; i < yCount; i++)
                {
                    this._sar[k].Add(new List<Complex>());
                    this._sum[k].Add(new List<double>());
                    this._square[k].Add(new List<double>());
                    this._average[k].Add(new List<double>());
                    for (int j = 0; j < xCount; j++)
                    {
                        this._sar[k][i].Add(0);
                        this._sum[k][i].Add(0);
                        this._square[k][i].Add(0);
                        this._average[k][i].Add(0);
                    }
                }
            }
        }

        private void fillList(List<double> list, double start, double interval, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(start + i * interval);
            }
        }
    }

}
