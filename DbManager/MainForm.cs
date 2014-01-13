using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace DbManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }

        private void SearchList()
        {
            string keywords = txtKeyword.Text;
            if(string.IsNullOrEmpty(keywords))
                return;
            using(Data2Container e=new Data2Container())
            {
                var q = from l in e.Word where l.Content.Contains(keywords) select l;
                q = q.Take(200);
                listSearchResult.Items.Clear();
                foreach (Word word in q.ToList())
                {
                    listSearchResult.Items.Add(word.Id+":"+word.Content);
                }

            }
        }
    }
}
