using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.Utility
{
    interface IFormable
    {
        /// <summary>
        /// Update the status of components in the form
        /// </summary>
        /// <param name="flag">Indicates starting or stoping inventorying</param>
        /// <param name="isSimulation">Indicates whether it is simulation</param>
        void UpdateComponentStatus(int flag, bool isSimulation);

        /// <summary>
        /// Clear all components created by this form before Inventroring 
        /// </summary>
        void Clear();
    }
}
