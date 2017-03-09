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
        protected int count;
        protected List<double> gridX;
        protected List<double> gridY;
        protected List<double> gridZ;
        protected int _count;
        protected Dictionary<Tuple<int, int, int>, Complex> pfMap = new Dictionary<Tuple<int, int, int>, Complex>();
        protected Dictionary<Tuple<int, int, int>, double> absValueMap = new Dictionary<Tuple<int, int, int>, double>();
        protected bool first = true;
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
            this._count = 0;
            this.pfMap.Clear();
            this.absValueMap.Clear();
            first = true;
        }

        /**
         *初始化，三维坐标系上分配网格
         */
        public void init(ConfParam confParam)
        {
            clear();
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
                for (int i = 0; i < yCount; i++)
                {
                    for (int j = 0; j < xCount; j++)
                    {
                        Tuple<int, int, int> tuple = new Tuple<int, int, int>(k,i,j);
                        pfMap.Add(tuple,0);
                        absValueMap.Add(tuple, 0);
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
