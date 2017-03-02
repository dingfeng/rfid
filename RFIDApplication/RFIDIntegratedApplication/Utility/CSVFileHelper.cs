using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDIntegratedApplication.Utility
{
    public class CSVFileHelper
    {
        public static void SaveCSV(DataTable dt, string filepath)
        {
            FileMode mode;
            if (File.Exists(filepath)){
                mode = FileMode.Truncate;
            }
            else
            {
                mode = FileMode.OpenOrCreate;
            }
            using (FileStream fs = new FileStream(filepath, mode, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    string data = "";

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        data += dt.Columns[i].ColumnName.ToString();
                        if (i < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            string str = dt.Rows[i][j].ToString();
                            str = str.Replace("\"", "\"\"");
                            if (str.Contains('\r') || str.Contains('"') || str.Contains('\r') || str.Contains('\n'))
                            {
                                str = string.Format("\"{0}\"", str);
                            }
                            data += str;
                            if (j < dt.Columns.Count - 1)
                            {
                                data += ",";
                            }
                        }
                        sw.WriteLine(data);
                    }
                    sw.Flush();
                }
            }
        }

    }
}
