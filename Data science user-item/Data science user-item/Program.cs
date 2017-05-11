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
                Console.WriteLine("Choose a user between " + ratings.Keys.First() + " and " + ratings.Keys.Last());
                Int32.TryParse(Console.ReadLine(), out userId);
            }
            while (userId < ratings.Keys.First() || userId > ratings.Keys.Last());


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
                Console.WriteLine("How many tops u want to search for? " + ratings.Keys.First() + " - " + (ratings.Keys.Last() -1));
                Int32.TryParse(Console.ReadLine(), out topNeihbours);
            }
            while (topNeihbours < ratings.Keys.First() || topNeihbours >= ratings.Keys.Last());

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

            User_Item userItem = new User_Item(ratings, testData, userId, threshold, topNeihbours, (SimilarityComputations)algorithm);

            Console.Read();
        }


    }
}
