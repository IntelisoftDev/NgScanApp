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
using System.Runtime.InteropServices;

namespace NgScanApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String userProfile = Environment.GetEnvironmentVariable("userprofile");
        string ScannerSettings = Environment.CurrentDirectory + "\\ScannerSettings.settings";

        public class scanSettings
        {
            public int colorMode { get; set; }
            public float cropX { get; set; }
            public float cropY { get; set; }
            public float wInch { get; set; }
            public float hInch { get; set; }
            public int dpi { get; set; }
            public int brightness { get; set; }
            public int contrast { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();
            readSettings();
            //
            getDevices();

            // Check if a scanner is connected
            if (DeviceCmb.Items.Count != 0)
            {
                DeviceCmb.SelectedIndex = 0;
            }
        }

        private void readSettings()
        {
            //if (File.Exists(ScannerSettings))
            // {
            // string[] allSettings = System.IO.File.ReadAllLines(ScannerSettings);

            scanSettings _scanSettings = new scanSettings();
            {
                _scanSettings.contrast = 150;
            };
            propList.DataContext = _scanSettings;

            //  }
        }

        private void saveSettings()
        {
            scanSettings _scanSettings = new scanSettings();
            string[] allSettings = {"Color Mode: " + _scanSettings.colorMode, "Brightness: " + _scanSettings.brightness, "Contrast: " + _scanSettings.contrast,
            "DPI: " + _scanSettings.dpi, "Width: " + _scanSettings.wInch, "Height: " + _scanSettings.hInch, "Crop X: " + _scanSettings.cropX,
            "Crop Y: " + _scanSettings.cropY};
            System.IO.File.WriteAllLines(Environment.CurrentDirectory + "\\ScannerSettings.settings", allSettings);
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        BitmapSource ImgToBmpSource(System.Drawing.Image imageData)
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
        Bitmap ImgToBmp(System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Bmp);
                Bitmap bi = new Bitmap(ms);
                return bi;
            }
        }

        /* private void onSettingsCliked(object sender, RoutedEventArgs e)
         {
             DevSettings m_devSettings = new DevSettings();
             m_devSettings.Show();
         }*/

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
                scanSettings _scanSettings = new scanSettings();

                List<System.Drawing.Image> images = WIAScanner.AutoScan((string)DeviceIdCmb.SelectedItem, _scanSettings.dpi, (int)_scanSettings.cropX, (int)_scanSettings.cropY,
                    (int)((_scanSettings.wInch * _scanSettings.dpi) + _scanSettings.cropX), (int)((_scanSettings.hInch * _scanSettings.dpi) + _scanSettings.cropY), _scanSettings.brightness,
                    _scanSettings.contrast, 1);
                foreach (System.Drawing.Image image in images)
                {
                    //ScanView.Source = convImage((System.Drawing.Image)_deskew.DeskewImage((Bitmap)image));
                    ScanView.Source = setPixelFormat(ImgToBmpSource(image), PixelFormats.BlackWhite);
                    // encoder.Frames.Add(BitmapFrame.Create(BitmapTo1Bpp(ImgToBmp(image))));
                    Random rnd = new Random();
                    using (var stream = new FileStream(userProfile + "\\Pictures\\" + "image" + rnd.Next(1, 12) + ".tif", FileMode.Create, FileAccess.Write))
                    {
                        encoder.Save(stream);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static BitmapSource setPixelFormat(BitmapSource image, System.Windows.Media.PixelFormat format)
        {
            var formatted = new FormatConvertedBitmap();

            formatted.BeginInit();
            formatted.Source = image;
            formatted.DestinationFormat = format;
            formatted.EndInit();
            return formatted;
        }
        public static Bitmap BitmapTo1Bpp(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            byte[] scan = new byte[(w + 7) / 8];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (x % 8 == 0) scan[x / 8] = 0;
                    System.Drawing.Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                Marshal.Copy(scan, 0, (IntPtr)((long)data.Scan0 + data.Stride * y), scan.Length);
            }
            bmp.UnlockBits(data);
            return bmp;
        }

        private void previewBtnClicked(object sender, RoutedEventArgs e)
        {
            CommonDialogClass commonDialogClass = new CommonDialogClass();
            DeviceIdCmb.SelectedIndex = DeviceCmb.SelectedIndex;
            try
            {
                if (DeviceCmb.Items.Count == 0)
                {
                    MessageBox.Show("Please connect a scanner.");
                }
                List<System.Drawing.Image> images = WIAScanner.preScan((string)DeviceIdCmb.SelectedItem);
                foreach (System.Drawing.Image img in images)
                {
                    ScanView.Source = ImgToBmpSource(img);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            saveSettings();
        }
    }
}
