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
            //Prediction prediction = new Prediction();
            Dictionary<int, double> summation = new Dictionary<int, double>();
            double totalSimilarity = 0;

            foreach (var neighbour in NearestNeighbours)
            {
                foreach (var rating in neighbour.Ratings)
                {
                    try
                    {
                        summation.Add(rating.Key, 0);
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }
            }

            foreach (var neighbour in NearestNeighbours)
            {
                totalSimilarity += neighbour.Similarity;

                foreach (var rating in neighbour.Ratings)
                {
                    summation[rating.Key] += rating.Value*neighbour.Similarity;
                }
            }

            Dictionary<int, double> prediction = new Dictionary<int, double>();
            foreach (var item in summation)
            {
                //devide by total similarity
                var pred = item.Value / totalSimilarity;
                prediction.Add(item.Key, pred);
            }

            return prediction;
        }
    }
}
