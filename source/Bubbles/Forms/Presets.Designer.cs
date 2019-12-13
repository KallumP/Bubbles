namespace Bubbles
{
    partial class Presets
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
            this.ThreeBodySys_btn = new System.Windows.Forms.Button();
            this.SolarSys_btn = new System.Windows.Forms.Button();
            this.TwoBodySys_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThreeBodySys_btn
            // 
            this.ThreeBodySys_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ThreeBodySys_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ThreeBodySys_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ThreeBodySys_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeBodySys_btn.Location = new System.Drawing.Point(12, 128);
            this.ThreeBodySys_btn.Name = "ThreeBodySys_btn";
            this.ThreeBodySys_btn.Size = new System.Drawing.Size(157, 52);
            this.ThreeBodySys_btn.TabIndex = 0;
            this.ThreeBodySys_btn.Text = "Three Body System";
            this.ThreeBodySys_btn.UseVisualStyleBackColor = true;
            this.ThreeBodySys_btn.Click += new System.EventHandler(this.ThreeBodySys_btn_Click);
            // 
            // SolarSys_btn
            // 
            this.SolarSys_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SolarSys_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SolarSys_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.SolarSys_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SolarSys_btn.Location = new System.Drawing.Point(12, 12);
            this.SolarSys_btn.Name = "SolarSys_btn";
            this.SolarSys_btn.Size = new System.Drawing.Size(157, 52);
            this.SolarSys_btn.TabIndex = 1;
            this.SolarSys_btn.Text = "Solar System";
            this.SolarSys_btn.UseVisualStyleBackColor = true;
            this.SolarSys_btn.Click += new System.EventHandler(this.SolarSys_btn_Click);
            // 
            // TwoBodySys_btn
            // 
            this.TwoBodySys_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TwoBodySys_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.TwoBodySys_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TwoBodySys_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwoBodySys_btn.Location = new System.Drawing.Point(12, 70);
            this.TwoBodySys_btn.Name = "TwoBodySys_btn";
            this.TwoBodySys_btn.Size = new System.Drawing.Size(157, 52);
            this.TwoBodySys_btn.TabIndex = 2;
            this.TwoBodySys_btn.Text = "Two Body System";
            this.TwoBodySys_btn.UseVisualStyleBackColor = true;
            this.TwoBodySys_btn.Click += new System.EventHandler(this.TwoBodySys_btn_Click);
            // 
            // Presets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 192);
            this.Controls.Add(this.TwoBodySys_btn);
            this.Controls.Add(this.SolarSys_btn);
            this.Controls.Add(this.ThreeBodySys_btn);
            this.Name = "Presets";
            this.Text = "Presets";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ThreeBodySys_btn;
        private System.Windows.Forms.Button SolarSys_btn;
        private System.Windows.Forms.Button TwoBodySys_btn;
    }
}