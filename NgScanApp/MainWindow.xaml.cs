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
using WIA;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Win32;

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
        public string fileName = "";
        bool CropToolReady = false;
        private TranslateTransform transform = new TranslateTransform();
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
        private void saveImageAsFile(System.Drawing.Image img)
        {
            var encoder = new TiffBitmapEncoder();
            encoder.Compression = TiffCompressOption.Ccitt4;
            encoder.Frames.Add(BitmapFrame.Create(ImageProc.setPixelFormat(ImageProc.ImgToBmpSource(img), PixelFormats.BlackWhite)));

            using (var stream = new FileStream(savePathTxt.Text, FileMode.Create, FileAccess.Write))
            {
                encoder.Save(stream);
            }
        }
        private void ScanBtnClicked(object sender, RoutedEventArgs e)
        {
            InitScan();
            CropToolReady = false;
        }
        public void InitScan()
        {
            ImageProc imgP = new ImageProc();
            CommonDialogClass commonDialogClass = new CommonDialogClass();
            DeviceIdCmb.SelectedIndex = DeviceCmb.SelectedIndex;
            try
            {
                if (DeviceCmb.Items.Count == 0)
                {
                    MessageBox.Show("Please connect a scanner.");
                }
                Deskew _deskew = new Deskew();

                scanSettings _scanSettings = new scanSettings();
                List<System.Drawing.Image> images = null;
                images = WIAScanner.AutoScan((string)DeviceIdCmb.SelectedItem, Convert.ToInt32(dpiTxt.Text), (Convert.ToDouble(cropxTxt.Text)), (Convert.ToDouble(cropyTxt.Text)),
                (Convert.ToDouble(widthTxt.Text) * Convert.ToDouble(dpiTxt.Text)), (Convert.ToDouble(heightTxt.Text) * Convert.ToDouble(dpiTxt.Text)), (int)brightSl.Value,
                (int)contrastSl.Value, colModeCmb.SelectedIndex);
                selRect.Visibility = Visibility.Collapsed;
                foreach (System.Drawing.Image image in images)
                {
                    ScanView.Source = ImageProc.setPixelFormat(ImageProc.ImgToBmpSource(image), PixelFormats.BlackWhite);
                    saveImageAsFile(image);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void previewBtnClicked(object sender, RoutedEventArgs e)
        {
            previewScan();
            selRect.Visibility = Visibility.Visible;
            CropToolReady = true;
        }
        private void previewScan()
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
                    //ScanView.Source = ImgToBmpSource(img);
                    /*Bitmap bmp = new Bitmap(img);
                    Grayscale gs_fil = new Grayscale(0.2125, 0.7154, 0.0721);
                    Bitmap gs_Bmp = gs_fil.Apply(bmp);
                    DocumentSkewChecker skewCheck = new DocumentSkewChecker();
                    double angle = skewCheck.GetSkewAngle(gs_Bmp);
                    RotateBilinear rotateFilter = new RotateBilinear(-angle);
                    rotateFilter.FillColor = System.Drawing.Color.White;
                    Bitmap rotatedImage = rotateFilter.Apply(gs_Bmp);
                    new ContrastStretch().ApplyInPlace(gs_Bmp);
                    new Threshold(180).ApplyInPlace(gs_Bmp);
                    //new Invert().ApplyInPlace(gs_Bmp);
                    BlobCounter bc = new BlobCounter();

                    bc.FilterBlobs = true;
                    bc.ProcessImage(gs_Bmp);
                    System.Drawing.Rectangle[] rects = bc.GetObjectsRectangles();*/
                    ScanView.Source = ImageProc.ImgToBmpSource(img);
                    //gs_Bmp.Save(userProfile + "\\Pictures\\TreshSample1.png", ImageFormat.Png);
                    /* foreach (System.Drawing.Rectangle rect in rects)
                     {
                         cropxTxt.Text = (rect.Left).ToString();
                         cropyTxt.Text = (rect.Top / 5).ToString();
                         heightTxt.Text = (rect.Bottom).ToString();
                         widthTxt.Text = (rect.Right / 45).ToString();
                     }*/
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

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();

            saveDlg.InitialDirectory = userProfile + "\\Pictures\\";
            saveDlg.Filter = "JPEG files (*.jpeg; *.jpg)|*.jpeg; *.jpg|PNG files (*.png)|*.png|TIFF files (*.tif; *.tiff)|*.tif; *.tiff|All files (*.*)|*.*";
            saveDlg.FilterIndex = 4;
            saveDlg.RestoreDirectory = true;

            if (saveDlg.ShowDialog() == true)
            {
                savePathTxt.Text = saveDlg.FileName;
            }
        }
        // Selection Control
        AdornerLayer aLayer;

        bool _isDown;
        bool _isDragging;
        bool selected = false;
        UIElement selectedElement = null;

        System.Windows.Point _startPoint;
        private double _originalLeft;
        private double _originalTop;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Window1_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
            this.MouseMove += new MouseEventHandler(Window1_MouseMove);
            this.MouseLeave += new MouseEventHandler(Window1_MouseLeave);

            CanvasL.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(myCanvas_PreviewMouseLeftButtonDown);
            CanvasL.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(DragFinishedMouseHandler);
        }

        // Handler for drag stopping on leaving the window
        void Window1_MouseLeave(object sender, MouseEventArgs e)
        {
            StopDragging();
            e.Handled = true;
        }

        // Handler for drag stopping on user choise
        void DragFinishedMouseHandler(object sender, MouseButtonEventArgs e)
        {
            StopDragging();
            e.Handled = true;
        }

        // Method for stopping dragging
        private void StopDragging()
        {
            if (_isDown)
            {
                _isDown = false;
                _isDragging = false;
            }
        }

        // Hanler for providing drag operation with selected element
        void Window1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(CanvasL).X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(CanvasL).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                    _isDragging = true;

                if (_isDragging)
                {
                    System.Windows.Point position = Mouse.GetPosition(CanvasL);
                    Canvas.SetTop(selectedElement, position.Y - (_startPoint.Y - _originalTop));
                    Canvas.SetLeft(selectedElement, position.X - (_startPoint.X - _originalLeft));
                }
            }
        }

        // Handler for clearing element selection, adorner removal
        void Window1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selected)
            {
                selected = false;
                if (selectedElement != null)
                {
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
            }
        }

        // Handler for element selection on the canvas providing resizing adorner
        void myCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Remove selection on clicking anywhere the window
            if (selected)
            {
                selected = false;
                if (selectedElement != null)
                {
                    // Remove the adorner from the selected element
                    aLayer.Remove(aLayer.GetAdorners(selectedElement)[0]);
                    selectedElement = null;
                }
            }

            // If any element except canvas is clicked, 
            // assign the selected element and add the adorner
            if (e.Source != CanvasL)
            {
                _isDown = true;
                _startPoint = e.GetPosition(CanvasL);

                selectedElement = e.Source as UIElement;

                _originalLeft = Canvas.GetLeft(selectedElement);
                _originalTop = Canvas.GetTop(selectedElement);

                aLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                aLayer.Add(new ResizingAdorner(selectedElement));
                selected = true;
                e.Handled = true;
            }
        }

        private void getCropVal()
        {
            widthTxt.Text = Math.Round(((selRect.Width) / 18.23), 2).ToString();
            cropxTxt.Text = Math.Round(((Canvas.GetLeft(selRect)) * 15), 2).ToString();
            cropyTxt.Text = Math.Round(((Canvas.GetTop(selRect)) / 19), 2).ToString();
            heightTxt.Text = Math.Round(((Canvas.GetTop(selRect) + selRect.Height) / 19), 2).ToString();
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(CanvasL);
            posLbn.Content = "X: " + mousePosition.X + " Y: " + mousePosition.Y;
        }

        private void RectSizeChange(object sender, SizeChangedEventArgs e)
        {
            if (CropToolReady == true)
            {
                getCropVal();
            }
        }

        private void rotL_Click(object sender, RoutedEventArgs e)
        {
            var img = System.Drawing.Image.FromFile(savePathTxt.Text);
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            ScanView.Source = ImageProc.ImgToBmpSource(img);
            saveImageAsFile(img);
        }

        private void rotR_Click(object sender, RoutedEventArgs e)
        {
            var img = System.Drawing.Image.FromFile(savePathTxt.Text);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ScanView.Source = ImageProc.ImgToBmpSource(img);
            saveImageAsFile(img);
        }
    }
}
