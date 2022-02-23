using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Video_Player
{
    public partial class MoviePlay : UserControl
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "nX9ECkVBWhH7oOKqtqwyDofgKbdg6tWThflaKjdt",
            BasePath = "https://ds-project-7c104-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        public MoviePlay()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MoviePlay_Load(object sender, EventArgs e)
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
    }
}
