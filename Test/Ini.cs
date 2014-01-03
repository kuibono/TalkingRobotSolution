using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Object = DataAccess.Object;

namespace Test
{
    public class Ini
    {

        private void w(string str)
        {
            Console.WriteLine(str);
        }

        public void InitialDefaultUser()
        {
            using (DataContainer c = new DataContainer())
            {
                User u = new User();
                u.Birth = DateTime.Now;
                u.Height = 10;
                u.Weight = 10;
                u.QQ = "363212404";
                u.Male = true;
                u.Married = false;

            }
        }

        private void addZhou(string name)
        {
            using (DataContainer c = new DataContainer())
            {
                var zhou = (from l in c.Category
                            where l.Id == 42
                            select l).First();//洲
                Object z1 = new Object();
                z1.Category.Add(zhou);
                z1.Name = name;
                z1.Remark = "";
                c.AddToObject(z1);
                
                c.SaveChanges();

                w("保存：" + name);
            }
        }

        private void addCountry(string zhou, string name)
        {
            using (DataContainer c = new DataContainer())
            {
                var guo = (from l in c.Category
                           where l.Id == 43
                           select l).First();//洲
                Object z1 = new Object();
                z1.Category.Add(guo);
                z1.Name = name;
                z1.Remark = "";
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "国家",Value = ""});
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "洲", Value = zhou });
                c.AddToObject(z1);
                c.SaveChanges();

                w("保存：" + name);
            }
        }

        private void addProvince(string country,string name)
        {
            using (DataContainer c = new DataContainer())
            {
                var sheng = (from l in c.Category
                           where l.Id == 81
                           select l).First();//省
                Object z1 = new Object();
                z1.Category.Add(sheng);
                z1.Name = name;
                z1.Remark = "";
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "省", Value = "" });
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "国家", Value = country });
                c.AddToObject(z1);
                c.SaveChanges();

                w("保存：" + name);
            }
        }

        private void addCity(string province,string name)
        {
            using (DataContainer c = new DataContainer())
            {
                var sheng = (from l in c.Category
                             where l.Id == 82
                             select l).First();//城市
                Object z1 = new Object();
                z1.Category.Add(sheng);
                z1.Name = name;
                z1.Remark = "";
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "城市", Value = "" });
                z1.ObjectPropty.Add(new ObjectPropty() { Name = "省", Value = province });
                c.AddToObject(z1);
                c.SaveChanges();

                w("保存：" + name);
            }
        }

        public void TryAddSomeCitys()
        {
            using (DataContainer c = new DataContainer())
            {
                addZhou("亚洲");
                addZhou("非洲");
                addZhou("欧洲");
                addZhou("南美洲");
                addZhou("北美洲");
                addZhou("大洋洲");
                addZhou("南极洲");


                addCountry("亚洲","中国");

                addCountry("亚洲", "日本");
                addProvince("中国", "辽宁");
                addProvince("中国", "北京");

                addCity("辽宁","沈阳");
                addCity("辽宁", "大连");
            }

        }


        public void InitialAll()
        {
            w("Initialling all...");
            IniActions();

            IniQuestionTemplate();

            w("Initialling all finished.");
        }

        private void IniActions()
        {
            //using (DataContainer c = new DataContainer())
            //{
            //    ResponseAction a = new ResponseAction();
            //    a.Name = "搜索";
            //    c.AddToResponseAction(a);

            //    c.SaveChanges();
            //}

        }

        private void IniQuestionTemplate()
        {
            w("Initialling question template...");
            using (DataContainer c = new DataContainer())
            {
                QuestionTemplate q1 = new QuestionTemplate();
                q1.Regex = @"(今天|现在)几号";
                c.AddToQuestionTemplate(q1);

                AnswerTemplate a1 = new AnswerTemplate();
                a1.Answer = "{nowdate}";
                c.AddToAnswerTemplate(a1);

                AnswerTemplate a11 = new AnswerTemplate();
                a11.Answer = "今天应该是{nowdate}";
                c.AddToAnswerTemplate(a11);

                QuestionTemplate q2 = new QuestionTemplate();
                q2.Regex = @"(现在)?几点";
                c.AddToQuestionTemplate(q2);

                AnswerTemplate a2 = new AnswerTemplate();
                a2.Answer = "{nowtime}";
                c.AddToAnswerTemplate(a2);

                AnswerTemplate a21 = new AnswerTemplate();
                a21.Answer = "差不多{nowtime}的样子";
                c.AddToAnswerTemplate(a21);


                q1.AnswerTemplate.Add(a1);
                q1.AnswerTemplate.Add(a11);


                q2.AnswerTemplate.Add(a2);
                q2.AnswerTemplate.Add(a21);


                c.SaveChanges();
            }


            w("Initialling question template complete.");
        }
    }
}
