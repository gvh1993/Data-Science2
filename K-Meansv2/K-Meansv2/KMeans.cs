using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Meansv2
{
    class KMeans
    {
        private DataProvider _dataProvider;
        private ErrorCalculator _errorCalculator;

        public KMeans(DataProvider dataProvider, ErrorCalculator errorCalculator)
        {
            _dataProvider = dataProvider;
            _errorCalculator = errorCalculator;
        }
        public List<Cluster> FindClosestCentroid(List<Cluster> clusters, double[][] centroids)
        {
            //ClearClusterWineData();
            //iterate over winematrix vectors to calculate distance and assign to cluster/centroid
            foreach (int[] wineVector in _dataProvider.WineMatrix)
            {
                double[] closestCentroid = { };
                double minDistanceToCentroid = Double.MaxValue;

                foreach (double[] centroid in centroids) //loop thourgh all clusters to check distance with its centroid
                {
                    double distance = _errorCalculator.CalculateDistance(wineVector, centroid);

                    if (distance < minDistanceToCentroid)
                    {
                        closestCentroid = centroid;
                        minDistanceToCentroid = distance;
                    }
                }

                //add vector to closest cluster
                Cluster theChosenCluster = clusters.Find(x => x.Centroid == closestCentroid); //find cluster with the saved centroid
                theChosenCluster.WineData.Add(wineVector);
            }
            return clusters;
        }

        public List<Cluster> ComputeCentroids(List<Cluster> clusters)
        {
            foreach (Cluster cluster in clusters)
            {
                //check if wineData exists
                if (cluster.WineData.Count == 0)
                {
                    continue;
                }

                //plus 
                int[] meanCalculation = new int[_dataProvider.Columns];

                foreach (int[] wineVector in cluster.WineData)
                {
                    meanCalculation = meanCalculation.Select((x, index) => x + wineVector[index]).ToArray();

                }
                for (int i = 0; i < meanCalculation.Length; i++)
                {
                    var meanCalcNumber = meanCalculation[i];
                    double calcNumber = Convert.ToDouble(meanCalcNumber);

                    cluster.Centroid[i] = calcNumber / cluster.WineData.Count;
                }
            }

            return clusters;
        }
    }
}
