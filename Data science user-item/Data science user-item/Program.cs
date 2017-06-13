using Data_science_user_item.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_science_user_item
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<int, float>> ratings = new DataProvider().InitRatings();
            

            Dictionary<int, Dictionary<int, float>> testData = new DataProvider().InitTestData();

            int userId = 0;
            //input for user
            do
            {
                var first = ratings.Keys.Min();
                var last = ratings.Keys.Max();
                Console.WriteLine("Choose a user between " + first + " and " + last);
                Int32.TryParse(Console.ReadLine(), out userId);
            }
            while (userId < ratings.Keys.Min() || userId > ratings.Keys.Max() && ratings.ContainsKey(userId));


            float threshold = 0;
            do
            {
                Console.WriteLine("How big do u want your threshold? (between 0.10 and 1)");
                float.TryParse(Console.ReadLine(), out threshold);
            }
            while (threshold < 0.1 || threshold > 1);

            int topNeihbours = 0;
            do
            {
                Console.WriteLine("How many top neighbours u want to search for? " + 1 + " - " + ratings.Count);
                Int32.TryParse(Console.ReadLine(), out topNeihbours);
            }
            while (topNeihbours < 1 || topNeihbours >= ratings.Count);

            int topRecommendations = 0;
            do
            {
                Console.WriteLine("How many top recommendations u want to search for? " + 1 + " - " + ratings.Count);
                Int32.TryParse(Console.ReadLine(), out topRecommendations);
            }
            while (topRecommendations < 1 || topRecommendations >= ratings.Count);

            int algorithm = 0;
            do
            {
                Console.WriteLine("Which algorithm would you like to use? (type the number)");
                //Console.WriteLine(SimilarityComputations.Euclidean + " : " + (int)SimilarityComputations.Euclidean);
                foreach (var item in Enum.GetValues(typeof(SimilarityComputations)))
                {
                    Console.WriteLine(item + ":" + (int)item);
                }
                Int32.TryParse(Console.ReadLine(), out algorithm);
            } while (algorithm == 0 || algorithm > 4);

            UserItem userItem = new UserItem(ratings, testData, userId, threshold, topNeihbours, topRecommendations, (SimilarityComputations)algorithm);

            Console.Read();
        }


    }
}
