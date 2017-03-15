using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{
    public class SES : Forecast
    {
        public SES()
        {
            SmoothenedData = new List<int>();

            InitData();
            ComputeSES();

        }

        private void ComputeSES()
        {
            //take first 12
            //float s1 = 0.1f;

            //for (int i = 0; i < 12; i++)
            //{
            //    s1 += Demand[i];
            //}

            //s1 /= 12;
            //SmoothenedData.Add(s1);

            SmoothenedData.Add(Demand[0]);

            for (int i = 1; i < Demand.Count; i++)
            {
                SmoothenedData.Add(Convert.ToInt32(alpha * Demand[i - 1] + (1 - alpha) * SmoothenedData[i - 1]));
            }

            //forecast
            for (int i = Demand.Count + 1; i < Time.Count; i++)
            {
                SmoothenedData.Add(SmoothenedData.Last());
            }

            CalculateError();
        }

        private void CalculateError()
        {
            double error = 0;

            for (int i = 0; i < Demand.Count; i++)
            {
                error += Demand[i] - SmoothenedData[i];
            }

            error = Math.Pow(error, 2);
            error = error / Demand.Count - 1;

            error = Math.Sqrt(error);
            if (error < this.error)
            {
                this.error = error;
                alpha += 0.1f;
                Reset();
            }
        }

        private void Reset()
        {
            SmoothenedData.Clear();
            ComputeSES();
        }
    }
}
