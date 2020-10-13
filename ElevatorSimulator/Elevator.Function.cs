using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ElevatorSimulator
{
    partial class Elevator
    {
        private void InitializeFunction()
        {
            var follrButtons = InsideControls.Controls;
            foreach (var button in follrButtons)
            {
                var btn = (Button)button;
                btn.Click += Btn_Click;
            }
        }
    }
}
