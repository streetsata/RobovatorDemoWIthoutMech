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
        private float maxCb;
        private float minCb;
        private float maxCr;
        private float minCr;


        public Form1()
        {
            InitializeComponent();

            filter = new YCbCrFiltering();

            blobCounter.MinWidth = 30;
            blobCounter.MinHeight = 30;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();

            FileVideoSource file = new FileVideoSource(openFileDialog1.FileName);

            videoSourcePlayer1.VideoSource = file;
            videoSourcePlayer1.Start();
            //videoSourcePlayer2.VideoSource = asyncSource;
            //videoSourcePlayer2.Start();
        }

        int tmp = 0;


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.Stop();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {

            //if (tmp <= 1)
            //{
            //    tmp++;
            //    return;
            //}
            //tmp = 0;

            Bitmap tmpImg = (Bitmap)image.Clone();
            
            filter.Y = new Range(0, 1);
            filter.Cb = new Range(minCb, maxCb);
            filter.Cr = new Range(minCr, maxCr);
            filter.ApplyInPlace(tmpImg);
            
            //BitmapData objectsData = image.LockBits(new Rectangle(0, 0,
            //    image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            //UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            //image.UnlockBits(objectsData);


            blobCounter.ProcessImage(tmpImg);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            Graphics g = Graphics.FromImage(tmpImg);
            Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5);
            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                    g.DrawRectangle(pen, rects[0]);
            g.Dispose();
            pictureBox1.Image = tmpImg;

        }

        private void sliderControl1_PositionChanged(object sender, float position)
        {
            minCb = position * 500;
        }

        private void colorSlider1_ValuesChanged(object sender, EventArgs e)
        {
            int tmp = 0;

        }

        private void sliderControl2_PositionChanged(object sender, float position)
        {
            maxCb = position * 500;
        }

        private void sliderControl4_PositionChanged(object sender, float position)
        {
            minCr = position * 500;
        }

        private void sliderControl3_PositionChanged(object sender, float position)
        {
            maxCr = position * 500;
        }

    }
}
