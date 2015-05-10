using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Video;

namespace RobovatorDemo
{
    public partial class Form1 : Form
    {
        private YCbCrFiltering filter;
        private Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        private BlobCounter blobCounter = new BlobCounter();
        private float maxCb = 0.0f;
        private float minCb = -500.0f;
        private float maxCr = 0.0f;
        private float minCr = -500.0f;
        private int minWidth = 30;
        private int minHeight = 30;

        public Form1()
        {
            InitializeComponent();

            filter = new YCbCrFiltering();

            sliderControl1.ManipulatorPosition = -1.0f;
            sliderControl2.ManipulatorPosition = 0.0f;
            sliderControl3.ManipulatorPosition = 0.0f;
            sliderControl4.ManipulatorPosition = -1.0f;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();

            FileVideoSource file = new FileVideoSource(openFileDialog1.FileName);

            videoSourcePlayer1.VideoSource = file;
            videoSourcePlayer1.Start();
        }

        int tmp = 0;


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.Stop();
            Application.Exit();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {

            if (tmp <= 1)
            {
                tmp++;
                return;
            }
            tmp = 0;

            Bitmap tmpImg = (Bitmap)image.Clone();
            
            filter.Y = new Range(0, 1);
            filter.Cb = new Range(minCb, maxCb);
            filter.Cr = new Range(minCr, maxCr);
            filter.ApplyInPlace(tmpImg);

            blobCounter.MinWidth = minWidth;
            blobCounter.MinHeight = minHeight;
            blobCounter.FilterBlobs = true;
            blobCounter.ProcessImage(tmpImg);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    foreach (Rectangle objectRect in rects)
                    {
                        Graphics g = Graphics.FromImage(tmpImg);
                        using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                        {
                            g.DrawRectangle(pen, objectRect);
                        }

                        g.Dispose();
                    }
                }

            pictureBox1.Image = tmpImg;

        }

        private void sliderControl1_PositionChanged(object sender, float position)
        {
            minCb = position * 500;
            label5.Text = minCb.ToString();
        }

        private void sliderControl2_PositionChanged(object sender, float position)
        {
            maxCb = position * 500;
            label7.Text = maxCb.ToString();
        }

        private void sliderControl4_PositionChanged(object sender, float position)
        {
            minCr = position * 500;
            label6.Text = minCr.ToString();
        }

        private void sliderControl3_PositionChanged(object sender, float position)
        {
            maxCr = position * 500;
            label8.Text = maxCr.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.minHeight = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.minWidth = (int)numericUpDown2.Value;
        }

    }
}
