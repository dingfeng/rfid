using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicApplication
{
    public partial class SearchReaderIPForm : Form
    {
        public string SelectedIP { get; set; }
        public SearchReaderIPForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get ARP strings through arp process
        /// </summary>
        /// <returns></returns>
        private string ARPProcess()
        {
            Process process = null;
            string output = null;

            try
            {
                process = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });
                output = process.StandardOutput.ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (process != null) process.Close();
            }

            return output;
        }

        /// <summary>
        /// Get Host IP Address and MAC Address by matching Regex
        /// </summary>
        private void GetHostAddress()
        {
            StreamReader reader = null;

            try
            {
                string regex = (new StringBuilder(@"^\s+(")).Append(HostAddress.IPRegex)
                    .Append(@")\s+(").Append(HostAddress.MACRegex)
                    .Append(@")\s+\S+\s+$").ToString();
                DataRowCollection rows = dataSet.Tables[0].Rows;
                reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(ARPProcess())));

                rows.Clear();
                while (!reader.EndOfStream)
                {
                    GroupCollection groups = Regex.Match(reader.ReadLine(), regex).Groups;
                    if (groups.Count == 3)
                    {
                        HostAddress address = new HostAddress()
                        {
                            IP = groups[1].Value,
                            MAC = groups[2].Value
                        };

                        rows.Add(address.IP, address.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Searching hosts' IP Failed! " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        private class HostAddress
        {

            public static string IPRegex
            {
                get
                {
                    return @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
                }
            }

            public static string MACRegex
            {
                get
                {
                    return @"[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}";
                }
            }

            public string IP { get; set; }
            public string MAC { get; set; }
            public string HostName { get; set; }

            public override string ToString()
            {
                return string.Format("{0, -19}{1, -21}{2}", IP, MAC, HostName);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetHostAddress();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string selectedIP = (string)listBoxHostAddress.SelectedValue;

            if (selectedIP != null)
            {
                string[] segments = selectedIP.Split(' ');
                SelectedIP = segments[0];
            }
            this.Dispose();
        }

        private void SearchReaderIPForm_Load(object sender, EventArgs e)
        {

        }
    }
}
