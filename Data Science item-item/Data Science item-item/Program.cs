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
            //input for user
            do
            {
                var first = ratings.Keys.Min();
                var last = ratings.Keys.Max();
                Console.WriteLine("Choose a user between " + first + " and " + last);
                Int32.TryParse(Console.ReadLine(), out userId);
            }
            while (userId < ratings.Keys.Min() || userId > ratings.Keys.Max() && ratings.ContainsKey(userId));

            int item = 0;
            do
            {

                Console.WriteLine("Choose an item to predict");
                Int32.TryParse(Console.ReadLine(), out item);
                var user = ratings[userId];
                
            }
            while (ratings[userId].ContainsKey(item));


            ItemItem itemItem = new ItemItem(ratings, userId, item);
        }
    }
}
