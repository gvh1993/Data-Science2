using Data_science_user_item.SimilairtyComputation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    class Manhattan : FilteredSimilarityComputation, ISimilarityComputation
    {
        public double CalculateSimilarity(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            var filteredPersons = Filter(person1, person2);

            double distance = 0;

            foreach (var ratingPerson1 in filteredPersons[person1.Key])
            {
                distance += Math.Abs(ratingPerson1.Value - filteredPersons[person2.Key][ratingPerson1.Key]);
            }

            return 1 / (1 + distance);
        }
        //private Dictionary<int, Dictionary<int, float>> Filter(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        //{
        //    // check the items in common and return it in a filtered dictionary
        //    Dictionary<int, Dictionary<int, float>> filteredPersons = new Dictionary<int, Dictionary<int, float>>
        //    {
        //        { person1.Key, new Dictionary<int, float>() { } },
        //        { person2.Key, new Dictionary<int, float>() { } }
        //    };

        //    foreach (var ratingPerson1 in person1.Value)
        //    {
        //        foreach (var ratingPerson2 in person2.Value)
        //        {
        //            if (ratingPerson1.Key == ratingPerson2.Key) //check if both persons have rated the same things
        //            {
        //                //add it to new dictionary.value with respect to key
        //                filteredPersons[person1.Key].Add(ratingPerson1.Key, ratingPerson1.Value);
        //                filteredPersons[person2.Key].Add(ratingPerson2.Key, ratingPerson2.Value);
        //            }
        //        }
        //    }

        //    return filteredPersons;
        //}
    }
    
}
