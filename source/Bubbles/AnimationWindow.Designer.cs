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
            this.Switch_btn = new System.Windows.Forms.Button();
            this.mode_lbl = new System.Windows.Forms.Label();
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
            // Switch_btn
            // 
            this.Switch_btn.Location = new System.Drawing.Point(12, 415);
            this.Switch_btn.Name = "Switch_btn";
            this.Switch_btn.Size = new System.Drawing.Size(88, 23);
            this.Switch_btn.TabIndex = 1;
            this.Switch_btn.Text = "Switch Mode";
            this.Switch_btn.UseVisualStyleBackColor = true;
            this.Switch_btn.Click += new System.EventHandler(this.Switch_btn_Click);
            // 
            // mode_lbl
            // 
            this.mode_lbl.AutoSize = true;
            this.mode_lbl.Location = new System.Drawing.Point(13, 396);
            this.mode_lbl.Name = "mode_lbl";
            this.mode_lbl.Size = new System.Drawing.Size(37, 13);
            this.mode_lbl.TabIndex = 2;
            this.mode_lbl.Text = "Mode:";
            // 
            // AnimationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mode_lbl);
            this.Controls.Add(this.Switch_btn);
            this.Controls.Add(this.Reset_btn);
            this.DoubleBuffered = true;
            this.Name = "AnimationWindow";
            this.Text = "Bubbles";
            this.Load += new System.EventHandler(this.AnimationWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationWindow_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimationWindow_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ProgramTimer;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.Button Switch_btn;
        private System.Windows.Forms.Label mode_lbl;
    }
}

