using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    public class Cluster
    {
        public List<int[]> WineData { get; set; }
        public double[] Centroid { get; set; }

        public Cluster()
        {
            WineData = new List<int[]>();
        }
    }
}
