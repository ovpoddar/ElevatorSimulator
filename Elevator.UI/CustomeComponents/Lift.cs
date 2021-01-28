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
            Height = _height;
        }

        public void UpdatePosition(int floor)
        {
            try
            {
                Top = floor * _height;
            }
            catch
            {
                Invoke((Action)delegate
                {
                    Top = floor * _height;
                });
            }
        }
    }
}
