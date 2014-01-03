using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wisdom.Context;

namespace Wisdom
{
    public class WordsProcess
    {

        public static string UserWordsProcess(string strWords)
        {
            strWords = strWords.Replace("今天天气", Env.GetUserCity() + "天气");
            strWords = strWords.Replace("你那", Env.GetServerCiry());
            strWords = strWords.Replace("你那里", Env.GetServerCiry());
            strWords = strWords.Replace("你那边", Env.GetServerCiry());
            return strWords;
        }

        public static string ProcessAll(string strWords, string par = "")
        {
            strWords = strWords.Replace("{nowdate}", DateTime.Now.ToString("M月d号"));
            strWords = strWords.Replace("{nowtime}", DateTime.Now.ToString("h点mm分"));

            if (strWords.Contains("getweather({key})") && string.IsNullOrEmpty(par) == false)
            {
                strWords = strWords.Replace("getweather({key})", ServiceHelper.Svc.GetWeatherByName(par));
            }


            return strWords;
        }
    }
}
