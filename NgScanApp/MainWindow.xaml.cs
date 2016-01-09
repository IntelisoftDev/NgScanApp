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
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NgScanApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string userProfile = Environment.GetEnvironmentVariable("userprofile");
        public string vendor = "";
        public string local_appData = "";
        public string ScannerSettings = "";

        public class scanSettings
        {
            public int colorMode { get; set; }
            public double cropX { get; set; }
            public double cropY { get; set; }
            public double wInch { get; set; }
            public double hInch { get; set; }
            public int dpi { get; set; }
            public int brightness { get; set; }
            public int contrast { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            vendor = versionInfo.CompanyName;
            local_appData = userProfile + "\\AppData\\Roaming\\" + vendor + "\\" + versionInfo.InternalName.Replace(".exe", "") + "\\";
            ScannerSettings = local_appData + "ScannerSettings.settings";
            readSettings();
            getDevices();
            // Check if a scanner is connected
            if (DeviceCmb.Items.Count != 0)
            {
                DeviceCmb.SelectedIndex = 0;
            }
        }

        private void readSettings()
        {
            if (!File.Exists(ScannerSettings))
            {
                scanSettings _scanSettings = new scanSettings();
                _scanSettings.dpi = 300;
                _scanSettings.wInch = 8.50;
                _scanSettings.hInch = 11;
                _scanSettings.cropX = 0;
                _scanSettings.cropY = 0;
                _scanSettings.colorMode = 0;
                if (!Directory.Exists(local_appData))
                {
                    Directory.CreateDirectory(userProfile + "\\AppData\\Roaming\\" + vendor + "\\");
                    Directory.CreateDirectory(local_appData);
                }
                string[] allSettings = {"Color Mode: " + _scanSettings.colorMode, "Brightness: " + _scanSettings.brightness, "Contrast: " + _scanSettings.contrast,
            "DPI: " + _scanSettings.dpi, "Width: " + _scanSettings.wInch, "Height: " + _scanSettings.hInch, "Crop X: " + _scanSettings.cropX,
            "Crop Y: " + _scanSettings.cropY};
                System.IO.File.WriteAllLines(ScannerSettings, allSettings);
            }
            if (File.Exists(ScannerSettings))
            {
                scanSettings _scanSettings = new scanSettings();
                {
                    _scanSettings.colorMode = (int)parseSettings("Color Mode");
                    _scanSettings.brightness = (int)parseSettings("Brightness");
                    _scanSettings.contrast = (int)parseSettings("Contrast");
                    _scanSettings.dpi = (int)parseSettings("DPI");
                    _scanSettings.wInch = parseSettings("Width");
                    _scanSettings.hInch = parseSettings("Height");
                    //_scanSettings.cropX = parseSettings("Crop X");
                   // _scanSettings.cropY = parseSettings("Crop Y");
                    GridR.DataContext = _scanSettings;
                };

            }
        }

        private double parseSettings(string args)
        {
            string[] allSettings = System.IO.File.ReadAllLines(ScannerSettings);
            int aIndex = Array.FindIndex(allSettings, element => element.StartsWith(args, StringComparison.Ordinal));
            double extractedNum = Convert.ToDouble(Decimal.Parse(Regex.Match(allSettings[aIndex], @"\d+.*\d*").Value));

            return extractedNum;
        }

        private void saveSettings()
        {
            scanSettings _scanSettings = new scanSettings();
            _scanSettings.colorMode = colModeCmb.SelectedIndex;
            _scanSettings.brightness = (int)brightSl.Value;
            _scanSettings.contrast = (int)contrastSl.Value;
            
            if (dpiTxt.Text != "")
            {
                _scanSettings.dpi = Convert.ToInt32(dpiTxt.Text);
                _scanSettings.wInch = Convert.ToDouble(widthTxt.Text);
                _scanSettings.hInch = Convert.ToDouble(heightTxt.Text);
                _scanSettings.cropX = Convert.ToDouble(cropxTxt.Text);
                _scanSettings.cropY = Convert.ToDouble(cropyTxt.Text);
            }
            string[] allSettings = {"Color Mode: " + _scanSettings.colorMode, "Brightness: " + _scanSettings.brightness, "Contrast: " + _scanSettings.contrast,
            "DPI: " + _scanSettings.dpi, "Width: " + _scanSettings.wInch, "Height: " + _scanSettings.hInch, "Crop X: " + _scanSettings.cropX,
            "Crop Y: " + _scanSettings.cropY};
            System.IO.File.WriteAllLines(ScannerSettings, allSettings);
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

        public BitmapSource ImgToBmpSource(System.Drawing.Image imageData)
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
        public Bitmap ImgToBmp(System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Bmp);
                Bitmap bi = new Bitmap(ms);
                return bi;
            }
        }
        
        public BitmapSource BmpToBmpSource(Bitmap bmp)
        {
            var bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            var bmpSource = BitmapSource.Create(
                bmpData.Width, bmpData.Height, Convert.ToDouble(dpiTxt.Text), Convert.ToDouble(dpiTxt.Text), PixelFormats.Bgr32, null,
                bmpData.Scan0, bmpData.Stride * bmpData.Height, bmpData.Stride);
            bmp.UnlockBits(bmpData);

            return bmpSource;
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
                scanSettings _scanSettings = new scanSettings();
                MessageBox.Show(Convert.ToInt32(contrastSl.Value).ToString());
                List<System.Drawing.Image> images = null;
                    images = WIAScanner.AutoScan((string)DeviceIdCmb.SelectedItem, Convert.ToInt32(dpiTxt.Text), Convert.ToDouble(cropxTxt.Text), Convert.ToDouble(cropyTxt.Text),
                    ((Convert.ToDouble(widthTxt.Text) * Convert.ToDouble(dpiTxt.Text)) + Convert.ToDouble(cropxTxt.Text)), ((Convert.ToDouble(heightTxt.Text) * Convert.ToDouble(dpiTxt.Text)) + Convert.ToDouble(cropyTxt.Text)), (int)brightSl.Value,
                    (int)contrastSl.Value, colModeCmb.SelectedIndex);
                foreach (System.Drawing.Image image in images)
                {
                    //ScanView.Source = convImage((System.Drawing.Image)_deskew.DeskewImage((Bitmap)image));
                    ScanView.Source = setPixelFormat(ImgToBmpSource(image), PixelFormats.BlackWhite);
                    encoder.Frames.Add(BitmapFrame.Create(setPixelFormat(ImgToBmpSource(image), PixelFormats.BlackWhite)));
                    Random rnd = new Random();
                    using (var stream = new FileStream(userProfile + "\\Pictures\\" + "image2.tif", FileMode.Create, FileAccess.Write))
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
