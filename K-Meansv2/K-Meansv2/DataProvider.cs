using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Meansv2
{
    class DataProvider
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[][] WineMatrix { get; set; }


        public DataProvider()
        {
            InitData();
        }
        void InitData()
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
            Rows = lines.Count;
            foreach (var vector in lines)
            {
                foreach (var point in vector)
                {
                    Columns++;
                }
                break;
            }

            WineMatrix = new int[Rows][];
            WineMatrix = lines.ToArray();
        }
    }
}
