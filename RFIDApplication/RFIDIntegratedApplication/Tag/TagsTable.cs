using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Tag
{
    public class TagsTable
    {
        DataTable _tags;

        public TagsTable()
        {
            this._tags = new DataTable("tags");
            Tags.Columns.Add("EPC");
            Tags.Columns.Add("Antenna");
            Tags.Columns.Add("Channel");
            Tags.Columns.Add("TimeStamp/us");
            Tags.Columns.Add("RSSI/dBm");
            Tags.Columns.Add("Phase/rad");
            Tags.Columns.Add("Doppler Shift/Hz");
            Tags.Columns.Add("Velocity");
        }
        
        public DataTable Tags
        {
            get
            {
                return _tags;
            }

            set
            {
                _tags = value;
            }
        }

        public void AddTagInfo(TagInfo tagInfo)
        {
            DataRow row = Tags.NewRow();
            row["EPC"] = tagInfo.EPC;
            row["Antenna"] = tagInfo.Antenna;
            row["Channel"] = tagInfo.ChannelIndex;
            row["TimeStamp/us"] = tagInfo.TimeStamp;
            row["RSSI/dBm"] = tagInfo.RSSI; 
            row["Phase/rad"] = tagInfo.AcutalPhaseInRadian;
            row["Doppler Shift/Hz"] = tagInfo.DopplerShift;
            row["Velocity"] = tagInfo.Velocity;
            Tags.Rows.Add(row);
        }

        public void Clear()
        {
            _tags.Clear();
        }
    }
}
