using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wisdom.Context
{
    public class TalkingContext
    {
        public ContextUser User { get; set; }

        public ContextUser RobotInfo { get; set; }

        /// <summary>
        /// 友好程度
        /// </summary>
        public int Friendly { get; set; }

        public List<UserWords> Words { get; set; }

        public UserWords LastWords { get; set; }

        public List<string> WordsToResponse { get; set; }



        public int RobotMood { get; set; }

        public int UserMood { get; set; }

        public DateTime StartTime { get; set; }


    }
}
