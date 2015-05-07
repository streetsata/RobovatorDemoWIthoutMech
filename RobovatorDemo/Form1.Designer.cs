namespace RobovatorDemo
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.pictureBox1 = new AForge.Controls.PictureBox();
            this.sliderControl1 = new AForge.Controls.SliderControl();
            this.sliderControl2 = new AForge.Controls.SliderControl();
            this.sliderControl3 = new AForge.Controls.SliderControl();
            this.sliderControl4 = new AForge.Controls.SliderControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 42);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer1.TabIndex = 1;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(341, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // sliderControl1
            // 
            this.sliderControl1.Location = new System.Drawing.Point(13, 316);
            this.sliderControl1.ManipulatorPosition = 0F;
            this.sliderControl1.Name = "sliderControl1";
            this.sliderControl1.ResetPositionOnMouseRelease = false;
            this.sliderControl1.Size = new System.Drawing.Size(321, 23);
            this.sliderControl1.TabIndex = 3;
            this.sliderControl1.Text = "sliderControl1";
            this.sliderControl1.PositionChanged += new AForge.Controls.SliderControl.PositionChangedHandler(this.sliderControl1_PositionChanged);
            // 
            // sliderControl2
            // 
            this.sliderControl2.Location = new System.Drawing.Point(13, 362);
            this.sliderControl2.ManipulatorPosition = 0F;
            this.sliderControl2.Name = "sliderControl2";
            this.sliderControl2.ResetPositionOnMouseRelease = false;
            this.sliderControl2.Size = new System.Drawing.Size(321, 22);
            this.sliderControl2.TabIndex = 5;
            this.sliderControl2.Text = "sliderControl2";
            this.sliderControl2.PositionChanged += new AForge.Controls.SliderControl.PositionChangedHandler(this.sliderControl2_PositionChanged);
            // 
            // sliderControl3
            // 
            this.sliderControl3.Location = new System.Drawing.Point(341, 362);
            this.sliderControl3.ManipulatorPosition = 0F;
            this.sliderControl3.Name = "sliderControl3";
            this.sliderControl3.ResetPositionOnMouseRelease = false;
            this.sliderControl3.Size = new System.Drawing.Size(340, 22);
            this.sliderControl3.TabIndex = 7;
            this.sliderControl3.Text = "sliderControl3";
            this.sliderControl3.PositionChanged += new AForge.Controls.SliderControl.PositionChangedHandler(this.sliderControl3_PositionChanged);
            // 
            // sliderControl4
            // 
            this.sliderControl4.Location = new System.Drawing.Point(341, 316);
            this.sliderControl4.ManipulatorPosition = 0F;
            this.sliderControl4.Name = "sliderControl4";
            this.sliderControl4.ResetPositionOnMouseRelease = false;
            this.sliderControl4.Size = new System.Drawing.Size(340, 29);
            this.sliderControl4.TabIndex = 6;
            this.sliderControl4.Text = "sliderControl4";
            this.sliderControl4.PositionChanged += new AForge.Controls.SliderControl.PositionChangedHandler(this.sliderControl4_PositionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CbMin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CbMax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "CrMax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CrMin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sliderControl3);
            this.Controls.Add(this.sliderControl4);
            this.Controls.Add(this.sliderControl2);
            this.Controls.Add(this.sliderControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RobovatorDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private AForge.Controls.PictureBox pictureBox1;
        private AForge.Controls.SliderControl sliderControl1;
        private AForge.Controls.SliderControl sliderControl2;
        private AForge.Controls.SliderControl sliderControl3;
        private AForge.Controls.SliderControl sliderControl4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

