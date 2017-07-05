using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace assignment3forecasting
{
    public partial class Form1 : Form
    {
        public List<int> Time { get; set; }
        public List<int> Demand { get; set; }

        public SES ses;
        public DES des;

        List<SES> SESHistory;
        List<DES> DESHistory;
        public Form1()
        {
            SESHistory = new List<SES>();
            DESHistory = new List<DES>();

            InitializeComponent();
            InitData();
            

            for (int i = 1; i <= 100; i++)//iterate from 0.01 to 1
            {
                float alphaValue = i / 100f;

                SES ses = new SES(alphaValue);
                SESHistory.Add(ses);


                for (int j = 0; j < 100; j++)
                {
                    float betaValue = j / 100f;

                    DES des = new DES(alphaValue, betaValue);
                    DESHistory.Add(des);
                }
            }
            double sesMin = SESHistory.Min(x => x.error);
            ses = SESHistory.Find(x => x.error == sesMin);

            double desMin = DESHistory.Min(x => x.error);
            des = DESHistory.Find(x => x.error == desMin);

            PlotData();
            PlotSESData();
            PlotDESData();

            lbl_SES_alpha.Text += ses.alpha.ToString();
            lbl_SES_error.Text += ses.error.ToString();

            lbl_DES_alpha.Text += des.alpha.ToString();
            lbl_DES_beta.Text += des.beta.ToString();
            lbl_DES_error.Text += des.error.ToString();
        }

        private void InitData()
        {
            Time = new List<int>();
            for (int i = 0; i < 48; i++)
            {
                Time.Add(i);
            }
            Demand = new List<int> { 165, 171, 147, 143, 164, 160, 152, 150, 159, 169, 173, 203, 169, 166, 162, 147, 188, 161, 162, 169, 185, 188, 200, 229, 189, 218, 185, 199, 210, 193, 211, 208, 216, 218, 264, 304 };
        }

        private void PlotData()
        {
            chart1.Series["Data"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas["SES"].AxisX.Title = "Time";
            chart1.ChartAreas["SES"].AxisY.Title = "Demand";
            chart1.ChartAreas["SES"].AxisX.Interval = 1;

            for (int i = 0; i < ses.Demand.Count; i++)
            {
                chart1.Series["Data"].Points.AddXY(i, ses.Demand[i]);
            }
        }

        private void PlotSESData()
        {
            for (int i = 0; i < ses.SmoothenedData.Count; i++)
            {
                chart1.Series["SES"].Points.AddXY(i, ses.SmoothenedData[i]);
            }
        }

        private void PlotDESData()
        {
            for (int i = 0; i < des.SmoothenedData.Count; i++)
            {
                chart1.Series["DES"].Points.AddXY(i + 1, des.SmoothenedData[i]);
            }
        }
    }
}
