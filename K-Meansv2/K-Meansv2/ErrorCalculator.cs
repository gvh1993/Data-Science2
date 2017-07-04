using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Meansv2
{
    class ErrorCalculator
    {
        private DataProvider _dataProvider;
        public ErrorCalculator(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public double CalculateDistance(int[] vector, double[] centroid)
        {
            double distance = 0;

            // double[] powerValues = {};
            //calculate pow and add to distance
            for (int i = 0; i < _dataProvider.Columns; i++)
            {
                //powerValues[i] = Math.Pow(vector[i] - centroid[i], 2);
                distance += Math.Pow(vector[i] - centroid[i], 2);
            }

            return Math.Sqrt(distance);
        }

        public double SSE(List<Cluster> clusters)
        {
            // voor elke cluster moet je de distance van de vector naar de centroid
            double distance = 0;

            foreach (var cluster in clusters)
            {
                //per centroid/cluster de distance berekenen van de vectors
                foreach (var wineData in cluster.WineData)
                {
                    distance += CalculateDistance(wineData, cluster.Centroid);
                }
            }
            return distance;
        }
    }
}
