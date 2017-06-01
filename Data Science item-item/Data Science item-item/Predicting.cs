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

        public Predicting(Dictionary<int, Dictionary<int, float>> userData)
        {
            _userData = userData;
            CalculateDeviationMatrix();
        }

        void CalculateDeviationMatrix()
        {
            List<Deviation> deviations = new List<Deviation>();

            List<int> items = new List<int>();
            List<int> users = _userData.Keys.Distinct().ToList();

            //foreach (var rating in from user in _userData from rating in user.Value where !items.Contains(rating.Key) select rating)
            //{
            //    deviations.Add(new Deviation() {Item = rating.Key});
            //    items.Add(rating.Key);
            //}


            foreach (var user in _userData)
            {
                
                foreach (var rating in user.Value)
                {
                    if (!items.Contains(rating.Key))
                        items.Add(rating.Key);


                    var deviation = deviations.Find(x => x.Item == rating.Key);
                    deviation.Users.Add(user.Key);
                }
            }


        }
    }
}
