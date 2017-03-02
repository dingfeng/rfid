using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicApplication.Tag
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
            Tags.Columns.Add("RSSI");
            Tags.Columns.Add("TimeStamp");
            Tags.Columns.Add("Phase");
            Tags.Columns.Add("Doppler Shift");
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
            row["RSSI"] = tagInfo.RSSI;
            row["TimeStamp"] = tagInfo.FirstSeenTime;   //?
            row["Phase"] = tagInfo.RawPhase;
            row["Doppler Shift"] = tagInfo.DopplerShift;
            row["Velocity"] = tagInfo.Velocity;
            Tags.Rows.Add(row);
        }

        public void Clear()
        {
            _tags.Clear();
        }
    }
}
