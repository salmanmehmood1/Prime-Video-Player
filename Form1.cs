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
    public partial class Form1 : Form
    {

        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "nX9ECkVBWhH7oOKqtqwyDofgKbdg6tWThflaKjdt",
            BasePath = "https://ds-project-7c104-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                //MessageBox.Show("Connection Established");
            }
            else
            {
                MessageBox.Show("Connection Not Established");
            }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void Username_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void bunifuCustomLabel2_Click_1(object sender, EventArgs e)
        {
            
                this.Hide();
                SignUp f1 = new SignUp(client, bunifuDropdown1.selectedValue);
                f1.ShowDialog();
           
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if(bunifuDropdown1.selectedIndex == 1)
            {
                Username.Text = "Admin ";
            }
            else
            {
                Username.Text = "Username ";
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected_1(object sender, EventArgs e)
        {

        }

        private async void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.selectedValue == "ADMIN")
            {
                FirebaseResponse response = await client.GetTaskAsync("Admin Data/" + UsernameTextbox1.Text);
                Data obj = response.ResultAs<Data>();
                if (UsernameTextbox1.Text == obj.Name && bunifuMaterialTextbox1.Text == obj.Password)
                {
                    this.Hide();
                    AdminPanel f3 = new AdminPanel();
                    f3.ShowDialog();
                }
            }
            else if (bunifuDropdown1.selectedValue == "USER")
            {
                FirebaseResponse response = await client.GetTaskAsync("User Data/" + UsernameTextbox1.Text);
                Data obj = response.ResultAs<Data>();
                if(UsernameTextbox1.Text == obj.Name && bunifuMaterialTextbox1.Text == obj.Password)
                {
                    this.Hide();
                    UserPanel f4 = new UserPanel();
                    f4.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Name / Password");
                }
            }
            
        }

        private void bunifuMaterialTextbox1_OnValueChanged_2(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
