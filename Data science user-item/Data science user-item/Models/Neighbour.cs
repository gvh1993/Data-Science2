using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item.Models
{
    class Neighbour
    {
        public int UserId { get; set; }
        public Dictionary<int, float> Ratings { get; set; }
        public double Similarity { get; set; }
    }
}
