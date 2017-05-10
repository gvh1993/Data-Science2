using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_science_user_item
{
    class User_Item
    {
        Dictionary<int, Dictionary<int, float>> ratings;

        public User_Item()
        {
            ratings = new Dictionary<int, Dictionary<int, float>>();
            InitData();
        }

        private void InitData()
        {
            using (FileStream fileStream = File.OpenRead("userItem.data"))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',');

                        int userId = Convert.ToInt32(line[0]);
                        int item = Convert.ToInt32(line[1]);
                        float rate = float.Parse(line[2], CultureInfo.InvariantCulture.NumberFormat);
                        
                        ////check if user exist
                        if (ratings.ContainsKey(userId))
                        {
                            // if key already exist
                            ratings[userId].Add(item, rate);
                        }
                        else
                        {
                            Dictionary<int, float> rating = new Dictionary<int, float>();
                            rating.Add(item, rate);
                            ratings.Add(userId, rating);
                        }
                        
                        
                    }
                }
            }
            Euclidean euclidean = new Euclidean(ratings);
            var euclideanDistance = euclidean.CalculateEuclideanDistance(ratings.First(), ratings.Last());

            Pearson pearson = new Pearson(ratings);
            var pearsonDistance = pearson.CalculateDistance(ratings.First(), ratings.Last());

            Console.WriteLine("Euclidean similatiry:");
            Console.WriteLine(euclidean.CalculateSimilarity(euclideanDistance));
            Console.WriteLine();
            Console.WriteLine("Pearson similarity:");
            Console.WriteLine(pearsonDistance);
            Console.Read();
        }
    }
}
