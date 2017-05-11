using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_science_user_item.Enums;

namespace Data_science_user_item
{
    class User_Item
    {
        Dictionary<int, Dictionary<int, float>> ratings;
        Dictionary<int, Dictionary<int, float>> testData;

        public int UserId { get; set; }
        public int TopNeighbours { get; set; }
        public double Threshold { get; set; }
        public SimilarityComputations Algorithm { get; set; }

        ISimilarityComputation similairtyComputationAbility;

        KeyValuePair<int, Dictionary<int, float>> chosenUser;

        public User_Item(Dictionary<int, Dictionary<int, float>> ratings, Dictionary<int, Dictionary<int, float>> testData, int userId, float threshold, int topNeighbours, SimilarityComputations algorithm)
        {
            this.ratings = ratings;
            this.testData = testData;
            UserId = userId;
            TopNeighbours = topNeighbours;
            Threshold = threshold;
            Algorithm = algorithm;

            chosenUser = ratings.SingleOrDefault(x => x.Key == userId);

            Execute();
        }
        
        public void Execute() {
            Dictionary<int, double> nearestNeighbours = new Dictionary<int, double>();

            switch (Algorithm)
            {
                case SimilarityComputations.Euclidean:
                    similairtyComputationAbility = new Euclidean();
                    //loop through all keys except the one inserted
                    foreach (var otherUser in ratings)
                    {
                        if (otherUser.Key == UserId)
                        {
                            continue;
                        }
                        double similarity = similairtyComputationAbility.CalculateSimilarity(chosenUser, otherUser);
                        if (similarity > Threshold) //check if its higher than threshold
                        {
                            if (nearestNeighbours.Count < TopNeighbours) // check if theres room in list
                            {
                                nearestNeighbours.Add(otherUser.Key, similarity);
                            }
                            else //if there is no more room --> change threshold and check if its higher than that
                            {
                                Threshold = nearestNeighbours.Select(x => x.Value).Min();
                                if (similarity > Threshold)
                                {
                                    int toBeRemovedKey = nearestNeighbours.OrderBy(kvp => kvp.Value).First().Key;
                                    nearestNeighbours.Remove(toBeRemovedKey);

                                    nearestNeighbours.Add(otherUser.Key, similarity);
                                }
                            }
                        }
                    }
                    
                    
                    Console.WriteLine("Recommendations:");
                    foreach (var nearNeighbour in nearestNeighbours.OrderBy(x => x.Value))
                    {
                        Console.WriteLine("User: " + nearNeighbour.Key);
                    }

                    break;

                case SimilarityComputations.Manhattan:
                    similairtyComputationAbility = new Manhattan();
                    Console.WriteLine("Manhattan similarity:");
                    Console.WriteLine(similairtyComputationAbility.CalculateSimilarity(testData.First(), testData.Last()));
                    Console.WriteLine();
                    break;

                case SimilarityComputations.Pearson:
                    similairtyComputationAbility = new Pearson();
                    Console.WriteLine("Pearson similarity:");
                    Console.WriteLine(similairtyComputationAbility.CalculateSimilarity(testData.First(), testData.Last()));
                    Console.WriteLine();
                    break;

                case SimilarityComputations.Cosine:
                    similairtyComputationAbility = new Cosine();
                    Console.WriteLine("Cosine similarity");
                    Console.WriteLine(similairtyComputationAbility.CalculateSimilarity(testData.First(), testData.Last()));
                    break;
                default:
                    break;
            }
            

            

            

            
        }
    }
}
