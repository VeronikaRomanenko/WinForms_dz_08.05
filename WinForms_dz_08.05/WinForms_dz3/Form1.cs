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

namespace WinForms_dz3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();
        }

        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo item in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(item.Name);
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
                e.Node.Nodes.Clear();
                listView1.Clear();
                try
                {
                    ListViewItem item1 = new ListViewItem("Дата создания - " + new FileInfo(e.Node.FullPath).CreationTime.ToString());
                    listView1.Items.Add(item1);
                    ListViewItem item2 = new ListViewItem("Атрибуты - " + new FileInfo(e.Node.FullPath).Attributes.ToString());
                    listView1.Items.Add(item2);
                    ListViewItem item3 = new ListViewItem("Размер - " + new FileInfo(e.Node.FullPath).Length);
                    listView1.Items.Add(item3);
                    ListViewItem item4 = new ListViewItem("Расширение - " + new DirectoryInfo(e.Node.FullPath).Extension);
                    listView1.Items.Add(item4);
                }
                catch (Exception ex)
                {

                }                
                foreach (string item in Directory.GetDirectories(e.Node.FullPath))
                {
                    TreeNode node = new TreeNode(new DirectoryInfo(item).Name);
                    e.Node.Nodes.Add(node);
                }
                foreach (string item in Directory.GetFiles(e.Node.FullPath))
                {
                    TreeNode node = new TreeNode(new FileInfo(item).Name);
                    e.Node.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
