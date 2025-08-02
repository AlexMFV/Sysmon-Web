using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sysmon_WebForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Timer timers = new System.Threading.Timer();
            timer.Interval = 1000;
            timer.Start();
        }
    }
}
