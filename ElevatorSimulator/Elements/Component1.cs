using System.ComponentModel;

namespace ElevatorSimulator.Elements
{
    public partial class Component1 : Component
    {
        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(new Elevator());

            InitializeComponent();
        }
    }
}
