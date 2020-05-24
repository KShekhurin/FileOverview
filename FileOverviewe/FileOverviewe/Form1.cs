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

namespace FileOverviewe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode();
                node.Text = di.Name;
                treeView1.Nodes.Add(node);
                FillNode(ref node, di.Name);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dir = Directory.GetDirectories(e.Node.FullPath);
            string[] files = Directory.GetFiles(e.Node.FullPath);
            if (dir.Length != 0)
            {
                foreach (string file in files)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = file.Remove(0, file.LastIndexOf("\\") + 1);
                    e.Node.Nodes.Add(treeNode);
                }

                foreach (string str in dir)
                {
                    TreeNode treeNode = new TreeNode();
                    try
                    {
                        if (Directory.GetDirectories(str).Length != 0)
                        {
                            treeNode.Nodes.Add("pass");
                        }
                    }
                    catch
                    {

                    }
                    string str2 = str.Remove(0, str.LastIndexOf("\\") + 1);
                    treeNode.Text = str2;
                    e.Node.Nodes.Add(treeNode);
                }
            }
        }

        private void FillNode(ref TreeNode node, string path)
        {
            node.Nodes.Clear();
            string[] dir = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            if (dir.Length != 0)
            {
                foreach (string file in files)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = file.Remove(0, file.LastIndexOf("\\") + 1);
                    node.Nodes.Add(treeNode);
                }

                foreach (string str in dir)
                {
                    TreeNode treeNode = new TreeNode();
                    try
                    {
                        if (Directory.GetDirectories(str).Length != 0)
                        {
                            treeNode.Nodes.Add("pass");
                        }
                    }
                    catch
                    {

                    }
                    string str2 = str.Remove(0, str.LastIndexOf("\\") + 1);
                    treeNode.Text = str;
                    node.Nodes.Add(treeNode);
                }
            }
        }
    }
}
