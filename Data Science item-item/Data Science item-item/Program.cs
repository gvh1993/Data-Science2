using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science_item_item
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<int, float>> ratings = new DataProvider().InitRatings();
            //welke user
            //welke item

            int userId = 0;
            bool succeededParseUserId;
            //input for user
            do
            {
                var first = ratings.Keys.Min();
                var last = ratings.Keys.Max();
                Console.WriteLine("Choose a user between " + first + " and " + last);
                succeededParseUserId = Int32.TryParse(Console.ReadLine(), out userId);
            }
            while (userId < ratings.Keys.Min() || userId > ratings.Keys.Max() && !ratings.ContainsKey(userId) && succeededParseUserId);


            int topRecommendations;
            bool succeededParseRecommendation;
            do
            {
                Console.WriteLine("How many recommendations do you want?");
                succeededParseRecommendation = Int32.TryParse(Console.ReadLine(), out topRecommendations);
            }
            while (!succeededParseRecommendation);

            ItemItem itemItem = new ItemItem(ratings, userId, topRecommendations);
        }
    }
}
