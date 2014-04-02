using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WattSim_03A.Views
{
    /// <summary>
    /// Interaction logic for SimulationPage.xaml
    /// </summary>
    public partial class SimulationPage : Page
    {
        public SimulationPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.SimulationViewModel();
        }

        private void GoToCarSetup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarSetupPage());
        }

        private void GoToBrakeSetup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BrakeSetupPage());
        }

        private void GoToResultsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarResultsPage());
        }

        private void GoToLiveResultsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LiveResults());
        }
    }
}
