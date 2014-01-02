using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wisdom.Context
{
    public class TalkingContext
    {
        public TalkingUserInfo UserInfo { get; set; }

        /// <summary>
        /// 对话
        /// </summary>
        public List<string> Words { get; set; }

        public TalkingType TalkingType { get; set; }



    }
}
