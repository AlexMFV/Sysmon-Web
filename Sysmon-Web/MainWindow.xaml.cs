using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HardwareProviders.CPU;
using HardwareProviders;
using OpenHardwareMonitor.Hardware;
using HardwareProviders.HDD;

namespace Sysmon_Web
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 1000;
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //TemperatureReader temps = new TemperatureReader();
            //IReadOnlyDictionary<string, float> readings = temps.GetTemperaturesInCelsius();
            //string test = readings.TryGetValue("");

            Visitor visitor = new Visitor();
            IReadOnlyDictionary<string, float?> readings = visitor.GetSystemInfo();

            lblTemp.Content = "";
            foreach (var dic in readings)
            {
                lblTemp.Content += $"{dic.Key} - {dic.Value} \n";
            }
            
            //t.Stop();
        }
    }
}
