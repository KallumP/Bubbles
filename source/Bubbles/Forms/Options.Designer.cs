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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpawnMass_radio
            // 
            this.SpawnMass_radio.AutoSize = true;
            this.SpawnMass_radio.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpawnMass_radio.Location = new System.Drawing.Point(3, 3);
            this.SpawnMass_radio.Name = "SpawnMass_radio";
            this.SpawnMass_radio.Size = new System.Drawing.Size(118, 33);
            this.SpawnMass_radio.TabIndex = 0;
            this.SpawnMass_radio.TabStop = true;
            this.SpawnMass_radio.Text = "Spawn Mass";
            this.SpawnMass_radio.UseVisualStyleBackColor = true;
            this.SpawnMass_radio.CheckedChanged += new System.EventHandler(this.SpawnMass_radio_CheckedChanged);
            // 
            // ExplodeMass_radio
            // 
            this.ExplodeMass_radio.AutoSize = true;
            this.ExplodeMass_radio.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExplodeMass_radio.Location = new System.Drawing.Point(3, 42);
            this.ExplodeMass_radio.Name = "ExplodeMass_radio";
            this.ExplodeMass_radio.Size = new System.Drawing.Size(125, 33);
            this.ExplodeMass_radio.TabIndex = 1;
            this.ExplodeMass_radio.TabStop = true;
            this.ExplodeMass_radio.Text = "Explode Mass";
            this.ExplodeMass_radio.UseVisualStyleBackColor = true;
            this.ExplodeMass_radio.CheckedChanged += new System.EventHandler(this.ExplodeMass_radio_CheckedChanged);
            // 
            // CreateRockets_radio
            // 
            this.CreateRockets_radio.AutoSize = true;
            this.CreateRockets_radio.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRockets_radio.Location = new System.Drawing.Point(3, 81);
            this.CreateRockets_radio.Name = "CreateRockets_radio";
            this.CreateRockets_radio.Size = new System.Drawing.Size(134, 33);
            this.CreateRockets_radio.TabIndex = 2;
            this.CreateRockets_radio.TabStop = true;
            this.CreateRockets_radio.Text = "Create Rockets";
            this.CreateRockets_radio.UseVisualStyleBackColor = true;
            this.CreateRockets_radio.CheckedChanged += new System.EventHandler(this.CreateRockets_radio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(60, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SpawnMass_radio);
            this.panel1.Controls.Add(this.ExplodeMass_radio);
            this.panel1.Controls.Add(this.CreateRockets_radio);
            this.panel1.Location = new System.Drawing.Point(18, 45);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(140, 120);
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
            this.VelocityLines_check.Location = new System.Drawing.Point(250, 88);
            this.VelocityLines_check.Name = "VelocityLines_check";
            this.VelocityLines_check.Size = new System.Drawing.Size(127, 33);
            this.VelocityLines_check.TabIndex = 5;
            this.VelocityLines_check.Text = "Velocity Lines";
            this.VelocityLines_check.UseVisualStyleBackColor = true;
            this.VelocityLines_check.Click += new System.EventHandler(this.VelocityLines_check_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 182);
            this.Controls.Add(this.VelocityLines_check);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Options";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Options_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}