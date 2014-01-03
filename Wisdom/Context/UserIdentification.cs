using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Wisdom.Struct;

namespace Wisdom.Context
{
    public class UserIdentification
    {
        public bool GetUserNameFromWords(TalkingContext context)
        {
            Match m = new Regex(@"我(是|叫)(?<key>[\S]+)[\s]*", RegexOptions.IgnoreCase).Match(context.LastWords.Words);
            if (m.Success)
            {
                string name = m.Groups["key"].Value;
                name = name.Replace("你", "");

                if (Relatives.Relatices.Contains(name))
                {
                    if (context.WordsToResponse == null)
                        context.WordsToResponse = new List<string>();

                    context.WordsToResponse.Add("回答错误，重新回答！");
                    context.WordsToResponse.Add("开玩笑吧？我没有" + name);
                    context.WordsToResponse.Add("... 你怎么这样");
                }
                else//用户提供了正确的名称
                {
                    if (context.User == null)
                        context.User = new ContextUser();
                    if (string.IsNullOrEmpty(context.User.Name))
                    {
                        context.User.Name = name;
                        if (context.WordsToResponse == null)
                            context.WordsToResponse = new List<string>();
                        context.WordsToResponse.Add("你好，" + name + " .我是" + Env.GetServerName());
                        context.WordsToResponse.Add(name + "哦.我记住了");
                        return true;
                    }
                    else
                    {
                        context.WordsToResponse.Add("不是吧？之前不是说你是" + context.User.Name + "吗？");
                        context.WordsToResponse.Add("啊？那你到底是" + context.User.Name + "还是" + name + "啊？");
                    }
                }
            }
            return false;
        }

        public bool GetQQFromWords(TalkingContext context)
        {
            Match m = new Regex(@"(q)?(?<key>[\d]{5,10})+(q)?", RegexOptions.IgnoreCase).Match(context.LastWords.Words);
            if (m.Success)
            {
                string qq = m.Groups["key"].Value;
                if (string.IsNullOrEmpty(context.User.Qq))
                {
                    context.User.Qq = qq;
                    return true;
                }
            }
            return false;
        }
    }
}
