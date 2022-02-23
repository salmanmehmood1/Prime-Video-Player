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
    public partial class SignUp : Form
    {
      
        IFirebaseClient client;
        public string ss;
        public SignUp(IFirebaseClient clint, string s)
        {
            ss = s;
            client = clint;
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private async void bunifuThinButton22_Click(object sender, EventArgs e)
        {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);

                var data = new Data
                {
                    Name = UsernameTextbox1.Text,
                    Mobile_Num = bunifuMaterialTextbox1.Text,
                    Address = bunifuMaterialTextbox2.Text,
                    Email = bunifuMaterialTextbox3.Text,
                    Password = bunifuMaterialTextbox4.Text,
                    Confirm_pass = bunifuMaterialTextbox5.Text,
                    Img = output
                };
            if (ss == "USER")
            {
                SetResponse response1 = await client.SetTaskAsync("User Data/" + UsernameTextbox1.Text, data);
                Data result = response1.ResultAs<Data>();
            }
            else if(ss == "ADMIN")
            {
                SetResponse response1 = await client.SetTaskAsync("Admin Data/" + UsernameTextbox1.Text, data);
                Data result = response1.ResultAs<Data>();
            }
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            OpenFileDialog on = new OpenFileDialog();
            on.Title = "Photo";
            on.Filter = "Image (jpg,jpeg,png) | *.jpg;*.jpeg;*.png|all files|*.*";
            if (on.ShowDialog() == DialogResult.OK)
            {
                Image ir = new Bitmap(on.FileName);
                pictureBox1.Image = ir.GetThumbnailImage(128, 130, null, new IntPtr());

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsernameTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
