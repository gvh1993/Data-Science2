using System;
using System.Collections.Generic;

namespace Data_science_user_item.SimilairtyComputation
{
    public class Euclidean : FilteredSimilarityComputation, ISimilarityComputation
    {
        public double CalculateSimilarity(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            var filteredPersons = Filter(person1, person2);

            double squaredDistance = 0;
            // iterate per item from person1 to person 2 and calculate the distance
            foreach (var item in filteredPersons[person1.Key])
            {
                var item1 = item.Value;
                var item2 = filteredPersons[person2.Key][item.Key];
                squaredDistance += Math.Pow((item1 - item2), 2);
            }
            
            return 1 / (1 + Math.Sqrt(squaredDistance));
        }


    }
}
