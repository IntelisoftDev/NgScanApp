using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NgScanApp
{
    /// <summary>
    /// Interaction logic for SettingsDlg.xaml
    /// </summary>
    public partial class SettingsDlg : Window
    {
        static string userProfile = Environment.GetEnvironmentVariable("userprofile");
        private string vendor = "";
        private string local_appData = "";
        public string ScannerSettings = "";
        public SettingsDlg()
        {
            InitializeComponent();
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            vendor = versionInfo.CompanyName;
            local_appData = userProfile + "\\AppData\\Roaming\\" + vendor + "\\" + versionInfo.InternalName.Replace(".exe", "") + "\\";
            ScannerSettings = local_appData + "ScannerSettings.settings";
            readSettings();
        }
        public class scanSettings
        {
            public int brightness { get; set; }
            public int colorMode { get; set; }
            public int contrast { get; set; }
            public double cropX { get; set; }
            public double cropY { get; set; }
            public int dpi { get; set; }
            public double hInch { get; set; }
            public double wInch { get; set; }
        }

        private void readSettings()
        {
            scanSettings _scanSettings = new scanSettings();
            string[] allSettings = {"Color Mode: " + _scanSettings.colorMode, "Brightness: " + _scanSettings.brightness, "Contrast: " + _scanSettings.contrast,
            "DPI: " + _scanSettings.dpi, "Width: " + _scanSettings.wInch, "Height: " + _scanSettings.hInch, "Crop X: " + _scanSettings.cropX,
            "Crop Y: " + _scanSettings.cropY};
            System.IO.File.WriteAllLines(ScannerSettings, allSettings);

            if (File.Exists(ScannerSettings))
            {
                //scanSettings _scanSettings = new scanSettings();
                {
                    _scanSettings.colorMode = (int)parseSettings("Color Mode");
                    _scanSettings.brightness = (int)parseSettings("Brightness");
                    _scanSettings.contrast = (int)parseSettings("Contrast");
                    _scanSettings.dpi = (int)parseSettings("DPI");
                    settingsGrid.DataContext = _scanSettings;
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

            _scanSettings.dpi = (int)parseSettings("DPI");
            string[] allSettings = {"Color Mode: " + _scanSettings.colorMode, "Brightness: " + _scanSettings.brightness, "Contrast: " + _scanSettings.contrast,
            "DPI: " + _scanSettings.dpi};
            System.IO.File.WriteAllLines(ScannerSettings, allSettings);
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            saveSettings();
            this.Close();
        }
    }
}
