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

namespace RobovatorDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "avi files (*.avi)|*.avi|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();

            FileVideoSource file = new FileVideoSource(openFileDialog1.FileName);
            videoSourcePlayer1.AutoSizeControl = false;
            videoSourcePlayer1.VideoSource = file;
            videoSourcePlayer1.Start();

        }
    }
}
