using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicApplication.Analysis
{
    public class HeatMap
    {
        PictureBox _pb;
        Bitmap _bitmap;
        int _maxRow;
        int _maxCol;
        int _rowHeight;
        int _colWidth;
        List<Color> _colors;

        public HeatMap(PictureBox pb, int row, int col)
        {
            _pb = pb;
            _maxRow = row;
            _maxCol = col;
           
            _rowHeight = _pb.ClientSize.Height / row;
            _colWidth = _pb.ClientSize.Width / col;

            _bitmap = new Bitmap(_colWidth * col, _rowHeight * row);
            
            List<Color> baseColors = new List<Color>();  // create a color list
            baseColors.Add(Color.RoyalBlue);
            baseColors.Add(Color.LightSkyBlue);
            baseColors.Add(Color.LightGreen);
            baseColors.Add(Color.Yellow);
            baseColors.Add(Color.Orange);
            baseColors.Add(Color.Red);
            _colors = interpolateColors(baseColors, 1001);
        }

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

        List<Color> interpolateColors(List<Color> stopColors, int count)
        {
            SortedDictionary<float, Color> gradient = new SortedDictionary<float, Color>();
            for (int i = 0; i < stopColors.Count; i++)
                gradient.Add(1f * i / (stopColors.Count - 1), stopColors[i]);
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
