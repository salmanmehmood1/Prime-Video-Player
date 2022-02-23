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
using Firebase.Storage;
using System.Drawing.Imaging;

namespace Video_Player
{
    public partial class AddMovie : UserControl
    {
        public string url;
        public int cnt = 0;

        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "nX9ECkVBWhH7oOKqtqwyDofgKbdg6tWThflaKjdt",
            BasePath = "https://ds-project-7c104-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        

        public AddMovie()
        {
            InitializeComponent();
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {

                MessageBox.Show("Not Connected");
            }
        }

        private  void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog on = new OpenFileDialog();
            on.Title = "Photo";
            on.Filter = "Image (jpg,jpeg,png) | *.jpg;*.jpeg;*.png|all files|*.*";
            if (on.ShowDialog() == DialogResult.OK)
            {
                Image ir = new Bitmap(on.FileName);
                pictureBox1.Image = ir.GetThumbnailImage(128, 130, null, new IntPtr());
                //trans1.ShowSync(bunifuThinButton21);
            }
        }

        private async void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog im = new OpenFileDialog();
            im.Title = "Select";
            im.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (im.ShowDialog() == DialogResult.OK)
            {
                cnt = 1;
                try
                {
                    var stream = File.Open(im.FileName, FileMode.Open);
                    var task = new FirebaseStorage("gs://ds-project-7c104.appspot.com/data")
                            .Child("data")
                            .Child("project")
                            .Child(im.FileName)
                            .PutAsync(stream);

                    //trans1.ShowSync(bunifuCircleProgressbar1);
                    task.Progress.ProgressChanged += (s, rk) => bunifuCircleProgressbar1.Value = rk.Percentage;

                    var downloadUrl = await task;
                    url = downloadUrl;
                    bunifuCircleProgressbar1.Hide();
                    //trans1.ShowSync(bunifuThinButton22);
                    // bunifuThinButton22.Show();
                }
                catch (Exception es)
                {
                    var msg = es;
                    MessageBox.Show("Internet Error");
                }

            }
        }

        private void nametext_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null && cnt != 0 && nametext.Text != "" && bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text !="" && bunifuMaterialTextbox4.Text != "")
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);

                var data = new Movie_Data
                {
                    M_Name = nametext.Text,
                    M_Desc = bunifuMaterialTextbox1.Text,
                    M_Creator = bunifuMaterialTextbox2.Text,
                    M_Starr = bunifuMaterialTextbox3.Text,
                    M_Genre = bunifuMaterialTextbox4.Text,
                    img = output
                };
                SetResponse response1 = await client.SetTaskAsync("Movie Data/" + nametext.Text, data);
                Data result = response1.ResultAs<Data>();
            }
            else
            {
                MessageBox.Show("Something Wrong");
            }
        }
    }
}
