using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{
    public class DES : Forecast
    {
        public float beta = 0.00f;

        public DES(float alpha, float beta)
        {
            this.alpha = alpha;
            this.beta = beta;

            SmoothenedData = new List<double>();
            InitData();
            ComputeDES();
        }

        private void ComputeDES()
        {
            //𝒔𝒕 = 𝜶𝒙𝒕 + 𝟏 − 𝜶 𝒔𝒕−𝟏 + 𝒃𝒕−𝟏
            //𝒃𝒕 = 𝜷 𝒔𝒕 − 𝒔𝒕−𝟏 + 𝟏 − 𝜷 𝒃𝒕−𝟏
            
            List<double> s = new List<double>();
            List<double> b = new List<double>();

            s.Add(Demand[1]);
            b.Add(Demand[1] - Demand[0]);

            SmoothenedData.Add(s[0] + b[0]); // t=3 == index 2

            for (int i = 3; i < Demand.Count; i++)//begin with (index 3 == t4) compared to (index 0 of DESlist == t3)
            {
                s.Add(alpha * Demand[i] + (1 - alpha) * (s[i - 3] + b[i - 3]));
                b.Add(beta * (s[i - 2] - s[i - 3]) + (1 - beta) * b[i - 3]);

                SmoothenedData.Add(s[i - 3] + b[i - 3]); //
            }

            //forecast
            //𝒇𝒕+𝟏 = 𝒔𝒕 + 𝒃𝒕
            for (int i = Demand.Count; i < Time.Count; i++)
            {
                SmoothenedData.Add(s.Last() + (i - Demand.Count) * b.Last());
            }

            CalculateError();
        }
        protected override void CalculateError()
        {
            double error = 0;

            for (int i = 2; i < Demand.Count; i++)//compare index 0 with 2
            {
                error += Math.Pow(Demand[i] - SmoothenedData[i - 2], 2);

            }
            error = error / (Demand.Count - 1);

            error = Math.Sqrt(error);

            this.error = error;
        }
        //private void CalculateError()
        //{
        //    double error = 0;

        //    for (int i = 0; i < Demand.Count; i++)
        //    {
        //        error += Demand[i] - SmoothenedData[i];
        //    }

        //    error = Math.Pow(error, 2);
        //    error = error / Demand.Count - 1;

        //    error = Math.Sqrt(error);

        //    this.error = error;
        //    //if (error < this.error && alpha < 1 && beta < 1)
        //    //{
        //    //    this.error = error;
        //    //    alpha += 0.1f;
        //    //    beta += 0.1f;
        //    //    Reset();
        //    //}
        //}

        //private void Reset()
        //{
        //    SmoothenedData.Clear();
        //    ComputeDES();
        //}
    }
}
