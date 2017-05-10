﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    public abstract class SimilarityComputation
    {
        Dictionary<int, Dictionary<int, float>> ratings;
        public SimilarityComputation(Dictionary<int, Dictionary<int, float>> ratings)
        {
            this.ratings = ratings;
        }

        protected Dictionary<int, Dictionary<int, float>> Filter(KeyValuePair<int, Dictionary<int, float>> person1, KeyValuePair<int, Dictionary<int, float>> person2)
        {
            // check the items in common and return it in a filtered dictionary
            Dictionary<int, Dictionary<int, float>> filteredPersons = new Dictionary<int, Dictionary<int, float>>
            {
                { person1.Key, new Dictionary<int, float>() { } },
                { person2.Key, new Dictionary<int, float>() { } }
            };

            foreach (var ratingPerson1 in person1.Value)
            {
                foreach (var ratingPerson2 in person2.Value)
                {
                    if (ratingPerson1.Key == ratingPerson2.Key) //check if both persons have rated the same things
                    {
                        //add it to new dictionary.value with respect to key
                        filteredPersons[person1.Key].Add(ratingPerson1.Key, ratingPerson1.Value);
                        filteredPersons[person2.Key].Add(ratingPerson2.Key, ratingPerson2.Value);
                    }
                }
            }

            return filteredPersons;
        }

        public double CalculateSimilarity(double distance)
        {
            return 1 / (1 + distance);
        }

    }
}
