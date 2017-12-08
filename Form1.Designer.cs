namespace BrickGame
{
    partial class Form1
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
            this.Window = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Window)).BeginInit();
            this.SuspendLayout();
            // 
            // Window
            // 
            this.Window.BackColor = System.Drawing.Color.Navy;
            this.Window.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Window.Location = new System.Drawing.Point(0, 0);
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(519, 342);
            this.Window.TabIndex = 0;
            this.Window.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 342);
            this.Controls.Add(this.Window);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brick Game - Shiva Bhardwaj";
            ((System.ComponentModel.ISupportInitialize)(this.Window)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Window;
    }
}

