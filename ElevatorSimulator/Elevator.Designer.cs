using System.Windows.Forms;

namespace ElevatorSimulator
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
            this.Inside = new System.Windows.Forms.Panel();
            this.InsideControls = new System.Windows.Forms.FlowLayoutPanel();
            this.Floors = new System.Windows.Forms.Panel();
            this.Lift = new System.Windows.Forms.Panel();
            this.BtnP = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn4 = new System.Windows.Forms.Button();
            this.Btn5 = new System.Windows.Forms.Button();
            this.Inside.SuspendLayout();
            this.InsideControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // Inside
            // 
            this.Inside.Controls.Add(this.InsideControls);
            this.Inside.Dock = System.Windows.Forms.DockStyle.Left;
            this.Inside.Location = new System.Drawing.Point(0, 0);
            this.Inside.Name = "Inside";
            this.Inside.Size = new System.Drawing.Size(124, 536);
            this.Inside.TabIndex = 0;
            // 
            // InsideControls
            // 
            this.InsideControls.Controls.Add(this.Btn5);
            this.InsideControls.Controls.Add(this.Btn4);
            this.InsideControls.Controls.Add(this.Btn3);
            this.InsideControls.Controls.Add(this.Btn1);
            this.InsideControls.Controls.Add(this.BtnP);
            this.InsideControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsideControls.Location = new System.Drawing.Point(0, 0);
            this.InsideControls.Name = "InsideControls";
            this.InsideControls.Size = new System.Drawing.Size(124, 379);
            this.InsideControls.TabIndex = 0;
            // 
            // Floors
            // 
            this.Floors.Dock = System.Windows.Forms.DockStyle.Right;
            this.Floors.Location = new System.Drawing.Point(336, 0);
            this.Floors.Name = "Floors";
            this.Floors.Size = new System.Drawing.Size(131, 536);
            this.Floors.TabIndex = 1;
            // 
            // Lift
            // 
            this.Lift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lift.Location = new System.Drawing.Point(124, 0);
            this.Lift.Name = "Lift";
            this.Lift.Size = new System.Drawing.Size(212, 536);
            this.Lift.TabIndex = 2;
            // 
            // button1
            // 
            this.BtnP.Location = new System.Drawing.Point(3, 119);
            this.BtnP.Name = "button1";
            this.BtnP.Size = new System.Drawing.Size(75, 23);
            this.BtnP.TabIndex = 0;
            this.BtnP.Text = "button1";
            this.BtnP.UseVisualStyleBackColor = true;
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(3, 90);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 23);
            this.Btn1.TabIndex = 0;
            this.Btn1.Text = "Btn1";
            this.Btn1.UseVisualStyleBackColor = true;
            // 
            // Btn3
            // 
            this.Btn3.Location = new System.Drawing.Point(3, 61);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(75, 23);
            this.Btn3.TabIndex = 0;
            this.Btn3.Text = "Btn2";
            this.Btn3.UseVisualStyleBackColor = true;
            // 
            // Btn4
            // 
            this.Btn4.Location = new System.Drawing.Point(3, 32);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(75, 23);
            this.Btn4.TabIndex = 0;
            this.Btn4.Text = "button4";
            this.Btn4.UseVisualStyleBackColor = true;
            // 
            // Btn5
            // 
            this.Btn5.Location = new System.Drawing.Point(3, 3);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(75, 23);
            this.Btn5.TabIndex = 0;
            this.Btn5.Text = "button5";
            this.Btn5.UseVisualStyleBackColor = true;
            // 
            // Elevator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 536);
            this.Controls.Add(this.Lift);
            this.Controls.Add(this.Floors);
            this.Controls.Add(this.Inside);
            this.Name = "Elevator";
            this.Text = "Elevator";
            this.Inside.ResumeLayout(false);
            this.InsideControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Lift;
        private System.Windows.Forms.Panel Floors;
        private System.Windows.Forms.Panel Inside;
        private System.Windows.Forms.FlowLayoutPanel InsideControls;
        private System.Windows.Forms.Button Btn5;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button BtnP;
        private System.Windows.Forms.Button Btn3;
    }
}