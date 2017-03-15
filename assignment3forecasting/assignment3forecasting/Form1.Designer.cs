namespace assignment3forecasting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_SES = new System.Windows.Forms.Label();
            this.lbl_SES_alpha = new System.Windows.Forms.Label();
            this.lbl_SES_error = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_DES_alpha = new System.Windows.Forms.Label();
            this.lbl_DES_beta = new System.Windows.Forms.Label();
            this.lbl_DES_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "SES";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(21, 27);
            this.chart1.Name = "chart1";
            series1.ChartArea = "SES";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Data";
            series2.ChartArea = "SES";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "SES";
            series3.ChartArea = "SES";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "DES";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1389, 587);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // lbl_SES
            // 
            this.lbl_SES.AutoSize = true;
            this.lbl_SES.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SES.Location = new System.Drawing.Point(34, 637);
            this.lbl_SES.Name = "lbl_SES";
            this.lbl_SES.Size = new System.Drawing.Size(31, 13);
            this.lbl_SES.TabIndex = 1;
            this.lbl_SES.Text = "SES";
            // 
            // lbl_SES_alpha
            // 
            this.lbl_SES_alpha.AutoSize = true;
            this.lbl_SES_alpha.Location = new System.Drawing.Point(37, 654);
            this.lbl_SES_alpha.Name = "lbl_SES_alpha";
            this.lbl_SES_alpha.Size = new System.Drawing.Size(39, 13);
            this.lbl_SES_alpha.TabIndex = 2;
            this.lbl_SES_alpha.Text = "alpha: ";
            // 
            // lbl_SES_error
            // 
            this.lbl_SES_error.AutoSize = true;
            this.lbl_SES_error.Location = new System.Drawing.Point(37, 671);
            this.lbl_SES_error.Name = "lbl_SES_error";
            this.lbl_SES_error.Size = new System.Drawing.Size(34, 13);
            this.lbl_SES_error.TabIndex = 3;
            this.lbl_SES_error.Text = "error: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DES";
            // 
            // lbl_DES_alpha
            // 
            this.lbl_DES_alpha.AutoSize = true;
            this.lbl_DES_alpha.Location = new System.Drawing.Point(177, 654);
            this.lbl_DES_alpha.Name = "lbl_DES_alpha";
            this.lbl_DES_alpha.Size = new System.Drawing.Size(36, 13);
            this.lbl_DES_alpha.TabIndex = 5;
            this.lbl_DES_alpha.Text = "alpha:";
            // 
            // lbl_DES_beta
            // 
            this.lbl_DES_beta.AutoSize = true;
            this.lbl_DES_beta.Location = new System.Drawing.Point(177, 670);
            this.lbl_DES_beta.Name = "lbl_DES_beta";
            this.lbl_DES_beta.Size = new System.Drawing.Size(31, 13);
            this.lbl_DES_beta.TabIndex = 6;
            this.lbl_DES_beta.Text = "beta:";
            // 
            // lbl_DES_error
            // 
            this.lbl_DES_error.AutoSize = true;
            this.lbl_DES_error.Location = new System.Drawing.Point(177, 687);
            this.lbl_DES_error.Name = "lbl_DES_error";
            this.lbl_DES_error.Size = new System.Drawing.Size(31, 13);
            this.lbl_DES_error.TabIndex = 7;
            this.lbl_DES_error.Text = "error:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 876);
            this.Controls.Add(this.lbl_DES_error);
            this.Controls.Add(this.lbl_DES_beta);
            this.Controls.Add(this.lbl_DES_alpha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_SES_error);
            this.Controls.Add(this.lbl_SES_alpha);
            this.Controls.Add(this.lbl_SES);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_SES;
        private System.Windows.Forms.Label lbl_SES_alpha;
        private System.Windows.Forms.Label lbl_SES_error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_DES_alpha;
        private System.Windows.Forms.Label lbl_DES_beta;
        private System.Windows.Forms.Label lbl_DES_error;
    }
}

