using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data_science_user_item.Enums;
using Data_science_user_item.Models;
using Data_science_user_item.SimilairtyComputation;

namespace Data_science_user_item
{
    class UserItem
    {
        readonly Dictionary<int, Dictionary<int, float>> _ratings;
        Dictionary<int, Dictionary<int, float>> _testData;

        public int UserId { get; set; }
        public int TopNeighbours { get; set; }
        public double Threshold { get; set; }
        public SimilarityComputations Algorithm { get; set; }

        ISimilarityComputation _similairtyComputationAbility;

        readonly KeyValuePair<int, Dictionary<int, float>> _chosenUser;

        public UserItem(Dictionary<int, Dictionary<int, float>> ratings, Dictionary<int, Dictionary<int, float>> testData, int userId, float threshold, int topNeighbours, SimilarityComputations algorithm)
        {
            _ratings = ratings;
            _testData = testData;
            UserId = userId;
            TopNeighbours = topNeighbours;
            Threshold = threshold;
            Algorithm = algorithm;

            _chosenUser = ratings.SingleOrDefault(x => x.Key == userId);

            Execute();
        }

        public void Execute()
        {
            switch (Algorithm)
            {
                case SimilarityComputations.Euclidean:
                    _similairtyComputationAbility = new Euclidean();
                    break;

                case SimilarityComputations.Manhattan:
                    _similairtyComputationAbility = new Manhattan();
                    break;

                case SimilarityComputations.Pearson:
                    _similairtyComputationAbility = new Pearson();
                    Console.WriteLine();
                    break;

                case SimilarityComputations.Cosine:
                    _similairtyComputationAbility = new Cosine();
                    break;
                default:
                    break;
            }

            CalculatePredictions(CalculateTopNeighbours());
        }

        List<Neighbour> CalculateTopNeighbours()
        {
            List<Neighbour> nearestNeighbours = new List<Neighbour>();
            //Dictionary<int, double> nearestNeighbours = new Dictionary<int, double>();

            //loop through all keys except the one inserted
            foreach (var otherUser in _ratings)
            {
                if (otherUser.Key == UserId)
                {
                    continue;
                }

                double similarity = _similairtyComputationAbility.CalculateSimilarity(_chosenUser, otherUser);
                if (!(similarity > Threshold)) continue;

                Neighbour neighbour = new Neighbour
                {
                    UserId = otherUser.Key,
                    Ratings = otherUser.Value,
                    Similarity = similarity
                };

                if (nearestNeighbours.Count < TopNeighbours) // check if theres room in list
                {
                    //nearestNeighbours.Add(otherUser.Key, similarity);
                    nearestNeighbours.Add(neighbour);
                }
                else //if there is no more room --> change threshold and check if its higher than that
                {
                    Threshold = nearestNeighbours.Select(x => x.Similarity).Min();
                    if (!(similarity > Threshold)) continue;

                    //nearestNeighbours.RemovOrderBy(n => n.Similarity).First();
                    nearestNeighbours.Remove(nearestNeighbours.OrderBy(x => x.Similarity).First());

                    //nearestNeighbours.Add(otherUser.Key, similarity);
                    nearestNeighbours.Add(neighbour);
                }
            }

            Console.WriteLine("Recommendations:");
            foreach (var nearNeighbour in nearestNeighbours.OrderByDescending(x => x.Similarity))
            {
                Console.WriteLine("User: " + nearNeighbour.UserId + "  with similarity: " + nearNeighbour.Similarity);
            }

            //calculate prediction:
            return nearestNeighbours;
        }

        void CalculatePredictions(List<Neighbour> nearestNeighbours)
        {
            Predicting predict = new Predicting(nearestNeighbours, _chosenUser);
            var predictions = predict.Predict(); 

        }
    }
}
