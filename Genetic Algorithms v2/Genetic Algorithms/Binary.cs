using System;
using System.Linq;

namespace Genetic_Algorithms
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

        public override string ToString()
        {
            string BitString = "";
            foreach (var bit in BitArray.Reverse())
            {
                if (bit)
                {
                    BitString += "1 ";
                }
                else
                {
                    BitString += "0 ";
                }
                
            }
            return "Fittness: " + Fitness + " BitArray: " + BitString + " (" + CalculateBinaryCode() + " bits)";
        }
    }
}

