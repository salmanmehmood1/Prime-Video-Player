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
    public class Data
    {
        public string Name { get; set; }
        public string Mobile_Num { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_pass { get; set; }
        public string Img { get; set; }

    }
    
}
