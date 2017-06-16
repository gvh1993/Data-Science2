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

            //parse the data to itemObjects
            DataParser parser = new DataParser(UserData);
            var itemObjects = parser.ConvertUserdataToItemObjects();
            var itemObjectsWithDeviation = parser.ComputeDeviationObjects(itemObjects);

            //predict 
            ItemObject chosenItem = itemObjectsWithDeviation.Find(x => x.Item == item);
            var chosenUserData = UserData[userId];

            Predicting predict = new Predicting(chosenItem, chosenUserData);
            Console.WriteLine("Predicting:");
            Console.WriteLine("User: " + userId);
            Console.WriteLine("Item: " + item);
            Console.WriteLine(predict.Predict());
            Console.Read();
        }
    }
}
