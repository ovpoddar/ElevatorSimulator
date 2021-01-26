using System;
using System.Windows.Forms;

namespace Elevator.UI.CustomeComponents
{
    public partial class Lift : UserControl
    {
        private readonly int _height;

        public Lift(int height)
        {
            _height = height;
            InitializeComponent();
            this.Height = _height;
        }

        public void Updatepos(int floor)
        {
            try
            {
                this.Top = floor * _height;
            }
            catch
            {
                Invoke((Action)delegate
                {
                    this.Top = floor * _height;
                });
            }
        }
    }
}
