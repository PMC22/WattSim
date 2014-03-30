using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
// Core functionality
using Microsoft.Research.DynamicDataDisplay;
// EnumerableDataSource
using Microsoft.Research.DynamicDataDisplay.DataSources;
// CirclePointMarker
using Microsoft.Research.DynamicDataDisplay.PointMarkers; 

namespace WattSim_03A.Views
{
    /// <summary>
    /// Interaction logic for CarResultsPage.xaml
    /// </summary>

    public partial class CarResultsPage : Page
    {
        /// <summary>
        /// CarResultsPage constructor.
        /// </summary>
        public CarResultsPage()
        {
            InitializeComponent();
            // This runs the ResultsPage_Loaded routine when the element is 
            // laid out, 
            // rendered and ready for interaction:
            Loaded += new RoutedEventHandler(ResultsPage_Loaded);
        }   // End of ResultsPage constructor.

        LineAndMarker<MarkerPointsGraph> VelocityLineGraph;
        LineAndMarker<MarkerPointsGraph> AccelerationLineGraph;
        LineAndMarker<MarkerPointsGraph> TemperatureLineGraph;

        #region ResultsPage_Loaded / Main Routine
        /// <summary> 
        /// This is the main routine that is ran once the page is loaded. 
        /// It is triggered by 'Loaded' Event in the ResultsPage constructor. 
        /// </summary>
        private void ResultsPage_Loaded(object sender, RoutedEventArgs e)
        {
            /// Declare a generic list object, "simDataList", and 
            /// populated the list with the dummy data 
            /// in the file VelocityData.txt by using a program-defined 
            /// helper method named LoadVelocityData. 
            /// To organize my velocity data, a tiny helper class, 
            /// VelocityData, is declared.
            Uri assemblyUri = new Uri(System.Reflection.Assembly.
                GetExecutingAssembly().CodeBase);
            string LocalDir = System.IO.Path.GetDirectoryName(assemblyUri.
                LocalPath);
            List<SimData> SimDataList = LoadSimData(LocalDir + 
                "\\SimData.txt");

            #region Building Arrays
            /// Rather than reading and processing each line of the data 
            /// file, all of the lines could have been read into a string 
            /// array using the File.ReadAllLines method. Notice that both 
            /// to keep the size of the code small and for clarity, the 
            /// normal error-checking that is performed in a production 
            /// environment is ommited. Next the values were declared and 
            /// assigned to three arrays.
            double[] Time = new double[SimDataList.Count];
            double[] Velocity = new double[SimDataList.Count];
            double[] Acceleration = new double[SimDataList.Count];
            double[] Temperature = new double[SimDataList.Count];

            for (int i = 0; i < SimDataList.Count; ++i)
            {
                Time[i] = SimDataList[i].Time;
                Velocity[i] = SimDataList[i].Velocity;
                Acceleration[i] = SimDataList[i].Acceleration;
                Temperature[i] = SimDataList[i].Temperature;
            } // End of for loop.
            #endregion

            #region Convert arrays
            /// When working with the DynamicDataDisplay library, organizing 
            /// the display data into a set of one-dimensional arrays is 
            /// often convenient. As an alternative to this program design, 
            /// which read data into a list object and then transferred the 
            /// list data into arrays, the data could have read directly 
            /// into arrays. Next the data arrays were converted into special 
            /// EnumerableDataSource types.
            /// 
            var TimeDataSource = new EnumerableDataSource<double>(Time);
            TimeDataSource.SetXMapping(x => x);

            var VelocityDataSource = 
                new EnumerableDataSource<double>(Velocity);
            VelocityDataSource.SetYMapping(y => y);

            var AccelerationDataSource = 
                new EnumerableDataSource<double>(Acceleration);
            AccelerationDataSource.SetYMapping(y => y);

            var TemperatureDataSource =
                new EnumerableDataSource<double>(Temperature);
            TemperatureDataSource.SetYMapping(y => y);

            /// For the DynamicDataDisplay library, all data to be graphed 
            /// must be in a uniform format. The three arrays of data were 
            /// just passed to the generic EnumerableDataSource constructor. 
            /// Additionally, the library must be told which axis, x or y, 
            /// is associated with each data source. The SetXMapping and 
            /// SetYMapping methods accept method delegates as arguments. 
            /// Rather than define explicit delegates, lambda expressions 
            /// were used to create anonymous methods. The 
            /// DynamicDataDisplay library’s fundamental-axis data type is 
            /// double. The SetXMapping and SetYMapping methods map the 
            /// particular data type to type double.
            #endregion

            #region Combine data sources
            /// Each composite data source defines a data series.
            CompositeDataSource compositeDataSource1 = new
                CompositeDataSource(TimeDataSource, VelocityDataSource);
            CompositeDataSource compositeDataSource2 = new
                CompositeDataSource(TimeDataSource, 
                    AccelerationDataSource);
            CompositeDataSource compositeDataSource3 = new
                CompositeDataSource(TimeDataSource,
                    TemperatureDataSource);
            #endregion

            #region Plot
            /// With the data all prepared, a single statement actually 
            /// plotted the data points:

            VelocityLineGraph = 
                VelocityPlotter.AddLineGraph
                (
                        compositeDataSource1,
                        new Pen(Brushes.Blue, 2),
                        new CirclePointMarker 
                        { 
                            Size = 0.0, 
                            Fill = Brushes.Blue 
                        },
                        new PenDescription("Velocity in m/s")
                );  // End of AddLineGraph.

            AccelerationLineGraph = 
                AccelerationPlotter.AddLineGraph
                (
                        compositeDataSource2,
                        new Pen(Brushes.Black, 2),
                        new CirclePointMarker
                        { 
                            Size = 0.0, 
                            Fill =  Brushes.Black 
                        },
                        new PenDescription("Acceleration in m/s^2")
                );  // End of AddLineGraph.

            TemperatureLineGraph =
                TemperaturePlotter.AddLineGraph
                (
                        compositeDataSource3,
                        new Pen(Brushes.Red, 2),
                        new CirclePointMarker
                        {
                            Size = 0.0,
                            Fill = Brushes.Red
                        },
                        new PenDescription("Temperature in K")
                );  // End of AddLineGraph.

            /// The AddLineGraph method accepts a CompositeDataSource, 
            /// which defines the data to be plotted, along with 
            /// information about exactly how to plot it. Here the plotter,
            /// object named plotter (defined in the Window1.xaml file), is
            /// instructed to do the following: draw a graph using a blue 
            /// line of thickness 2, place circular markers of size 10 that
            /// have red borders and red fill, and add the series title 
            /// "Velocity in m/s".
            #endregion

            /// The FitToView method scales the graph to the size of the 
            /// WPF window.
            VelocityPlotter.Viewport.FitToView();

        }   // End of ResultsPage_Loaded.
        #endregion

