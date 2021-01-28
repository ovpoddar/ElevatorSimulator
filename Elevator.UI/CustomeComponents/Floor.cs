using System;
using System.Drawing;
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
            Height = _height;
            Up.Enabled = _top;
            Down.Enabled = _bottom;
            Up.Visible = _top;
            Down.Visible = _bottom;
            Up.Name = $"{_name}-Up";
            Down.Name = $"{_name}-Down";
            Name = _name;
        }

        public void Stop() =>
            BackColor = BackColor == SystemColors.ControlDarkDark ? Color.Yellow : SystemColors.ControlDarkDark;
    }
}
