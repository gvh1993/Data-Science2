using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    interface ISimilarityComputation
    {
        double CalculateSimilarity(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2);
    }

}
