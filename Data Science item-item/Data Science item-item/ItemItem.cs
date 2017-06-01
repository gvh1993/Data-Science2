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

        public ItemItem()
        {
            UserData = new DataProvider().InitRatings();
            Predicting predict = new Predicting(UserData);
            
        }
    }
}
