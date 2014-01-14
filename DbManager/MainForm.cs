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

        private long selectedId = 0;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }

        private void SearchList()
        {
            string keywords = txtKeyword.Text;
            //if(string.IsNullOrEmpty(keywords))
            //    return;
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
            string text = listSearchResult.SelectedItem.ToString();
            long id = Convert.ToInt64(text.Split(':')[0]);
            selectedId = id;
            LoadInfo(selectedId);
        }

        private void LoadInfo(long id)
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
            bno.Checked = w.bno;
            ono.Checked = w.ono;
            cno.Checked = w.cno;
            mno.Checked = w.mno;
            ano.Checked = w.ano;
            nq.Checked = w.nq;
            vq.Checked = w.vq;
            advd.Checked = w.advd;
            advr.Checked = w.advr;
            advt.Checked = w.advt;
            prer.Checked = w.prer;
            pred.Checked = w.pred;
            preu.Checked = w.prepu;
            prec.Checked = w.prec;
            pree.Checked = w.pree;
            conu.Checked = w.conu;
            conp.Checked = w.conp;
            pars.Checked = w.pars;
            part.Checked = w.part;
            parm.Checked = w.parm;
            inth.Checked = w.inth;
            ints.Checked = w.ints;
            inta.Checked = w.inta;
            intsu.Checked = w.intsu;
            intc.Checked = w.intc;
            intr.Checked = w.intr;
            oo.Checked = w.oo;

            favor.Value = w.favor;
            happy.Value = w.happy;
            anger.Value = w.anger;

            ZhuWei.Checked = w.ZhuWei;
            DongBin.Checked = w.DongBin;
            PianZhengDingZhong.Checked = w.PianZhengDingZhong;
            PianzhengZhuangZhong.Checked = w.PianZhengZhuangZhong;
            ZhongBu.Checked = w.ZhongBu;
            LianWei.Checked = w.LianWei;
            JianYu.Checked = w.JianYu;
            TongWei.Checked = w.TongWei;
            FangWei.Checked = w.FangWei;

            status.Text = txtWord.Text + " loaded.";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IniDefault();
        }

        private void IniDefault()
        {
            selectedId = 0;
            txtWord.Text = "";
            txtRegex.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Word w=new Word();
            using(Data2Container c=new Data2Container())
            {
                if (selectedId > 0)
                {
                    w = (from l in c.Word where l.Id == selectedId select l).First();
                }
                else
                {
                    if(c.Word.Any(p=>p.Content==txtWord.Text||(p.Regex==txtRegex.Text && string.IsNullOrEmpty(p.Regex)==false)))
                    {
                        MessageBox.Show("Exist");
                        return;
                    }
                }

                w.Content = txtWord.Text;
                w.Regex = txtRegex.Text;

                w.cn = cn.Checked;
                w.an = an.Checked;
                w.on = on.Checked;
                w.pp = pp.Checked;
                w.dp = dp.Checked;
                w.qp = qp.Checked;
                w.tv = tv.Checked;
                w.iv = iv.Checked;
                w.cv = cv.Checked;
                w.nv = nv.Checked;
                w.wv = wv.Checked;
                w.dv = dv.Checked;
                w.adjn = adjn.Checked;
                w.adjs = adjs.Checked;
                w.bno = bno.Checked;
                w.ono = ono.Checked;
                w.cno = cno.Checked;
                w.mno = mno.Checked;
                w.ano = ano.Checked;
                w.nq = nq.Checked;
                w.vq = vq.Checked;
                w.advd = advd.Checked;
                w.advr = advr.Checked;
                w.advt = advt.Checked;
                w.prer = prer.Checked;
                w.pred = pred.Checked;
                w.prepu = preu.Checked;
                w.prec = prec.Checked;
                w.pree = pree.Checked;
                w.conu = conu.Checked;
                w.conp = conp.Checked;
                w.pars = pars.Checked;
                w.part = part.Checked;
                w.parm = parm.Checked;
                w.inth = inth.Checked;
                w.ints = ints.Checked;
                w.inta = inta.Checked;
                w.intsu = intsu.Checked;
                w.intc = intc.Checked;
                w.intr = intr.Checked;
                w.oo = oo.Checked;

                w.favor = Convert.ToInt32(favor.Value);
                w.happy = Convert.ToInt32(happy.Value);
                w.anger = Convert.ToInt32(anger.Value);

                w.ZhuWei = ZhuWei.Checked;
                w.DongBin = DongBin.Checked;
                w.PianZhengDingZhong = PianZhengDingZhong.Checked;
                w.PianZhengZhuangZhong = PianzhengZhuangZhong.Checked;
                w.ZhongBu = ZhongBu.Checked;
                w.LianWei = LianWei.Checked;
                w.JianYu = JianYu.Checked;
                w.TongWei = TongWei.Checked;
                w.FangWei = FangWei.Checked;
                 if (selectedId == 0)
                     c.AddToWord(w);
                c.SaveChanges();

            }
            status.Text = txtWord.Text + " saved.";
            IniDefault();
        }
    }
}
