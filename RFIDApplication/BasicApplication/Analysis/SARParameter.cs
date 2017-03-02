 using BasicApplication.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicApplication.Analysis
{
    public class SARParameter
    {
        //Parameters for calculating phase
        public const int C = 299792458;            // The speed of light specified in m/s
        public const int FrequencyHoppingInterval = 250000; //Interval between two adjacent frequcny specified in Hz
     
        //Search Area
        public static List<double> GridX { get; set; }       //The x-coordinate of sampling points in the grid
        public static List<double> GridY { get; set; }       //The y-coordinate of sampling points in the grid
        public static List<double> GridZ { get; set; }       //The z-coordinate of sampling points in the grid

        //Antenna
        public double AntennaX { get; set; }    //The x-coordinate of the antenna
        public double AntennaY { get; set; }    //The y-coordinate of the antenna
        public double AntennaZ { get; set; }    //The z-coordinate of the antenna

        //TagInfo 
        public TagInfo TagInformation { get; set; } //Tag Information in each round
        
        //Predicted Points
        public static double PredictedX { get; set; }  //Predicted x-coordinate in each round
        public static double PredictedY { get; set; }  //Predicted y-coordinate in each round
        public static double PredictedZ { get; set; }  //Predicted z-coordinate in each round

        //Synthetix Aperture Radar
        public static List<List<double>> Hologram { get; set; }   //To Generate the hologram in each round
        
        //SAR algorithm type
        public static string SelectedSARAlgorithm { get; set; }

        internal class Simulation
        {
            //Tag information for simulation
            public static List<double> TagXs { get; set; }    //The x-coordinates of the tag
            public static List<double> TagYs { get; set; }    //The y-coordinates of the tag
            public static List<double> TagZs { get; set; }    //The z-coordinates of the tag
            public static List<string> Tags { get; set; }     //Tag EPC
        }
        
       
    }
}
