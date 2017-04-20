namespace Cyclotron
{
    partial class MainForm
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
            this.panelCyclotron = new Cyclotron.PanelDB();
            this.SuspendLayout();
            // 
            // panelCyclotron
            // 
            this.panelCyclotron.BackColor = System.Drawing.Color.Black;
            this.panelCyclotron.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCyclotron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCyclotron.Location = new System.Drawing.Point(0, 0);
            this.panelCyclotron.Name = "panelCyclotron";
            this.panelCyclotron.Size = new System.Drawing.Size(1575, 1218);
            this.panelCyclotron.TabIndex = 0;
            this.panelCyclotron.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCyclotron_Paint);
            this.panelCyclotron.Resize += new System.EventHandler(this.panelCyclotron_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1575, 1218);
            this.Controls.Add(this.panelCyclotron);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cyclotron";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelDB panelCyclotron;
    }
}

