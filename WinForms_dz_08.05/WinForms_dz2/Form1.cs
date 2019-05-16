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
            listView1.LargeImageList = large_gellary;
            listView1.SmallImageList = small_gellary;
        }
        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    treeView1.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                large_gellary.Images.Clear();
                small_gellary.Images.Clear();
                foreach (string item in Directory.GetDirectories(e.Node.FullPath))
                {
                    TreeNode driveNode = new TreeNode(item);
                    treeView1.Nodes.Add(driveNode);
                }
                foreach (string item in Directory.GetFiles(e.Node.FullPath))
                {
                    ListViewItem driveNode = new ListViewItem(new DirectoryInfo(item).Name);
                    large_gellary.Images.Add(Image.FromFile(item));
                    small_gellary.Images.Add(Image.FromFile(item));
                    driveNode.ImageIndex = large_gellary.Images.Count - 1;
                    listView1.Items.Add(driveNode);
                }
            }
            catch (Exception ex)
            {

            }            
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}