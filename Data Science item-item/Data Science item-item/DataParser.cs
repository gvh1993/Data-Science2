using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data_Science_item_item.Models;

namespace Data_Science_item_item
{
    class DataParser
    {
        private readonly Dictionary<int, Dictionary<int, float>> _userData;
        public DataParser(Dictionary<int, Dictionary<int, float>> userData)
        {
            _userData = userData;
        }

        public List<ItemObject> ComputeDeviationObjects(List<ItemObject> itemObjects )
        {
            foreach (ItemObject itemObject1 in itemObjects)
            {
                foreach (ItemObject itemObject2 in itemObjects)
                {

                    itemObject1.DeviationObjects.Add(ComputeDeviation(itemObject1, itemObject2));
                }
            }

            return itemObjects;
        }

        private DeviationObject ComputeDeviation(ItemObject item1, ItemObject item2)
        {
            DeviationObject deviationObject = new DeviationObject {OtherItemId = item2.Item};

            float summation = 0;

            //get the users who rated them both
            foreach (var userRating in item1.Users)
            {
                if (item2.Users.ContainsKey(userRating.Key))
                {
                    summation += userRating.Value - item2.Users[userRating.Key];
                    deviationObject.Card++;
                }
            }
            deviationObject.Deviation = (summation/deviationObject.Card);

            return deviationObject;
        }

        public List<ItemObject> ConvertUserdataToItemObjects()
        {
           var itemObjects = new List<ItemObject>();

            //init objects based on item
            foreach (var user in _userData)
            {
                foreach (var rating in user.Value)
                {

                    var deviation = itemObjects.Find(x => x.Item == rating.Key);
                    if (deviation == null)
                    {
                        ItemObject dev = new ItemObject { Item = rating.Key };
                        dev.Users.Add(user.Key, rating.Value);

                        itemObjects.Add(dev);
                    }
                    else
                    {
                        deviation.Users.Add(user.Key, rating.Value);
                    }
                }
            }

            return itemObjects;
        }
    }
}
