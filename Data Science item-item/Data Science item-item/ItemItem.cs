using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Science_item_item.Models;

namespace Data_Science_item_item
{
    class ItemItem
    {
        private Dictionary<int, Dictionary<int, float>> UserData { get; set; }

        public ItemItem(Dictionary<int, Dictionary<int, float>> userData, int userId, int topRecommendations)
        {
            UserData = userData;

            //parse the data to itemObjects
            DataParser parser = new DataParser(UserData);
            var itemObjects = parser.ConvertUserdataToItemObjects();
            var itemObjectsWithDeviation = parser.ComputeDeviationObjects(itemObjects);

            //predict 
            var chosenUserData = UserData[userId];
            Predicting predict = new Predicting(chosenUserData);

            Dictionary<int, float> predictions = new Dictionary<int, float>(); //key = itemId, Value = predictionValue
            //iterate through itemObjectsWithDeviation and perform a prediction
            foreach (var itemObject in itemObjectsWithDeviation)
            {
                float prediction = predict.Predict(itemObject);
                predictions.Add(itemObject.Item, prediction);
            }

            //sort predictions
            var sortedPredictions = predictions.OrderByDescending(x => x.Value).Take(topRecommendations);

            
            Console.WriteLine("top " + topRecommendations + " predictions:");
            Console.WriteLine("User: " + userId);
            foreach (var prediction in sortedPredictions)
            {
                Console.WriteLine(prediction.Key + ": " + prediction.Value);
            }
            Console.Read();
        }
    }
}
