using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace RFIDIntegratedApplication.Tag
{
    public class TagsWithPosTable
    {
        public  DataTable tags;
        public TagsWithPosTable()
        {
            tags = new DataTable();
            tags.Columns.Add("epc");
            tags.Columns.Add("phase");
            tags.Columns.Add("x");
            tags.Columns.Add("angle");
            tags.Columns.Add("time");
        }

        public void addTagInfo(string epc,double phase,double x, double angle, ulong time)
        {
            DataRow row = this.tags.NewRow();
            row["epc"] =epc;
            row["phase"] = phase;
            row["x"] = x;
            row["angle"] = angle;
            row["time"] = time;
            this.tags.Rows.Add(row);
        }

        public void Clear()
        {
            this.tags.Clear();
        }

    }
}
