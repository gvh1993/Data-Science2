using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    class Cosine : ISimilarityComputation
    {
        public double CalculateSimilarity(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            var filteredPersons = Filter(person1, person2);
            
            double part1 = 0.0;
            double part2 = 0.0;
            double part3 = 0.0;

            foreach (var rating in filteredPersons[person1.Key])
            {
                part1 += (rating.Value * filteredPersons[person2.Key][rating.Key]);
                part2 += Math.Pow(rating.Value, 2);
                part3 += Math.Pow(filteredPersons[person2.Key][rating.Key], 2);
            }

            return part1 / (Math.Sqrt(part2) * Math.Sqrt(part3));
        }

        private Dictionary<int, Dictionary<int, float>> Filter(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            //iterate over person1 and check if the other person also has the key
            foreach (var ratingPerson1 in person1.Value)
            {
                if (!person2.Value.Keys.Any(x => x == ratingPerson1.Key))
                {
                    //key is in person 1 but not in person 2
                    //TODO add key to person2 and value to 0
                    person2.Value.Add(ratingPerson1.Key, 0);
                }
            }

            //iterate over person2 and check if key is in the other person 
            foreach (var ratingPerson2 in person2.Value)
            {
                if (!person1.Value.Keys.Any(x => x == ratingPerson2.Key))
                {
                    //key is in person 1 but not in person 2
                    //TODO add key to person1 and value to 0
                    person1.Value.Add(ratingPerson2.Key, 0);
                }
            }

            Dictionary<int, Dictionary<int, float>> filteredPersons = new Dictionary<int, Dictionary<int, float>>
            {
                { person1.Key, person1.Value },
                { person2.Key, person2.Value }
            };
            return filteredPersons;
        }
    }
}
