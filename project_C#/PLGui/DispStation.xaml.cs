﻿using BO;
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
using System.Windows.Shapes;

namespace PLGui
{
    /// <summary>
    /// Interaction logic for DispStation.xaml
    /// </summary>
    public partial class DispStation : Window
    {
        Station station;
        public DispStation(Station mystation)
        {
            InitializeComponent();
            this.station = mystation;
            DataContext = mystation;
        }
    }
}
