using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science_item_item.Models
{
    class Deviation
    {
        public List<int> Users { get; set; }
        public int Item { get; set; }


        public Deviation()
        {
              Users = new List<int>();                    
        }
    }
}
