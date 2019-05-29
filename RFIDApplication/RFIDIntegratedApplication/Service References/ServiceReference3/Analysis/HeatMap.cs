using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDIntegratedApplication.Analysis
{
    class HeatMap
    {
        static PictureBox _pb;       // PictureBox for heatmap image
        Bitmap _bitmap;              // Heatmap image
        int _maxRow;                 // Row of heatmap
        int _maxCol;                 // Column of heatmap        
        int _rowHeight;              // Hieght of each row
        int _colWidth;               // Width of each column
        List<Color> _colors;         // Colors of heatmap

        public HeatMap(PictureBox pb, int row, int col)
        {
            _pb = pb;

            _maxRow = row;
            _maxCol = col;

            _rowHeight = _pb.ClientSize.Height / row;
            _colWidth = _pb.ClientSize.Width / col;

            _bitmap = new Bitmap(_colWidth * col, _rowHeight * row);

            // create an origin color list
            List<Color> baseColors = new List<Color>();  
            baseColors.Add(Color.RoyalBlue);
            baseColors.Add(Color.LightSkyBlue);
            baseColors.Add(Color.LightGreen);
            baseColors.Add(Color.Yellow);
            baseColors.Add(Color.Orange);
            baseColors.Add(Color.Red);
            _colors = interpolateColors(baseColors, 1001);
        }

        /// <summary>
        /// Draw heatmap using heatmap data from sar
        /// </summary>
        /// <param name="data">heatmap data</param>
        public void DrawHeatMap(List<List<double>> data)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                for (int r = 0; r < _maxRow; r++)
                    for (int c = 0; c < _maxCol; c++)
                    {
                        using (SolidBrush brush = new SolidBrush(_colors[(int)(1000 * data[r][c])]))
                            g.FillRectangle(brush, c * _colWidth, r * _rowHeight, _colWidth, _rowHeight);
                    }
            }

            _pb.Image = _bitmap;
        }

        /// <summary>
        /// Interpolate colors using base colors
        /// </summary>
        /// <param name="baseColors">base colors for generating heatmap colors</param>
        /// <param name="count">the number of heatmap colors</param>
        /// <returns>colors of heatmap</returns>
        List<Color> interpolateColors(List<Color> baseColors, int count)
        {
            SortedDictionary<float, Color> gradient = new SortedDictionary<float, Color>();
            for (int i = 0; i < baseColors.Count; i++)
                gradient.Add(1f * i / (baseColors.Count - 1), baseColors[i]);
            List<Color> ColorList = new List<Color>();

            using (Bitmap bmp = new Bitmap(count, 1))
            using (Graphics G = Graphics.FromImage(bmp))
            {
                Rectangle bmpCRect = new Rectangle(Point.Empty, bmp.Size);
                LinearGradientBrush br = new LinearGradientBrush
                                        (bmpCRect, Color.Empty, Color.Empty, 0, false);
                ColorBlend cb = new ColorBlend();
                cb.Positions = new float[gradient.Count];
                for (int i = 0; i < gradient.Count; i++)
                    cb.Positions[i] = gradient.ElementAt(i).Key;
                cb.Colors = gradient.Values.ToArray();
                br.InterpolationColors = cb;
                G.FillRectangle(br, bmpCRect);
                for (int i = 0; i < count; i++) ColorList.Add(bmp.GetPixel(i, 0));
                br.Dispose();
            }
            return ColorList;
        }
        
    }
}