        #region LoadVelocityData Method
        /// <summary>
        /// The LoadSimData method opens the SimData.txt file and iterates through it, 
        /// parsing each field, then instantiates a SimData object and stores each SimData 
        /// object into a result List.
        /// </summary>
        private static List<SimData> LoadSimData(string fileName)
        {
            var result = new List<SimData>();
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] pieces = line.Split(':');
                double Time = double.Parse(pieces[0]);
                double Velocity = double.Parse(pieces[1]);
                double Acceleration = double.Parse(pieces[2]);
                double Temperature = double.Parse(pieces[3]);
                SimData bi = new SimData(Time, Velocity, Acceleration, Temperature);
                result.Add(bi);
            } // End of ReadLine while loop.
            sr.Close();
            fs.Close();
            return result;
        } // End of LoadSimData.
        #endregion

        #region Code Behind Functions
        private void VelocityCheck_Checked(object sender, 
            RoutedEventArgs e)
        {
            VelocityPlotter.Visibility = Visibility.Visible;
            AccelerationPlotter.Visibility = Visibility.Hidden;
            TemperaturePlotter.Visibility = Visibility.Hidden;

            VelocityPlotter.Viewport.FitToView();

            AccelerationCheck.IsChecked = false;
            BrakeTemperatureCheck.IsChecked = false;
        } // End of VelocityCheck_Checked. 

        private void AccelerationCheck_Checked(object sender, 
            RoutedEventArgs e)
        {
            VelocityPlotter.Visibility = Visibility.Hidden;
            AccelerationPlotter.Visibility = Visibility.Visible;
            TemperaturePlotter.Visibility = Visibility.Hidden;

            AccelerationPlotter.Viewport.FitToView();

            VelocityCheck.IsChecked = false;
            BrakeTemperatureCheck.IsChecked = false;
        } // End of AccelerationCheck_Checked. 

        private void BrakeTemperatureCheck_Checked(object sender, 
            RoutedEventArgs e)
        {
            VelocityPlotter.Visibility = Visibility.Hidden;
            AccelerationPlotter.Visibility = Visibility.Hidden;
            TemperaturePlotter.Visibility = Visibility.Visible;

            TemperaturePlotter.Viewport.FitToView();

            VelocityCheck.IsChecked = false;
            AccelerationCheck.IsChecked = false;
        }
        #endregion

    }   //End of class ResulsPage.

    /// <summary>
    /// Three data fields were declared as type public for simplicity, 
    /// rather than as type private combined with get and set Properties. 
    /// Because Velocity is just data, a C# struct could have been used 
    /// instead of a class. 
    /// </summary>
    public class SimData
    {
        public double Time;
        public double Velocity;
        public double Acceleration;
        public double Temperature;

        public SimData(double Time, double Velocity, double Acceleration, 
            double Temperature)
        {
            this.Time = Time;
            this.Velocity = Velocity;
            this.Acceleration = Acceleration;
            this.Temperature = Temperature;
        }   // End of SimData constructor.
    }   // End of class SimData.

}   // End of namespace Wattsim_02B.