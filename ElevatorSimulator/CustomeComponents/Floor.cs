using System;
using System.Windows.Forms;

namespace Elevator.UI.CustomeComponents
{
    public partial class Floor : UserControl
    {
        private readonly int _height;
        private readonly bool _top;
        private readonly bool _bottom;
        private readonly string _name;

        public Floor(int height, bool Top, bool Bottom, string name)
        {
            InitializeComponent();
            _height = height;
            _top = Top;
            _bottom = Bottom;
            _name = name;
        }

        private void Floor_Load(object sender, EventArgs e)
        {
            this.Height = _height;
            this.Up.Enabled = _top;
            this.Down.Enabled = _bottom;
            this.Up.Visible = _top;
            this.Down.Visible = _bottom;
            this.Up.Name = $"{_name}-Up";
            this.Down.Name = $"{_name}-Down";
        }
    }
}
