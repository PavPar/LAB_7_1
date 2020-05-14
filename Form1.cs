using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы нажали на кнопку, вау", "Ты победил, но какой ценой?");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //label3.Text = "W: " + Form1.ActiveForm.Size;
            Button btn = button1;
            Point pos = btn.PointToClient(Cursor.Position);
            label1.Text = "btn_loc: " + PointToClient(button1.Location);
            label2.Text = "C_X_Test: " + this.PointToClient(Cursor.Position);
            Point center = new Point(((pos.X - (btn.Size.Width / 2)) + Math.Sign(pos.X - (btn.Size.Width / 2))), ((pos.Y - (btn.Size.Height / 2)) + Math.Sign(pos.Y - (btn.Size.Height / 2))));
            label3.Text = "Btn_Curs: " + Math.Abs(center.X / (btn.Size.Width / 2)) + " : " + Math.Abs(center.Y / (btn.Size.Height / 2));

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Point pos = btn.PointToClient(Cursor.Position);
            Point center = new Point(((pos.X - (btn.Size.Width / 2)) + Math.Sign(pos.X - (btn.Size.Width / 2))), ((pos.Y - (btn.Size.Height / 2)) + Math.Sign(pos.Y - (btn.Size.Height / 2))));
            
           
            if ((float)Math.Abs(center.X)/(btn.Size.Width / 2) > (float)Math.Abs(center.Y) / (btn.Size.Height / 2))
            {
                btn.Location = new Point(btn.Location.X + center.X + Math.Sign(-center.X) * (btn.Size.Width / 2), btn.Location.Y);
            }
            else
            {
                if ((float)Math.Abs(center.X) / (btn.Size.Width / 2) == (float)Math.Abs(center.Y) / (btn.Size.Height / 2))
                {
                    btn.Location = new Point(btn.Location.X + center.X + Math.Sign(-center.X) * (btn.Size.Width / 2), btn.Location.Y + center.Y + Math.Sign(-center.Y) * (btn.Size.Height / 2));
                }
                else
                {
                    btn.Location = new Point(btn.Location.X, btn.Location.Y + center.Y + Math.Sign(-center.Y) * (btn.Size.Height / 2));
                }
            }

            try
            {
                if (btn.Location.X > ActiveForm.Size.Width - 2*btn.Size.Width)
                {
                    btn.Location = new Point(Size.Width - 2 * btn.Size.Width, btn.Location.Y);
                }
                if (btn.Location.X < 0 + btn.Size.Width)
                {
                    btn.Location = new Point(0 + btn.Size.Width, btn.Location.Y);
                }
                if (btn.Location.Y > Size.Height - 2 * btn.Size.Height)
                {
                    btn.Location = new Point(btn.Location.X, Size.Height - 2 * btn.Size.Height);
                }
                if (btn.Location.Y < 0 + btn.Size.Height)
                {
                    btn.Location = new Point(btn.Location.X, 0 + btn.Size.Height);
                }
            }
            catch
            {
                //idk
            }
         
        }
    }

}
