namespace Bubbles {
    partial class MainWindow {
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
            this.vectorDebug = new System.Windows.Forms.Button();
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
            this.Reset_btn.Enabled = false;
            this.Reset_btn.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_btn.Location = new System.Drawing.Point(12, 12);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(75, 33);
            this.Reset_btn.TabIndex = 0;
            this.Reset_btn.Text = "Reset";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // Switch_btn
            // 
            this.Switch_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Switch_btn.Enabled = false;
            this.Switch_btn.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Switch_btn.Location = new System.Drawing.Point(12, 406);
            this.Switch_btn.Name = "Switch_btn";
            this.Switch_btn.Size = new System.Drawing.Size(88, 32);
            this.Switch_btn.TabIndex = 1;
            this.Switch_btn.Text = "Switch Mode";
            this.Switch_btn.UseVisualStyleBackColor = true;
            this.Switch_btn.Click += new System.EventHandler(this.Switch_btn_Click);
            // 
            // mode_lbl
            // 
            this.mode_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mode_lbl.AutoSize = true;
            this.mode_lbl.Enabled = false;
            this.mode_lbl.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mode_lbl.Location = new System.Drawing.Point(12, 374);
            this.mode_lbl.Name = "mode_lbl";
            this.mode_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mode_lbl.Size = new System.Drawing.Size(56, 29);
            this.mode_lbl.TabIndex = 2;
            this.mode_lbl.Text = "Mode:";
            // 
            // vectorDebug
            // 
            this.vectorDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorDebug.Enabled = false;
            this.vectorDebug.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vectorDebug.Location = new System.Drawing.Point(713, 12);
            this.vectorDebug.Name = "vectorDebug";
            this.vectorDebug.Size = new System.Drawing.Size(75, 33);
            this.vectorDebug.TabIndex = 3;
            this.vectorDebug.Text = "Vector Lines";
            this.vectorDebug.UseVisualStyleBackColor = true;
            this.vectorDebug.Click += new System.EventHandler(this.vectorDebug_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vectorDebug);
            this.Controls.Add(this.mode_lbl);
            this.Controls.Add(this.Switch_btn);
            this.Controls.Add(this.Reset_btn);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Bubbles";
            this.Load += new System.EventHandler(this.AnimationWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationWindow_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimationWindow_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ProgramTimer;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.Button Switch_btn;
        private System.Windows.Forms.Label mode_lbl;
        private System.Windows.Forms.Button vectorDebug;
    }
}

