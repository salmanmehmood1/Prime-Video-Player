using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Drawing.Imaging;

namespace Video_Player
{
    public partial class AdminPanel : Form
    {
        recent r1;
        public AdminPanel()
        {
            InitializeComponent();
        }
        public IFirebaseClient client;
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            //Font myfont = new Font("Arial", 14);
            //Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            //e.Graphics.TranslateTransform(30, 20);
            //e.Graphics.RotateTransform(-90);
            //e.Graphics.DrawString("Prime Video", myfont, mybrush, 0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            AddMovie f2 = new AddMovie();
            bunifuGradientPanel3.Controls.Clear();
            bunifuGradientPanel3.Controls.Add(f2);
        }

        private async void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FirebaseResponse resp = await client.GetTaskAsync("Playlist/");
            PlayList obj = resp.ResultAs<PlayList>();
            r1 = new recent();
            bunifuGradientPanel3.Controls.Clear();
            bunifuGradientPanel3.Controls.Add(r1);
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
