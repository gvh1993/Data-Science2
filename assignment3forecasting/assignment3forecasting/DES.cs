using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{
    public class DES : Forecast
    {
        public float beta = 0.1f;

        public DES()
        {
            SmoothenedData = new List<int>();
            InitData();
            ComputeDES();
        }

        private void ComputeDES()
        {
            //𝒔𝒕 = 𝜶𝒙𝒕 + 𝟏 − 𝜶 𝒔𝒕−𝟏 + 𝒃𝒕−𝟏
            //𝒃𝒕 = 𝜷 𝒔𝒕 − 𝒔𝒕−𝟏 + 𝟏 − 𝜷 𝒃𝒕−𝟏
            //𝒇𝒕+𝟏 = 𝒔𝒕 + 𝒃𝒕
            List<int> s = new List<int>();
            List<int> b = new List<int>();

            s.Add(Demand[1]);
            b.Add(Demand[1] - Demand[0]);

            SmoothenedData.Add(s[0] + b[0]);

            for (int i = 3; i < Demand.Count; i++)
            {
                s.Add(Convert.ToInt32(alpha * Demand[i] + (1 - alpha) * (s[i - 3] + b[i - 3])));
                b.Add(Convert.ToInt32(beta * (s[i - 2] - s[i - 3]) + (1 - beta) * b[i - 3]));

                SmoothenedData.Add(s[i - 2] + b[i - 2]);
            }

            //forecast
            for (int i = Demand.Count + 1; i < Time.Count; i++)
            {
                SmoothenedData.Add(s.Last() + (i - Demand.Count) * b.Last());
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
            if (error < this.error && alpha < 1 && beta < 1)
            {
                this.error = error;
                alpha += 0.1f;
                beta += 0.1f;
                Reset();
            }
        }

        private void Reset()
        {
            SmoothenedData.Clear();
            ComputeDES();
        }
    }
}
