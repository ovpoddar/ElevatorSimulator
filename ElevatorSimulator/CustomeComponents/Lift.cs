using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSimulator.CustomeComponents
{
    public partial class Lift : UserControl
    {
        private readonly int _height;

        public Lift(int height)
        {
            _height = height;
            InitializeComponent();
        }
        

        public void updatepos(int floor)
        {
            this.Top = floor * _height;
        }
    }
}
