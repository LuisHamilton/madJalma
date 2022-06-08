namespace MazeJalma
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.loreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loreLabel
            // 
            this.loreLabel.BackColor = System.Drawing.Color.Transparent;
            this.loreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loreLabel.ForeColor = System.Drawing.Color.Black;
            this.loreLabel.Location = new System.Drawing.Point(153, 122);
            this.loreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loreLabel.Name = "loreLabel";
            this.loreLabel.Size = new System.Drawing.Size(739, 126);
            this.loreLabel.TabIndex = 1;
            this.loreLabel.Text = ".";
            this.loreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MazeJalma.Properties.Resources.cena;
            this.ClientSize = new System.Drawing.Size(1080, 590);
            this.ControlBox = false;
            this.Controls.Add(this.loreLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loreLabel;
    }
}