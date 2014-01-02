using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wisdom.Context
{
    /// <summary>
    /// 心情
    /// </summary>
    public class Mood
    {

        public string Name { get; set; }

        /// <summary>
        /// 好或者坏
        /// </summary>
        public int Cent { get; set; }

        /// <summary>
        /// 程度
        /// </summary>
        public int Degree { get; set; }
    }
}
