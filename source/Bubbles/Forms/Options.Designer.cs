namespace Bubbles
{
    partial class Options
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
            this.components = new System.ComponentModel.Container();
            this.SpawnMass_radio = new System.Windows.Forms.RadioButton();
            this.ExplodeMass_radio = new System.Windows.Forms.RadioButton();
            this.CreateRockets_radio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SizeAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.VelocityLines_check = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BubbleMass_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.BubbleTVel_txt = new System.Windows.Forms.TextBox();
            this.BubbleZMass_chk = new System.Windows.Forms.CheckBox();
            this.BubbleStatic_chk = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RocketTank_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RocketTVel_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RocketMass_txt = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BubbleForce_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AngleDemo_pic = new System.Windows.Forms.PictureBox();
            this.BubbleAngle_bar = new System.Windows.Forms.TrackBar();
            this.TrailLines_check = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AngleDemo_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BubbleAngle_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // SpawnMass_radio
            // 
            this.SpawnMass_radio.AutoSize = true;
            this.SpawnMass_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpawnMass_radio.Location = new System.Drawing.Point(3, 31);
            this.SpawnMass_radio.Name = "SpawnMass_radio";
            this.SpawnMass_radio.Size = new System.Drawing.Size(118, 24);
            this.SpawnMass_radio.TabIndex = 0;
            this.SpawnMass_radio.TabStop = true;
            this.SpawnMass_radio.Text = "Spawn Mass";
            this.SpawnMass_radio.UseVisualStyleBackColor = true;
            this.SpawnMass_radio.CheckedChanged += new System.EventHandler(this.SpawnMass_radio_CheckedChanged);
            // 
            // ExplodeMass_radio
            // 
            this.ExplodeMass_radio.AutoSize = true;
            this.ExplodeMass_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExplodeMass_radio.Location = new System.Drawing.Point(3, 70);
            this.ExplodeMass_radio.Name = "ExplodeMass_radio";
            this.ExplodeMass_radio.Size = new System.Drawing.Size(126, 24);
            this.ExplodeMass_radio.TabIndex = 1;
            this.ExplodeMass_radio.TabStop = true;
            this.ExplodeMass_radio.Text = "Explode Mass";
            this.ExplodeMass_radio.UseVisualStyleBackColor = true;
            this.ExplodeMass_radio.CheckedChanged += new System.EventHandler(this.ExplodeMass_radio_CheckedChanged);
            // 
            // CreateRockets_radio
            // 
            this.CreateRockets_radio.AutoSize = true;
            this.CreateRockets_radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRockets_radio.Location = new System.Drawing.Point(3, 109);
            this.CreateRockets_radio.Name = "CreateRockets_radio";
            this.CreateRockets_radio.Size = new System.Drawing.Size(138, 24);
            this.CreateRockets_radio.TabIndex = 2;
            this.CreateRockets_radio.TabStop = true;
            this.CreateRockets_radio.Text = "Create Rockets";
            this.CreateRockets_radio.UseVisualStyleBackColor = true;
            this.CreateRockets_radio.CheckedChanged += new System.EventHandler(this.CreateRockets_radio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SpawnMass_radio);
            this.panel1.Controls.Add(this.ExplodeMass_radio);
            this.panel1.Controls.Add(this.CreateRockets_radio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 45);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(146, 144);
            this.panel1.TabIndex = 4;
            // 
            // SizeAnimationTimer
            // 
            this.SizeAnimationTimer.Interval = 16;
            this.SizeAnimationTimer.Tick += new System.EventHandler(this.AnimateResize);
            // 
            // MoveAnimationTimer
            // 
            this.MoveAnimationTimer.Interval = 16;
            // 
            // VelocityLines_check
            // 
            this.VelocityLines_check.AutoSize = true;
            this.VelocityLines_check.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelocityLines_check.Location = new System.Drawing.Point(600, 43);
            this.VelocityLines_check.Name = "VelocityLines_check";
            this.VelocityLines_check.Size = new System.Drawing.Size(127, 33);
            this.VelocityLines_check.TabIndex = 5;
            this.VelocityLines_check.Text = "Velocity Lines";
            this.VelocityLines_check.UseVisualStyleBackColor = true;
            this.VelocityLines_check.Click += new System.EventHandler(this.VelocityLines_check_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mass";
            // 
            // BubbleMass_txt
            // 
            this.BubbleMass_txt.Location = new System.Drawing.Point(64, 13);
            this.BubbleMass_txt.Name = "BubbleMass_txt";
            this.BubbleMass_txt.Size = new System.Drawing.Size(100, 20);
            this.BubbleMass_txt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 13);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bubble";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.BubbleTVel_txt);
            this.panel2.Controls.Add(this.BubbleZMass_chk);
            this.panel2.Controls.Add(this.BubbleStatic_chk);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BubbleMass_txt);
            this.panel2.Location = new System.Drawing.Point(162, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 156);
            this.panel2.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Term. Vel.";
            // 
            // BubbleTVel_txt
            // 
            this.BubbleTVel_txt.Location = new System.Drawing.Point(97, 52);
            this.BubbleTVel_txt.Name = "BubbleTVel_txt";
            this.BubbleTVel_txt.Size = new System.Drawing.Size(67, 20);
            this.BubbleTVel_txt.TabIndex = 13;
            // 
            // BubbleZMass_chk
            // 
            this.BubbleZMass_chk.AutoSize = true;
            this.BubbleZMass_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BubbleZMass_chk.Location = new System.Drawing.Point(15, 126);
            this.BubbleZMass_chk.Name = "BubbleZMass_chk";
            this.BubbleZMass_chk.Size = new System.Drawing.Size(103, 24);
            this.BubbleZMass_chk.TabIndex = 11;
            this.BubbleZMass_chk.Text = "Zero Mass";
            this.BubbleZMass_chk.UseVisualStyleBackColor = true;
            // 
            // BubbleStatic_chk
            // 
            this.BubbleStatic_chk.AutoSize = true;
            this.BubbleStatic_chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BubbleStatic_chk.Location = new System.Drawing.Point(15, 86);
            this.BubbleStatic_chk.Name = "BubbleStatic_chk";
            this.BubbleStatic_chk.Size = new System.Drawing.Size(69, 24);
            this.BubbleStatic_chk.TabIndex = 10;
            this.BubbleStatic_chk.Text = "Static";
            this.BubbleStatic_chk.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.RocketTank_txt);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.RocketTVel_txt);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.RocketMass_txt);
            this.panel3.Location = new System.Drawing.Point(358, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 144);
            this.panel3.TabIndex = 15;
            // 
            // RocketTank_txt
            // 
            this.RocketTank_txt.Location = new System.Drawing.Point(118, 73);
            this.RocketTank_txt.Name = "RocketTank_txt";
            this.RocketTank_txt.Size = new System.Drawing.Size(100, 20);
            this.RocketTank_txt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mass";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(76, 8);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rocket";
            // 
            // RocketTVel_txt
            // 
            this.RocketTVel_txt.Location = new System.Drawing.Point(118, 113);
            this.RocketTVel_txt.Name = "RocketTVel_txt";
            this.RocketTVel_txt.Size = new System.Drawing.Size(100, 20);
            this.RocketTVel_txt.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tank Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Term. Vel.";
            // 
            // RocketMass_txt
            // 
            this.RocketMass_txt.Location = new System.Drawing.Point(118, 32);
            this.RocketMass_txt.Name = "RocketMass_txt";
            this.RocketMass_txt.Size = new System.Drawing.Size(100, 20);
            this.RocketMass_txt.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BubbleForce_txt);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.AngleDemo_pic);
            this.panel4.Controls.Add(this.BubbleAngle_bar);
            this.panel4.Location = new System.Drawing.Point(162, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 112);
            this.panel4.TabIndex = 16;
            // 
            // BubbleForce_txt
            // 
            this.BubbleForce_txt.Location = new System.Drawing.Point(3, 80);
            this.BubbleForce_txt.Name = "BubbleForce_txt";
            this.BubbleForce_txt.Size = new System.Drawing.Size(115, 20);
            this.BubbleForce_txt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Force";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Angle";
            // 
            // AngleDemo_pic
            // 
            this.AngleDemo_pic.Location = new System.Drawing.Point(122, 50);
            this.AngleDemo_pic.Name = "AngleDemo_pic";
            this.AngleDemo_pic.Size = new System.Drawing.Size(50, 50);
            this.AngleDemo_pic.TabIndex = 1;
            this.AngleDemo_pic.TabStop = false;
            this.AngleDemo_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.AngleDemo_pic_Paint);
            // 
            // BubbleAngle_bar
            // 
            this.BubbleAngle_bar.Location = new System.Drawing.Point(-1, 22);
            this.BubbleAngle_bar.Maximum = 6282;
            this.BubbleAngle_bar.Name = "BubbleAngle_bar";
            this.BubbleAngle_bar.Size = new System.Drawing.Size(177, 45);
            this.BubbleAngle_bar.TabIndex = 0;
            this.BubbleAngle_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BubbleAngle_bar.Value = 1;
            this.BubbleAngle_bar.Scroll += new System.EventHandler(this.BubbleAngle_bar_Scroll);
            // 
            // TrailLines_check
            // 
            this.TrailLines_check.AutoSize = true;
            this.TrailLines_check.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrailLines_check.Location = new System.Drawing.Point(600, 77);
            this.TrailLines_check.Name = "TrailLines_check";
            this.TrailLines_check.Size = new System.Drawing.Size(102, 33);
            this.TrailLines_check.TabIndex = 17;
            this.TrailLines_check.Text = "Trail Lines";
            this.TrailLines_check.UseVisualStyleBackColor = true;
            this.TrailLines_check.CheckedChanged += new System.EventHandler(this.TrailLines_check_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 338);
            this.Controls.Add(this.TrailLines_check);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VelocityLines_check);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Options_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AngleDemo_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BubbleAngle_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton SpawnMass_radio;
        private System.Windows.Forms.RadioButton ExplodeMass_radio;
        private System.Windows.Forms.RadioButton CreateRockets_radio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer SizeAnimationTimer;
        private System.Windows.Forms.Timer MoveAnimationTimer;
        private System.Windows.Forms.CheckBox VelocityLines_check;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BubbleMass_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox RocketTank_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RocketTVel_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RocketMass_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox BubbleZMass_chk;
        private System.Windows.Forms.CheckBox BubbleStatic_chk;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TrackBar BubbleAngle_bar;
        private System.Windows.Forms.TextBox BubbleForce_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox AngleDemo_pic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BubbleTVel_txt;
        private System.Windows.Forms.CheckBox TrailLines_check;
    }
}