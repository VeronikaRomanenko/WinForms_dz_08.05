using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_dz2
{
    public partial class Form1 : Form
    {
        ImageList large_gellary = null;
        ImageList small_gellary = null;
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();
            large_gellary = new ImageList();
            large_gellary.ImageSize = new Size(50, 50);
            small_gellary = new ImageList();
            small_gellary.ImageSize = new Size(25, 25);
        }
        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    ListViewItem driveNode = new ListViewItem(drive.Name);
                    listView1.Items.Add(driveNode);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                large_gellary.Images.Clear();
                small_gellary.Images.Clear();
                string[] dirs = Directory.GetDirectories(textBox1.Text);
                for (int i = 0; i < dirs.Length; i++)
                {
                    ListViewItem driveNode = new ListViewItem(new DirectoryInfo(dirs[i]).Name);
                    //large_gellary.Images.Add(new DirectoryInfo(dirs[i]).)
                    listView1.Items.Add(driveNode);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
