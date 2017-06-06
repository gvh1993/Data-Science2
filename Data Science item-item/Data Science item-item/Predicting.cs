using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Science_item_item.Models;

namespace Data_Science_item_item
{
    class Predicting
    {
        //Format: user, [item, rating]
        private readonly Dictionary<int, Dictionary<int, float>> _userData;
        public List<ItemObject> ItemObjects { get; set; }

        public Predicting(Dictionary<int, Dictionary<int, float>> userData)
        {
            _userData = userData;
            CalculateDeviationMatrix();
            Console.WriteLine(Predict(7, 101));
            Console.Read();
        }

        void CalculateDeviationMatrix()
        {
            ItemObjects = new List<ItemObject>();

            List<int> items = new List<int>();
            List<int> users = _userData.Keys.Distinct().ToList();

            //init objects based on item
            foreach (var user in _userData)
            {
                foreach (var rating in user.Value)
                {
                    if (!items.Contains(rating.Key))
                        items.Add(rating.Key);


                    var deviation = ItemObjects.Find(x => x.Item == rating.Key);
                    if (deviation == null)
                    {
                        ItemObject dev = new ItemObject {Item = rating.Key};
                        dev.Users.Add(user.Key, rating.Value);

                        ItemObjects.Add(dev);
                    }
                    else
                    {
                        deviation.Users.Add(user.Key, rating.Value);
                    }
                }
            }

            items.Sort();
            users.Sort();

            //float[,] matrix = new float[users.Count, items.Count];

            for (int i = 0; i < ItemObjects.Count; i++)
            {
                for (int j = 0; j < ItemObjects.Count; j++)
                {
                    var dev1 = ItemObjects[i];
                    var dev2 = ItemObjects[j];

                    float deviationsummation = 0;
                    float card = 0;

                    //get the users who rated them both
                    foreach (var dev1User in dev1.Users)
                    {
                        foreach (var dev2User in dev2.Users)
                        {
                            if (dev1User.Key == dev2User.Key)
                            {
                                deviationsummation += dev1User.Value - dev2User.Value;
                                card++;
                            }
                        }
                    }

                    var deviation = (deviationsummation/card);
                    
                   //dev1.Deviations.Add(dev2.Item, deviation);
                   dev1.DeviationObjects.Add(new DeviationObject() {OtherItemId = dev2.Item, Deviation = deviation, Card = card}); 
                }
            }
        }

        float Predict(int user, int item)
        {
            float numerator = 0;
            float denominator = 0;
            ItemObject itemObject = ItemObjects.Find(x => x.Item == item);
            var userRatings = _userData[user];

            foreach (var rating in userRatings)
            {
                var deviation = itemObject.DeviationObjects.Find(x => x.OtherItemId == rating.Key);
                //var x = rating.Value;
                //var  = itemObject.DeviationObjects.Find(x => x.OtherItemId == rating.Key);
                //var minus = rating - 
                numerator += (rating.Value + deviation.Deviation)*deviation.Card;
                denominator += deviation.Card;
            }

            return numerator/denominator;
        }
    }
}
