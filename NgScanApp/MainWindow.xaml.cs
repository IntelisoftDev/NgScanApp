using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using AForge;
using AForge.Imaging;
using AForge.Math;
using WIA;

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

            // Check if a scanner is connected
            if(DeviceCmb.Items.Count != 0)
            {
                DeviceCmb.SelectedIndex = 0;
            }
        }
        static String userProfile = Environment.GetEnvironmentVariable("userprofile");
        private void getDevices()
        {
            try
            {
                List<string> devices = WIAScanner.GetDevices();
                List<string> deviceIds = WIAScanner.GetDevicesId();

                foreach (string deviceId in deviceIds)
                {
                    DeviceIdCmb.Items.Add(deviceId);
                }
                foreach (string device in devices)
                {
                    DeviceCmb.Items.Add(device);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        BitmapSource convImage(System.Drawing.Image imageData)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageData.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bI = new BitmapImage();
                bI.BeginInit();
                bI.CacheOption = BitmapCacheOption.OnLoad;
                bI.StreamSource = ms;
                bI.EndInit();
                return bI;
            }
        }

        private void onSettingsCliked(object sender, RoutedEventArgs e)
        {
            DevSettings m_devSettings = new DevSettings();
            m_devSettings.Show();
        }

        private void ScanBtnClicked(object sender, RoutedEventArgs e)
        {
            InitScan();
        }
        public void InitScan()
        {
            CommonDialogClass commonDialogClass = new CommonDialogClass();
            DeviceIdCmb.SelectedIndex = DeviceCmb.SelectedIndex;
            try
            {
                if (DeviceCmb.Items.Count == 0)
                {
                    MessageBox.Show("Please connect a scanner.");
                }
                Deskew _deskew = new Deskew();
                var encoder = new TiffBitmapEncoder();
                encoder.Compression = TiffCompressOption.Ccitt4;
                float cropX = 1500.00f;
                float cropY = 1000.00f;
                float wInch = 25f;
                float hInch = 30f;
                int dpi = 300;
                int brightness = 0;
                int contrast = 260;
                
                List<System.Drawing.Image> images = WIAScanner.preScan((string)DeviceIdCmb.SelectedItem);
                //List<System.Drawing.Image> images = WIAScanner.AutoScan((string)DeviceIdCmb.SelectedItem, dpi, (int)cropX, (int)cropY, (int)((wInch * dpi) + cropX), (int)((hInch * dpi) + cropY), brightness, contrast, 1);
                foreach (System.Drawing.Image image in images)
                {
                    ScanView.Source = convImage((System.Drawing.Image)_deskew.DeskewImage((Bitmap)image));
                    //ScanView.Source = convImage(image);
                   /* encoder.Frames.Add(BitmapFrame.Create(convImage(image)));
                    using (var stream = new FileStream(userProfile + "\\Pictures\\" + "image2.tif" , FileMode.Create, FileAccess.Write))
                    {
                        encoder.Save(stream);
                    }*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
