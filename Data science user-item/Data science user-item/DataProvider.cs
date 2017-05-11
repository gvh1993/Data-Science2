using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Data_science_user_item
{
    public class DataProvider
    {
        public Dictionary<int, Dictionary<int, float>> InitRatings()
        {
            Dictionary<int, Dictionary<int, float>> ratings = new Dictionary<int, Dictionary<int, float>>();

            using (FileStream fileStream = File.OpenRead(@"assets/userItem.data"))
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

            return ratings;
        }
        public Dictionary<int, Dictionary<int, float>> InitTestData()
        {
            Dictionary<int, Dictionary<int, float>> testData = new Dictionary<int, Dictionary<int, float>>();

            testData.Add(1, new Dictionary<int, float>());
            testData[1].Add(1, 5);
            testData[1].Add(3, 1);
            testData[1].Add(4, 3);
            testData[1].Add(5, 5);

            testData.Add(2, new Dictionary<int, float>());
            testData[2].Add(1, 2);
            testData[2].Add(2, 5);
            testData[2].Add(3, 4);
            testData[2].Add(4, 3);

            return testData;
        }
    }
}
