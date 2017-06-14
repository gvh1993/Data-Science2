using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Science_item_item.Models;

namespace Data_Science_item_item
{
    class ItemItem
    {
        private Dictionary<int, Dictionary<int, float>> UserData { get; set; }

        public ItemItem(Dictionary<int, Dictionary<int, float>> userData, int userId, int item)
        {
            UserData = userData;
            Predicting predict = new Predicting(UserData, userId, item);
            
        }
    }
}
