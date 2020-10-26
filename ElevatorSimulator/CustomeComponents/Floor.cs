using System;
using System.Windows.Forms;

namespace ElevatorSimulator.CustomeComponents
{
    public partial class Floor : UserControl
    {
        private readonly int _height;
        private readonly bool _top;
        private readonly bool _bottom;

        public Floor(int height, bool Top, bool Bottom)
        {
            InitializeComponent();
            _height = height;
            _top = Top;
            _bottom = Bottom;
        }

        private void Floor_Load(object sender, EventArgs e)
        {
            this.Height = _height;
            this.Up.Enabled = _top;
            this.Down.Enabled = _bottom;
            this.Up.Visible = _top;
            this.Down.Visible = _bottom;
        }
    }
}
