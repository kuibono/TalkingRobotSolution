using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wisdom.Context
{
    public class ContextUser
    {
        public string Name { get; set; }

        public string Qq { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string CiryName { get; set; }

        public string CardNo { get; set; }

        public List<string> FavFoods { get; set; }

        public List<string> FavPerson { get; set; }

        public List<string> FavMovie { get; set; }

        public List<string> FavSport { get; set; }

        public List<string> FavGame { get; set; }
    }
}
