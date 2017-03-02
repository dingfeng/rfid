using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDIntegratedApplication.Tag;
using RFIDIntegratedApplication.ServiceReference1;
namespace RFIDIntegratedApplication.Analysis
{

    public class PhaseLocating
    {
        private List<PhaseRecord> phaseRecords = new List<PhaseRecord>(); //相位记录列表
        private int positionSetIndex = 0;     //下一个需要设置位置信息的相位记录
        private List<PositionRecord> positionRecords = new List<PositionRecord>();  //位置信息
                                                                                    //  public PhaseRecord lowestPhaseRecord 相位最低点
        private static PhaseLocating phaseLocating = new PhaseLocating();
        public TagsWithPosTable tagsWithPosTable = new TagsWithPosTable();
        public bool started; //是否已经开始
        public void Clear()
        {
            this.tagsWithPosTable.Clear();
            this.phaseRecords.Clear();
            this.positionRecords.Clear();
            this.positionSetIndex = 0;
            // string epc,double phase,double x, double angle
        }


        private PhaseLocating()
        {

        }

        public static PhaseLocating getInstance()
        {
            return phaseLocating;
        }

        //添加相位记录
        public void addPhaseRecord(TagInfo tagInfo)
        {
            PhaseRecord phaseRecord = new PhaseRecord(tagInfo);
            phaseRecords.Add(phaseRecord);
        }

        //添加位置记录
        public void addPositionRecord(float x, float angle, ulong timestamp)
        {

            if (started)
            {
                PositionRecord positionRecord = new PositionRecord(x, angle, timestamp);
                positionRecords.Add(positionRecord);
                updatePhasePosition();
            }
        }



        //更新相位位置信息
        private void updatePhasePosition()
        {
            int phaseRecordsSize = phaseRecords.Count;
            for (int i = positionSetIndex; i < phaseRecordsSize; ++i)
            {
                PhaseRecord phaseRecord = phaseRecords[i];
                ulong phaseTimestamp = phaseRecord.timestamp;
                int positionRecordsSize = positionRecords.Count;
                int j = 0;
               // Console.WriteLine("phaseTimestamp=" + phaseTimestamp);
                for (j = positionRecordsSize - 1; j > 0; --j)
                {
                    PositionRecord positionRecord = positionRecords[j];
                 //   Console.WriteLine("positionRecordTimestamp=" + positionRecord.timestamp);
                    if (phaseTimestamp > positionRecord.timestamp)
                    {
                        if (j < positionRecordsSize - 1)
                        {
                            //找到时间区间
                            PositionRecord tmpPositionRecord = estimatePosition(positionRecords[j], positionRecords[j + 1], phaseTimestamp);
                            phaseRecord.angle = tmpPositionRecord.angle;
                            phaseRecord.x = tmpPositionRecord.x;
                            
                            tagsWithPosTable.addTagInfo(phaseRecord.epc, phaseRecord.phase, phaseRecord.x, phaseRecord.angle,phaseRecord.timestamp);
                            //将标签和位置信息加入队列
                            double radAngle = phaseRecord.angle / (360 * 60) * 2 * Math.PI;
                            double xDiff  = 0.35 * Math.Cos(radAngle);
                            double zDiff = 0.35 * Math.Sin(radAngle);
                            TagPos tagPos = new TagPos(phaseRecord.tagInfo,new Tuple<double,double,double>(phaseRecord.x/1000-0.02+xDiff,1.4,zDiff));
                            SARParameter.tagPosQueue.Enqueue(tagPos);
                            positionSetIndex++;
                        }
                        break;
                    }
                }
                if (j <= 0)
                {
                    positionSetIndex++;
                    break;
                }
            }
        }

        //决定位置
        private PositionRecord estimatePosition(PositionRecord positionRecord1, PositionRecord positionRecord2, ulong timestamp)
        {
            float f = (float)((timestamp - positionRecord1.timestamp) * 1.0 / (positionRecord2.timestamp - positionRecord1.timestamp));
            float x = positionRecord1.x + (positionRecord2.x - positionRecord1.x) * f;
            float angle = positionRecord1.angle + (positionRecord2.angle - positionRecord1.angle) * f;
            PositionRecord positionRecord = new PositionRecord(x, angle, timestamp);
            return positionRecord;
        }
    }
}
