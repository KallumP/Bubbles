namespace Bubbles {
    partial class AnimationWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.ProgramTimer = new System.Windows.Forms.Timer(this.components);
            this.Reset_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgramTimer
            // 
            this.ProgramTimer.Enabled = true;
            this.ProgramTimer.Interval = 17;
            this.ProgramTimer.Tick += new System.EventHandler(this.ProgramTimer_Tick);
            // 
            // Reset_btn
            // 
            this.Reset_btn.Location = new System.Drawing.Point(12, 12);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(75, 23);
            this.Reset_btn.TabIndex = 0;
            this.Reset_btn.Text = "Reset";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reset_btn);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.Text = "Bubbles";
            this.Load += new System.EventHandler(this.AnimationWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationWindow_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimationWindow_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ProgramTimer;
        private System.Windows.Forms.Button Reset_btn;
    }
}

