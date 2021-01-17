namespace Elevator.UI
{
    partial class Elevator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LiftInside = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn0 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DynamicFloorHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.BottomFloorHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.TopFloorHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.LiftInside.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LiftInside);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 517);
            this.panel1.TabIndex = 0;
            // 
            // LiftInside
            // 
            this.LiftInside.Controls.Add(this.Btn0);
            this.LiftInside.Controls.Add(this.Btn1);
            this.LiftInside.Controls.Add(this.Btn2);
            this.LiftInside.Controls.Add(this.Btn3);
            this.LiftInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiftInside.Location = new System.Drawing.Point(0, 0);
            this.LiftInside.Name = "LiftInside";
            this.LiftInside.Size = new System.Drawing.Size(108, 517);
            this.LiftInside.TabIndex = 0;
            // 
            // Btn0
            // 
            this.Btn0.Location = new System.Drawing.Point(3, 3);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(75, 23);
            this.Btn0.TabIndex = 0;
            this.Btn0.Text = "0";
            this.Btn0.UseVisualStyleBackColor = true;
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(3, 32);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 23);
            this.Btn1.TabIndex = 0;
            this.Btn1.Text = "1";
            this.Btn1.UseVisualStyleBackColor = true;
            // 
            // Btn2
            // 
            this.Btn2.Location = new System.Drawing.Point(3, 61);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(75, 23);
            this.Btn2.TabIndex = 0;
            this.Btn2.Text = "2";
            this.Btn2.UseVisualStyleBackColor = true;
            // 
            // Btn3
            // 
            this.Btn3.Location = new System.Drawing.Point(3, 90);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(75, 23);
            this.Btn3.TabIndex = 0;
            this.Btn3.Text = "3";
            this.Btn3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(108, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 517);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DynamicFloorHolder);
            this.panel3.Controls.Add(this.BottomFloorHolder);
            this.panel3.Controls.Add(this.TopFloorHolder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(262, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 517);
            this.panel3.TabIndex = 2;
            // 
            // DynamicFloorHolder
            // 
            this.DynamicFloorHolder.BackColor = System.Drawing.SystemColors.Control;
            this.DynamicFloorHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DynamicFloorHolder.Location = new System.Drawing.Point(0, 75);
            this.DynamicFloorHolder.Name = "DynamicFloorHolder";
            this.DynamicFloorHolder.Size = new System.Drawing.Size(136, 375);
            this.DynamicFloorHolder.TabIndex = 2;
            // 
            // BottomFloorHolder
            // 
            this.BottomFloorHolder.BackColor = System.Drawing.SystemColors.Control;
            this.BottomFloorHolder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomFloorHolder.Location = new System.Drawing.Point(0, 450);
            this.BottomFloorHolder.Name = "BottomFloorHolder";
            this.BottomFloorHolder.Size = new System.Drawing.Size(136, 67);
            this.BottomFloorHolder.TabIndex = 1;
            // 
            // TopFloorHolder
            // 
            this.TopFloorHolder.BackColor = System.Drawing.SystemColors.Control;
            this.TopFloorHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopFloorHolder.Location = new System.Drawing.Point(0, 0);
            this.TopFloorHolder.Name = "TopFloorHolder";
            this.TopFloorHolder.Size = new System.Drawing.Size(136, 75);
            this.TopFloorHolder.TabIndex = 0;
            // 
            // Elevator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 517);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(414, 556);
            this.MinimumSize = new System.Drawing.Size(414, 556);
            this.Name = "Elevator";
            this.Text = "Elevator";
            this.panel1.ResumeLayout(false);
            this.LiftInside.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel LiftInside;
        private System.Windows.Forms.FlowLayoutPanel DynamicFloorHolder;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn0;
        private System.Windows.Forms.FlowLayoutPanel TopFloorHolder;
        private System.Windows.Forms.FlowLayoutPanel BottomFloorHolder;
    }
}