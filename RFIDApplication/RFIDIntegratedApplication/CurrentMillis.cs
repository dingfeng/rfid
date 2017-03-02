using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication
{
    public class CurrentMillis
    {
        private static readonly DateTime jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
        public static long MicroSeconds { get { return (DateTime.UtcNow.Ticks - jan1St1970.Ticks) / 10; } }
    }
}
