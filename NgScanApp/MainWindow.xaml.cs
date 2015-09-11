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

namespace NgScanApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getDevices();
        }
        private void getDevices()
        {
            try
            {
                List<string> devices = WIAScanner.GetDevices();

                foreach(string device in devices)
                {
                    DeviceCmb.Items.Add(device);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ScanBtn_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
