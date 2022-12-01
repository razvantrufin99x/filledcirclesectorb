/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 6/17/2020
 * Time: 12:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace filledcirclesector
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Graphics g;
		public Font font0;
		public Pen pen0 = new Pen(Color.Black);
		public Pen pen1 = new Pen(Color.Black,7);
		public Pen pen2 = new Pen(Color.Red,30);
		public Brush brush0 =  new SolidBrush(Color.Black);
		public float cx,cy,px,py;
		public float step = 5.0f;
		public const double g2r = 180 / Math.PI;
		public int ismd = 0;
		public int su = 0;
		public int eu = 100;
		
		public void drawcircle()
		{
			cx = (float)Math.Cos(0/g2r) * 25*2 + 100;
			cy = (float)Math.Sin(0/g2r) * 25*2 + 100;
			px = cx;
			py = cy;
			
			for(float i = 0 ; i < 360+step ; i+=step)
			{
				cx = (float)Math.Cos(i/g2r) * 25*2 + 100;
				cy = (float)Math.Sin(i/g2r) * 25*2 + 100;
				try{
					g.DrawLine(pen0,cx,cy,px,py);
				}
				catch{}
				px = cx;
				py = cy;
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			font0 = this.Font;
			g = pictureBox1.CreateGraphics();
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			
			
		}
		void MainFormShown(object sender, EventArgs e)
		{
			
		}
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			
		}
		void PictureBox1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Close();
		}
		void PictureBox1MouseEnter(object sender, EventArgs e)
		{
			
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			//drawcircle();
			g.Clear(BackColor);
			g.DrawEllipse(pen0,0,0,100,100);
			g.DrawEllipse(pen0,10,10,80,80);
			g.DrawArc(pen1,10,10,80,80,su++,eu++);
			//g.DrawArc(pen2,10,10,80,80,su++,eu++);
			g.DrawArc(pen2,10,10,80,80,su,2);
			g.DrawArc(pen2,10,10,80,80,eu,2);
			g.DrawString(su.ToString(),font0,brush0,40,33);
			g.DrawString(eu.ToString(),font0,brush0,40,47);
			label1.Text = (eu-su).ToString();
			
			if(su<360){
				su++;
			}
			else{su=0;}
			if(eu<360){
				eu+=2;
			}
			else{eu=su+1;}
			//pictureBox1.Invalidate();
		}
		void PictureBox1MouseUp(object sender, MouseEventArgs e)
		{
			ismd = 0;
		}
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			ismd = 1;
		}
		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{
			if(ismd ==1)
			{
				Left += e.X;
				Top  += e.Y;
			}
		}
	}
}
