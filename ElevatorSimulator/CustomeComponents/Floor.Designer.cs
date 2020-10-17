namespace ElevatorSimulator.CustomeComponents
{
    partial class Floor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Up = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Up
            // 
            this.Up.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Up.Location = new System.Drawing.Point(1, 64);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(61, 23);
            this.Up.TabIndex = 0;
            this.Up.Text = "Up";
            this.Up.UseVisualStyleBackColor = true;
            // 
            // Down
            // 
            this.Down.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Down.Location = new System.Drawing.Point(68, 64);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(61, 23);
            this.Down.TabIndex = 0;
            this.Down.Text = "Down";
            this.Down.UseVisualStyleBackColor = true;
            // 
            // Floor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Name = "Floor";
            this.Size = new System.Drawing.Size(131, 150);
            this.Load += new System.EventHandler(this.Floor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
    }
}
