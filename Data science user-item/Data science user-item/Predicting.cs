using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_science_user_item.Models;

namespace Data_science_user_item
{
    class Predicting
    {
        public List<Neighbour> NearestNeighbours { get; set; }
        public KeyValuePair<int, Dictionary<int, float>> ChosenUser { get; set; }
        public float Summation { get; set; }

        private const int AmountRated = 3;

        public Predicting(List<Neighbour> nearestNeighbours, KeyValuePair<int, Dictionary<int, float>> chosenUser)
        {
            NearestNeighbours = nearestNeighbours;
            ChosenUser = chosenUser;
        }
        //dictionary ID rating
        public Dictionary<int, double> Predict()
        {
            FilterRatings();
            var summation = CalculateSum();

            return summation;
        }

        private void FilterRatings()
        {
            // a list with itemIds which the chosen user already has
            List<int> toBeRemovedItemIDs = (from neighbour in NearestNeighbours from chosenUserRating in ChosenUser.Value from neighbourRating in neighbour.Ratings where chosenUserRating.Key == neighbourRating.Key select neighbourRating.Key).Distinct().ToList();

            //remove from neighbour
            foreach (var neighbour in NearestNeighbours)
            {
                foreach (var itemId in toBeRemovedItemIDs)
                {
                    neighbour.Ratings.Remove(itemId);
                }
            }
        }

        //iterate through neighbours and calculate 
        Dictionary<int, double> CalculateSum()
        {
            Dictionary<int, double> summation = new Dictionary<int, double>(); // <itemID, sum of (rating * similarity of neighbour)>
            Dictionary<int, double> totalSimilarityPerItem = new Dictionary<int, double>(); // <itemID, sum of similarity of neighbours>
            Dictionary<int, int> amountRated = new Dictionary<int, int>(); // keeps up how many times an item is rated

            foreach (var neighbour in NearestNeighbours)
            {
                foreach (var rating in neighbour.Ratings)
                {
                    //initialize summation keys (item ID)
                    //initialize totalSimilarityPerItem keys (Item ID)
                    try
                    {

                        summation.Add(rating.Key, 0);
                        totalSimilarityPerItem.Add(rating.Key, 0);
                        amountRated.Add(rating.Key, 0);
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }

                    summation[rating.Key] += rating.Value * neighbour.Similarity; // add rating * similarity to summation of the item
                    
                    totalSimilarityPerItem[rating.Key] += neighbour.Similarity; // add similarity to item
                    amountRated[rating.Key] += 1;
                }
            }

            //remove amount rated below X
            foreach (var rating in amountRated.Where(rating => rating.Value < AmountRated))
            {
                summation.Remove(rating.Key);
                totalSimilarityPerItem.Remove(rating.Key);
            }

            //predict
            Dictionary<int, double> prediction = new Dictionary<int, double>();
            foreach (var item in summation)
            {
                //devide by total similarity which have rated the item!!
                var pred = item.Value / totalSimilarityPerItem[item.Key];
                prediction.Add(item.Key, pred);
            }
            prediction = prediction.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            return prediction;
        }
    }
}
