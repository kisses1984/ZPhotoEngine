﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class ExposureForm : CCWin.Skin_Mac
    {
        public ExposureForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)curBitmap;
            }
        }
        private Bitmap curBitmap = null;
        private int intensity = 0;
        private ZPhotoEngineDll zPhoto = null;
        public int getIntensity
        {
            get { return intensity; }
        }
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                intensity = skinHScrollBar1.Value;
                textBox1.Text = (intensity - 50).ToString();
                pictureBox1.Image = (Image)zPhoto.ExposureAdjust(curBitmap, intensity);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            intensity = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
