using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science_item_item.Models
{
    class ItemObject
    {
        public Dictionary<int, float> Users { get; set; }//format: [userId, rating]
        public int Item { get; set; }
        public List<DeviationObject> DeviationObjects { get; set; }

        public ItemObject()
        {
            Users = new Dictionary<int, float>();   
            DeviationObjects = new List<DeviationObject>();            
        }
    }
}
