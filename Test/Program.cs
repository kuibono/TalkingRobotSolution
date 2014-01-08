using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataAccess;
using Wisdom;

namespace Test
{
    class Program
    {

        public static List<List<string>> SpWords(string str)
        {
            using (Data2Container c = new Data2Container())
            {
                List<List<string>> result = new List<List<string>>();
                for (int i = 0; i < str.Length; i++)
                {
                    List<string> words = new List<string>();
                    for (int j = str.Length - i; j > 0; j--)
                    {
                        string str1 = str.Substring(i, j);
                        if (c.Word.Any(p => p.Content == str1))
                        {
                            words.Add(str1);
                        }
                    }
                    result.Add(words);
                }
                return result;
            }

        }
        static void Main(string[] args)
        {



            using (Data2Container c = new Data2Container())
            {
                string s = "我去吃饭了";

                var sr = SpWords(s);
                Console.ReadLine();

            }






            return;
            while (true)
            {
                string input = Console.ReadLine().Trim();
                input = WordsProcess.UserWordsProcess(input);
                if (input == "weathertest")
                {
                    Wisdom.ServiceHelper.Svc.GetWeatherByName("大连");
                }

                if (input == "addcity")
                {
                    Ini i = new Ini();
                    i.TryAddSomeCitys();
                }

                if (input == "初始化全部数据")
                {
                    Ini i = new Ini();
                    i.InitialAll();
                }
                if (input == "learning")
                {
                    Learning();
                }

                using (DataContainer c = new DataContainer())
                {
                    var temps = c.QuestionTemplate.ToList();

                    QuestionTemplate findedQuestion = null;
                    string key = "";
                    foreach (QuestionTemplate temp in temps)
                    {
                        if (Regex.IsMatch(input, temp.Regex))
                        {
                            findedQuestion = temp;
                            key = new Regex(temp.Regex).Match(input).Groups["key"].Value;
                        }
                    }

                    if (findedQuestion == null)
                    {
                        Console.WriteLine("Sorry Can Not Know What That Mean.");
                    }
                    else
                    {
                        string str_q =
                            WordsProcess.ProcessAll(findedQuestion.AnswerTemplate.OrderBy(p => Guid.NewGuid()).First().Answer, key);
                        Console.WriteLine(str_q);
                    }

                }


            }
        }

        private static void Learning()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                using (DataContainer c = new DataContainer())
                {
                    var temps = c.QuestionTemplate.ToList();

                    QuestionTemplate findedQuestion = null;
                    foreach (QuestionTemplate temp in temps)
                    {
                        if (Regex.IsMatch(input, temp.Regex))
                        {
                            findedQuestion = temp;
                        }
                    }

                    if (findedQuestion == null)
                    {
                        Console.WriteLine("answer:");
                        string str_a = Console.ReadLine();

                        List<AnswerTemplate> OtherAnswers = new List<AnswerTemplate>();

                        Console.WriteLine("onther answer:");
                        string str_other_answer = Console.ReadLine().Trim();
                        while (string.IsNullOrEmpty(str_other_answer) == false)
                        {
                            AnswerTemplate ans = new AnswerTemplate();
                            ans.Answer = str_other_answer;
                            c.AddToAnswerTemplate(ans);
                            OtherAnswers.Add(ans);
                            str_other_answer = Console.ReadLine().Trim();
                        }

                        Console.WriteLine("Possible questrion:");
                        string str_reg = Console.ReadLine();

                        QuestionTemplate q = new QuestionTemplate();
                        if (string.IsNullOrEmpty(str_reg))
                        {
                            q.Regex = input;
                        }
                        else
                        {
                            q.Regex = str_reg;
                        }
                        c.AddToQuestionTemplate(q);

                        AnswerTemplate a = new AnswerTemplate();
                        a.Answer = str_a;
                        a.QuestionTemplate = q;
                        c.AddToAnswerTemplate(a);

                        foreach (AnswerTemplate answerTemplate in OtherAnswers)
                        {
                            answerTemplate.QuestionTemplate = q;
                        }

                        c.SaveChanges();
                        Console.WriteLine("ok ,I got it.");

                    }
                    else
                    {
                        Console.WriteLine(WordsProcess.ProcessAll(findedQuestion.AnswerTemplate.OrderBy(p => Guid.NewGuid()).First().Answer));

                        List<AnswerTemplate> OtherAnswers = new List<AnswerTemplate>();
                        Console.WriteLine("onther answer:");
                        string str_other_answer = Console.ReadLine().Trim();
                        while (string.IsNullOrEmpty(str_other_answer) == false)
                        {
                            AnswerTemplate ans = new AnswerTemplate();
                            ans.Answer = str_other_answer;
                            c.AddToAnswerTemplate(ans);
                            OtherAnswers.Add(ans);
                            ans.QuestionTemplate = findedQuestion;
                            str_other_answer = Console.ReadLine().Trim();
                        }
                        c.SaveChanges();
                    }
                }
            }
        }
    }
}
