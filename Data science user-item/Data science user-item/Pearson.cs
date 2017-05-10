using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    class Pearson : SimilarityComputation
    {
        public Pearson(Dictionary<int, Dictionary<int, float>> ratings) : base(ratings)
        {
        }

        public double CalculateDistance(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            var filteredPersons = Filter(person1, person2);
            //part1
            double part1 = 0;

            //part2
            double part2a = 0;
            double part2b = 0;

            //part3
            double part3a = 0;
            double part3b = 0;

            //part4
            double part4a = 0;
            double part4b = 0;

            

            foreach (var item in filteredPersons[person1.Key])
            {
                var item1 = item.Value;
                var item2 = filteredPersons[person2.Key][item.Key];

                part1 += item1 * item2;
                part2a += item1;
                part2b += item2;
                part3a += Math.Pow(item1, 2);
                part3b += item1;
                part4a += Math.Pow(item2, 2);
                part4b += item2;
            }
            part3b = Math.Pow(part3b, 2);
            part4b = Math.Pow(part4b, 2);

            var a = part1;
            var b = (part2a * part2b) / filteredPersons[person1.Key].Count;
            var c = Math.Sqrt(part3a - (part3b / filteredPersons[person1.Key].Count));
            var d = Math.Sqrt(part4a - (part4b / filteredPersons[person1.Key].Count));
            var result = (a - b) / (c * d);
            return result;
        }
    }
}
