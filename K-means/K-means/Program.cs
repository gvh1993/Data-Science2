using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;


namespace K_means
{
    class Program
    {
        private static int[][] wineMatrix;
        private static double[][] centroids;
        private static int rows = 0;
        private static int columns = 0;
        private static List<Cluster> clusters;
        private static int amountCentroids = 4;
        static void Main(string[] args)
        {
            InitiateVectors();
            InitCentroids();
            KMeans(10);
        }


        private static void InitiateVectors()
        {
            List<int[]> lines;

            using (var fileStream = File.OpenRead("WineData.csv"))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                {
                    lines = new List<int[]>();
                    while (!reader.EndOfStream)
                    {
                        int[] line = reader.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                        lines.Add(line);
                    }
                }
            }

            //set rows and columns count
            rows = lines.Count;
            foreach (var vector in lines)
            {
                foreach (var point in vector)
                {
                    columns++;
                }
                break;
            }

            wineMatrix = new int[rows][];
            wineMatrix = lines.ToArray();
        }

        private static void InitCentroids()
        {
            centroids = new double[amountCentroids][];
            clusters = new List<Cluster>();

            //random initialize centroids
            Random r = new Random();
            for (int i = 0; i < amountCentroids; i++)
            {
                centroids[i] = new double[columns];
                Cluster cluster = new Cluster();

                for (int j = 0; j < columns; j++)
                {
                    centroids[i][j] = r.Next(0, 2);
                }
                cluster.Centroid = centroids[i];
                clusters.Add(cluster);
            }
        }

        //TODO CALCULATE HOW MANY CENTROIDS
        private static double CalculateDistance(int[] vector, double[] centroid)
        {
            double distance = 0;

           // double[] powerValues = {};
            //calculate pow and add to distance
            for (int i = 0; i < columns; i++)
            {
                    //powerValues[i] = Math.Pow(vector[i] - centroid[i], 2);
                    distance += Math.Pow(vector[i] - centroid[i], 2);
            }
            
            //calculate sqrt
            //for (int i = 0; i < columns; i++)
            //{
            //    distance += powerValues[i];
            //}

            return Math.Sqrt(distance);
        }

        private static void FindClosestCentroid()
        {
            //iterate over winematrix vectors to calculate distance and assign to cluster/centroid
            foreach (int[] wineVector in wineMatrix)
            {
                double[] closestCentroid = {};
                double minDistanceToCentroid = Double.MaxValue;

                foreach (double[] centroid in centroids)
                {
                    double distance = CalculateDistance(wineVector, centroid);

                    if (distance < minDistanceToCentroid)
                    {
                        closestCentroid = centroid;
                        minDistanceToCentroid = distance;
                    }
                }

                //add vector to closest cluster
                Cluster theChosenCluster = clusters.Find(x => x.Centroid == closestCentroid);
                theChosenCluster.WineData.Add(wineVector);
            }
        }

        private static void ComputeCentroids()
        {
            foreach (Cluster cluster in clusters)
            {
                //check if wineData exists
                if (cluster.WineData.Count == 0)
                {
                    continue;
                }

                //plus 
                int[] meanCalculation = new int[columns];
                
                foreach (int[] wineVector in cluster.WineData)
                {
                    meanCalculation = meanCalculation.Select((x, index) => x + wineVector[index]).ToArray();

                }
                for (int i = 0; i < meanCalculation.Length; i++)
                {
                    var meanCalcNumber = meanCalculation[i];
                    double calcNumber = Convert.ToDouble(meanCalcNumber);

                    cluster.Centroid[i] = calcNumber/cluster.WineData.Count;
                }
            }
        }

        private static void ClearClusterWineData()
        {
            foreach (var cluster in clusters)
            {
                cluster.WineData = new List<int[]>();
            }
        }

        private static void PrintClusters()
        {
            for (int i = 0; i < clusters.Count; i++)
            {
                var cluster = clusters[i];
                Console.Write("Cluster " + i);

                Console.WriteLine();
                foreach (var wineData in cluster.WineData)
                {
                    for (int q = 0; q < wineData.Length; q++)
                    {
                        Console.Write(wineData[q]);
                    }
                    Console.WriteLine();
                }
            }
            
            
            Console.Read();
        }

        private static double SSE()
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

        private static void KMeans(int iterations)
        {
            for (int i = 0; i <= iterations; i++)
            {
                FindClosestCentroid();
                ComputeCentroids();
                Console.WriteLine("Total Distance:" + SSE());
                if (i != iterations)
                {
                    ClearClusterWineData();
                }
                else
                {
                    PrintClusters();
                }
                
            }
        }
    }
}
