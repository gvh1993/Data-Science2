using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm
{
    public class Binary
    {
        public bool[] BitArray = new bool[5];
        public double Fitness { get; set; }


        public int CalculateBinaryCode()
        {
            int summation = 0;
            for (int i = 0; i < BitArray.Length; i++)
            {
                if (BitArray[i])
                {
                    summation += Convert.ToInt32(Math.Pow(2, i));
                }
            }

            return summation;
        }
    }
}
