﻿using System;
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
using System.Windows.Shapes;

namespace NgScanApp
{
    /// <summary>
    /// Interaction logic for DevSettings.xaml
    /// </summary>
    public partial class DevSettings : Window
    {
        public DevSettings()
        {
            InitializeComponent();
        }

        private void concelBtnClicked(object sender, RoutedEventArgs e)
        {
            DevSettings m_devSettings = new DevSettings();
            m_devSettings.Close();
        }
    }
}
