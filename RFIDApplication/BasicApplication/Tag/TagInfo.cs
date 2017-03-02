using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicApplication.Tag
{
    public class TagInfo
    {
        public string EPC { get; set; }            
        public ulong FirstSeenTime { get; set; }   //The time of the first tag read for the EPC conveyed in this tag report
        public ulong LastSeenTime { get; set; }    //The time of the last tag read for the EPC conveyed in this tag report
        public ulong TimeStamp { get; set; }       //The time between first tag read and last tag read conveyed in this tag report
        public ushort Antenna { get; set; }        
        public double TxPower { get; set; }
        public ushort ChannelIndex { get; set; }    
        public double Frequency { get; set; }

        public float RSSI { get; set; }            
        public ushort RawPhase { get; set; }             //Phase value without handling
        public double AcutalPhaseInRadian { get; set; }  //AcutalPhaseInRadian = 2*pi-2*pi*RawPhase/4096  Actual Phase value in the form of Radian
        public int DopplerShift { get; set; }    
        public double Velocity { get; set; }
        public int TagSeenCount { get; set; }       //The number of tag reads of this EPC conveyed in this tag report
        public int TotalTagCount { get; set; }     //The number of total tag reports
    }
}
