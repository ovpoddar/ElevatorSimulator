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
        private readonly int _height;

        public Lift(int height)
        {
            InitializeComponent();
            this._height = height;
            this.Height = _height;
        }
        public void updatepos(int floor)
        {
            this.Top = floor * _height;
        }
    }
}
