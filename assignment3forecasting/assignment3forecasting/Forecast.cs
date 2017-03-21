using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{

    public abstract class Forecast
    {
        protected List<int> Time { get; set; }
        public List<int> Demand { get; set; }

        public List<int> SmoothenedData { get; set; }

        public float alpha = 0.1f;

        public double error = double.MaxValue;


        protected void InitData()
        {
            Time = new List<int>();
            for (int i = 1; i < 49; i++)
            {
                Time.Add(i);
            }
            Demand = new List<int> { 165, 171, 147, 143, 164, 160, 152, 150, 159, 169, 173, 203, 169, 166, 162, 147, 188, 161, 162, 169, 185, 188, 200, 229, 189, 218, 185, 199, 210, 193, 211, 208, 216, 218, 264, 304 };
        }

        protected void CalculateError()
        {
            double error = 0;

            for (int i = 0; i < Demand.Count; i++)
            {
                error += Math.Pow(Demand[i] - SmoothenedData[i], 2);

            }
            error = error / (Demand.Count - 1);

            error = Math.Sqrt(error);

            this.error = error;
        }


    }
}
