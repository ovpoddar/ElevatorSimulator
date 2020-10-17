using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ElevatorSimulator.CustomeComponents
{
    public partial class Lift : UserControl
    {
        public Lift()
        {
            InitializeComponent();
        }
        public void updatepos(int floor)
        {
            this.Top = floor * 50;
        }
    }
}
