using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Web.WebView2.Core;
using System.Net;
using System.IO;

namespace LInjector_CS

    

{
    public partial class Form1 : Form
    {
        WebClient WebClient = new WebClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (keyTextBox.Text == "Enter Key.")
            {
                keyTextBox.Text = "";
                keyTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9370DB");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(keyTextBox.Text))
            {
                keyTextBox.Text = "Enter Key.";
                keyTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9370DB");
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://lexploits.netlify.app/extra/key");
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            string LInjKey = WebClient.DownloadString("https://lexploits.netlify.app/extra/key");
            string tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
            string newKeyPath = Path.Combine(tempFolder, "LInjector", "key");

            void tryKey()
            {
                Directory.CreateDirectory(Path.GetDirectoryName(newKeyPath));
                using (FileStream fs = File.Create(newKeyPath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(LInjKey);
                    fs.Write(info, 0, info.Length);
                }
            }

            if (keyTextBox.Text == LInjKey)
            {
                tryKey();
                MessageBox.Show("Correct LInjector key.");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect LInjector key.");
            }
        }


        private void approveKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
