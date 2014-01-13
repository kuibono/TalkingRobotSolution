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

        private void listSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadInfo(int id)
        {
            Word w;
            using(Data2Container c=new Data2Container())
            {
                var q = from l in c.Word where l.Id == id select l;
                if(q.Count()>0)
                {
                    w = q.First();
                }
                else
                {
                    w=new Word();
                }
            }

            txtWord.Text = w.Content;
            txtRegex.Text = w.Regex;
            cn.Checked = w.cn;
            an.Checked = w.an;
            on.Checked = w.on;
            pp.Checked = w.pp;
            dp.Checked = w.dp;
            qp.Checked = w.qp;
            tv.Checked = w.tv;
            iv.Checked = w.iv;
            cv.Checked = w.cv;
            nv.Checked = w.nv;
            wv.Checked = w.wv;
            dv.Checked = w.dv;
            adjn.Checked = w.adjn;
            adjs.Checked = w.adjs;
        }
    }
}
