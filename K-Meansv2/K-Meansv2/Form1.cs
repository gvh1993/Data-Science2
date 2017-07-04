using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace K_Meansv2
{
    public partial class Form1 : Form
    {
        Random r;
        private double[][] centroids;
        DataProvider dataProvider;
        ErrorCalculator errorCalculator;

        private List<Cluster> clusters;
        
        private List<List<Cluster>> history;
        private List<Cluster> bestClusters;

        int amountOfClusters, amountOfIterations, amountOfRuns;
        

        public Form1()
        {

            history = new List<List<Cluster>>();
            r = new Random();

            dataProvider = new DataProvider();
            errorCalculator = new ErrorCalculator(dataProvider);
            //wineMatrix = dataProvider.WineMatrix;
            //rows = 0;
            //columns = 0;

            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                //start algorithm
                Reset();
                //InitiateVectors();
                //InitCentroids();
                KMeans();
                PrintOutput();
            }
        }

        private void Reset()
        {
            //rows = 0;
            //columns = 0;
            lbl_bestSSE.Text = "Best SSE:";
            history.Clear();
        }

        private bool ValidateFields()
        {
            lbl_error.Text = "";
            if (!Int32.TryParse(txt_amountOfClusters.Text, out amountOfClusters))
            {
                lbl_error.Text += "Amount of clusters, ";
                return false;
            }
            if (!Int32.TryParse(txt_amountOfIterations.Text, out amountOfIterations))
            {
                lbl_error.Text += "Amount of Iterations";
                return false;
            }
            if (!Int32.TryParse(txt_amountOfRuns.Text, out amountOfRuns))
            {
                lbl_error.Text += "Amount of Runs";
                return false;
            }
            return true;
        }

        //private void InitiateVectors()
        //{
        //    List<int[]> lines;

        //    using (var fileStream = File.OpenRead("WineData.csv"))
        //    {
        //        using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
        //        {
        //            lines = new List<int[]>();
        //            while (!reader.EndOfStream)
        //            {
        //                int[] line = reader.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        //                lines.Add(line);
        //            }
        //        }
        //    }

        //    //set rows and columns count
        //    rows = lines.Count;
        //    foreach (var vector in lines)
        //    {
        //        foreach (var point in vector)
        //        {
        //            columns++;
        //        }
        //        break;
        //    }

        //    wineMatrix = new int[rows][];
        //    wineMatrix = lines.ToArray();
        //}

        private void InitCentroids()
        {
            centroids = new double[amountOfClusters][];
            clusters = new List<Cluster>();

            //random initialize centroids
            
            for (int i = 0; i < amountOfClusters; i++)
            {
                centroids[i] = new double[dataProvider.Columns];
                Cluster cluster = new Cluster();

                for (int j = 0; j < dataProvider.Columns; j++)
                {
                    //only 0 or 1
                    centroids[i][j] = r.Next(0, 2);
                }
                cluster.Centroid = centroids[i];
                clusters.Add(cluster);
            }
        }

        //private double CalculateDistance(int[] vector, double[] centroid)
        //{
        //    double distance = 0;

        //    // double[] powerValues = {};
        //    //calculate pow and add to distance
        //    for (int i = 0; i < dataProvider.Columns; i++)
        //    {
        //        //powerValues[i] = Math.Pow(vector[i] - centroid[i], 2);
        //        distance += Math.Pow(vector[i] - centroid[i], 2);
        //    }

        //    return Math.Sqrt(distance);
        //}

        //private void FindClosestCentroid()
        //{
        //    ClearClusterWineData();
        //    //iterate over winematrix vectors to calculate distance and assign to cluster/centroid
        //    foreach (int[] wineVector in dataProvider.WineMatrix)
        //    {
        //        double[] closestCentroid = { };
        //        double minDistanceToCentroid = Double.MaxValue;

        //        foreach (double[] centroid in centroids)
        //        {
        //            double distance = CalculateDistance(wineVector, centroid);

        //            if (distance < minDistanceToCentroid)
        //            {
        //                closestCentroid = centroid;
        //                minDistanceToCentroid = distance;
        //            }
        //        }

        //        //add vector to closest cluster
        //        Cluster theChosenCluster = clusters.Find(x => x.Centroid == closestCentroid);
        //        theChosenCluster.WineData.Add(wineVector);
        //    }
        //}

        //private void ComputeCentroids()
        //{
        //    foreach (Cluster cluster in clusters)
        //    {
        //        //check if wineData exists
        //        if (cluster.WineData.Count == 0)
        //        {
        //            continue;
        //        }

        //        //plus 
        //        int[] meanCalculation = new int[dataProvider.Columns];

        //        foreach (int[] wineVector in cluster.WineData)
        //        {
        //            meanCalculation = meanCalculation.Select((x, index) => x + wineVector[index]).ToArray();

        //        }
        //        for (int i = 0; i < meanCalculation.Length; i++)
        //        {
        //            var meanCalcNumber = meanCalculation[i];
        //            double calcNumber = Convert.ToDouble(meanCalcNumber);

        //            cluster.Centroid[i] = calcNumber / cluster.WineData.Count;
        //        }
        //    }
        //}

        private void ClearClusterWineData()
        {
            foreach (var cluster in clusters)
            {
                cluster.WineData = new List<int[]>();
            }
        }

        private void PrintClusters()
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

        //private double SSE(List<Cluster> clusters)
        //{
        //    // voor elke cluster moet je de distance van de vector naar de centroid
        //    double distance = 0;

        //    foreach (var cluster in clusters)
        //    {
        //        //per centroid/cluster de distance berekenen van de vectors
        //        foreach (var wineData in cluster.WineData)
        //        {
        //            distance += CalculateDistance(wineData, cluster.Centroid);
        //        }
        //    }
        //    return distance;
        //}

        private void Silhouette()
        {
            //TODO implement silhouette
        }

        private void KMeans()
        {
            KMeans kmeans = new KMeans(dataProvider, errorCalculator);
            for (int i = 0; i < amountOfRuns; i++)
            {
                InitCentroids();

                for (int j = 0; j <= amountOfIterations; j++)
                {
                    ClearClusterWineData();
                    var updatedClusters = kmeans.FindClosestCentroid(clusters, centroids);
                    clusters = kmeans.ComputeCentroids(updatedClusters);
                }
                // TODO add clusters to history
                List<Cluster> savedCluster = new List<Cluster>(clusters);
                history.Add(savedCluster);
                
                clusters.Clear();

            }
            // TODO get best from history and set to chosenCluster
            GetBestClusters();
        }

        private void GetBestClusters()
        {
            List<Cluster> bestClusters = new List<Cluster>();
            double fittest = Double.MaxValue;
            foreach (var clusters in history)
            {
                var SSE = errorCalculator.SSE(clusters);
                if (SSE < fittest)
                {
                    bestClusters = clusters;
                    fittest = SSE;
                }
            }
            Console.WriteLine(fittest);
            this.bestClusters = bestClusters;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            
            listView2.Items.Clear();
            listView3.Items.Clear();
            //get cluster from cluster list by getting the number
            string[] listViewItem = listView1.SelectedItems[0].Text.Split(' ');
            Cluster chosenCluster = bestClusters[Convert.ToInt32(listViewItem[1]) - 1];

            Console.WriteLine(listView1.SelectedItems[0].Text);
            lbl_amountOfItemsInCluster.Text = "Amount of items in cluster: " + chosenCluster.WineData.Count;
            List<int> amountBought = new List<int>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

            for (int i = 0; i < chosenCluster.WineData.Count; i++)
            {
                string client = "client #" + i + " buys offer: " ;
                for (int j = 0; j < dataProvider.Columns; j++)
                {
                    if (chosenCluster.WineData[i][j] == 1)
                    {
                        client += j + ", ";
                        amountBought[j] += 1;
                    }

                }

                ListViewItem item = new ListViewItem();
                item.Text = client;
                listView2.Items.Add(item);

            }

            for (int i = 0; i < amountBought.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = $"Offer {(i + 1)} --> bought {amountBought[i]} times";
                listView3.Items.Add(item);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintOutput()
        {
            lbl_bestSSE.Text += errorCalculator.SSE(bestClusters);
            listView1.Clear();
            listView2.Clear();
            listView3.Clear();

            for (int i = 0; i < amountOfClusters; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "cluster " + (i + 1);
                listView1.Items.Add(item);
            }
        }
    }
}
