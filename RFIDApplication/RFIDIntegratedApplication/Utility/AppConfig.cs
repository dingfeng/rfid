using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace RFIDIntegratedApplication.Utility
{
    class AppConfig
    {
        public static DockState readerSettingsDockState = DockState.DockLeft;
        public static DockState tagTableDockState = DockState.Document;
        public static DockState rssiGraphDockState = DockState.Document;
        public static DockState phaseGraphDockState = DockState.Document;
        public static DockState holographicsDockState = DockState.Document;

        public static DockState searchRegionDockState = DockState.DockRight;
        public static DockState updateEpcDockState = DockState.DockRight;
        public static DockState hologramDockState = DockState.Document;
        public static DockState simulationDockState = DockState.DockRight;

        public static DockState linearGuideDockState = DockState.DockRight;
        public static DockState sortingBooksDockState = DockState.Document;


    }
}
