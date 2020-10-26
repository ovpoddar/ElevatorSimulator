using ElevatorSimulator.CustomeComponents;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ElevatorSimulator
{
    public partial class Elevator : Form
    {
        private Lift _lift;
        public Elevator()
        {
            InitializeComponent();
            InitializeDynamicComponent();
            InitializeLift();
            InitializeMethods();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var floor = Convert.ToInt32(button.Text);
            _lift.GoTo(floor);
        }

        private void Elevator_Load(object sender, EventArgs e)
        {
        }


        #region ugly methods
        private void InitializeMethods()
        {
            foreach (var button in LiftInside.Controls.OfType<Button>())
                button.Click += Btn_Click;
        }

        private void InitializeDynamicComponent()
        {
            var totalHeight = panel3.Height;
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = totalHeight / totalButtons;
            for (int i = 0; i < totalButtons - 2; i++)
                DynamicFloorHolder.Controls.Add(new Floor(height, true, true));
            DynamicFloorHolder.Height = height * (totalButtons - 2);
            TopFloorHolder.Controls.Add(new Floor(height, true, false));
            TopFloorHolder.Height = height;
            BottomFloorHolder.Controls.Add(new Floor(height, false, true));
            BottomFloorHolder.Height = height;
        }

        private void InitializeLift()
        {
            var totalHeight = panel3.Height;
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = totalHeight / totalButtons;
            _lift = new Lift(height);
            panel2.Controls.Add(_lift);

            _lift.updatepos(totalButtons - 1);
        }
        #endregion
    }
}
