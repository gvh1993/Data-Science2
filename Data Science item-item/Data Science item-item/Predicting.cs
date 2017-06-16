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
        private readonly Dictionary<int, float> _userData;
        public ItemObject ItemObject { get; set; }

        public Predicting(ItemObject itemObject, Dictionary<int, float> userData)
        {
            _userData = userData;
            ItemObject = itemObject;
        }

        public float Predict()
        {
            float numerator = 0;
            float denominator = 0;

            foreach (var rating in _userData)
            {
                var deviation = ItemObject.DeviationObjects.Find(x => x.OtherItemId == rating.Key);
                if (Single.IsNaN(deviation.Deviation))
                    //NaN happends with deviation calulation if there are no similar raters! so we skip these in the prediction calculation
                    continue;
                

                numerator += (rating.Value + deviation.Deviation)*deviation.Card;
                denominator += deviation.Card;
            }

            return numerator/denominator;
        }
    }
}
