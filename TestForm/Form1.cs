using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadInfo()
        {
            using (DataContainer c = new DataContainer())
            {
                var allCategorys = c.Category.ToList();

                if (allCategorys.Count == 0 || allCategorys.Any(p => p.Name == "root") == false)
                {
                    Category root_add = new Category();
                    root_add.Name = "root";
                    root_add.Parent = null;
                    c.AddToCategory(root_add);
                    c.SaveChanges();
                }

                Category root = c.Category.Where(p => p.Name == "root").First();
                Tree1.Nodes.Clear();
                var nodes = GetTreeNodes(root);
                nodes.ExpandAll();
                Tree1.Nodes.Add(nodes);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private TreeNode GetTreeNodes(Category category)
        {
            TreeNode result = new TreeNode();
            result.Text = category.Name;
            result.Tag = category.Id;
            foreach (Category child in category.Children)
            {
                result.Nodes.Add(GetTreeNodes(child));
            }
            return result;
        }

        private void Tree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            textBox1.Text = e.Node.Text;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (DataContainer c = new DataContainer())
            {
                int id = Convert.ToInt32(Tree1.SelectedNode.Tag);
                var cs = c.Category.Where(p => p.Id == id);
                foreach (Category category in cs)
                {
                    category.Name = textBox1.Text;
                }
                c.SaveChanges();
            }
            LoadInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            if (string.IsNullOrEmpty(name))
                return;
            using (DataContainer c = new DataContainer())
            {
                int id = Convert.ToInt32(Tree1.SelectedNode.Tag);
                Category parent = c.Category.First(p => p.Id == id);
                Category category = new Category();
                category.Name = name;
                category.Parent = parent;
                c.AddToCategory(category);
                c.SaveChanges();
            }
            //LoadInfo();
        }

    }
}
