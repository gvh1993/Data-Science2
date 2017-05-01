namespace Genetic_Algorithms
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
            this.txt_CrossoverRate = new System.Windows.Forms.TextBox();
            this.txt_MutationRate = new System.Windows.Forms.TextBox();
            this.txt_PopulationSize = new System.Windows.Forms.TextBox();
            this.lbl_CrossoverRate = new System.Windows.Forms.Label();
            this.lbl_MutationRate = new System.Windows.Forms.Label();
            this.lbl_PopulationSize = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_Iterations = new System.Windows.Forms.Label();
            this.txt_Iterations = new System.Windows.Forms.TextBox();
            this.chbx_Elitism = new System.Windows.Forms.CheckBox();
            this.process1 = new System.Diagnostics.Process();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.lbl_AverageFittness = new System.Windows.Forms.Label();
            this.lbl_BestFittness = new System.Windows.Forms.Label();
            this.lbl_BestIndividual = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_CrossoverRate
            // 
            this.txt_CrossoverRate.Location = new System.Drawing.Point(78, 78);
            this.txt_CrossoverRate.Name = "txt_CrossoverRate";
            this.txt_CrossoverRate.Size = new System.Drawing.Size(223, 31);
            this.txt_CrossoverRate.TabIndex = 0;
            this.txt_CrossoverRate.Text = "0.85";
            // 
            // txt_MutationRate
            // 
            this.txt_MutationRate.Location = new System.Drawing.Point(78, 187);
            this.txt_MutationRate.Name = "txt_MutationRate";
            this.txt_MutationRate.Size = new System.Drawing.Size(223, 31);
            this.txt_MutationRate.TabIndex = 1;
            this.txt_MutationRate.Text = "0.01";
            // 
            // txt_PopulationSize
            // 
            this.txt_PopulationSize.Location = new System.Drawing.Point(78, 375);
            this.txt_PopulationSize.MaxLength = 3;
            this.txt_PopulationSize.Name = "txt_PopulationSize";
            this.txt_PopulationSize.Size = new System.Drawing.Size(223, 31);
            this.txt_PopulationSize.TabIndex = 2;
            this.txt_PopulationSize.Text = "25";
            // 
            // lbl_CrossoverRate
            // 
            this.lbl_CrossoverRate.AutoSize = true;
            this.lbl_CrossoverRate.Location = new System.Drawing.Point(73, 50);
            this.lbl_CrossoverRate.Name = "lbl_CrossoverRate";
            this.lbl_CrossoverRate.Size = new System.Drawing.Size(211, 25);
            this.lbl_CrossoverRate.TabIndex = 4;
            this.lbl_CrossoverRate.Text = "Crossover Rate(0..1)";
            // 
            // lbl_MutationRate
            // 
            this.lbl_MutationRate.AutoSize = true;
            this.lbl_MutationRate.Location = new System.Drawing.Point(73, 159);
            this.lbl_MutationRate.Name = "lbl_MutationRate";
            this.lbl_MutationRate.Size = new System.Drawing.Size(202, 25);
            this.lbl_MutationRate.TabIndex = 5;
            this.lbl_MutationRate.Text = "Mutation Rate (0..1)";
            // 
            // lbl_PopulationSize
            // 
            this.lbl_PopulationSize.AutoSize = true;
            this.lbl_PopulationSize.Location = new System.Drawing.Point(73, 347);
            this.lbl_PopulationSize.Name = "lbl_PopulationSize";
            this.lbl_PopulationSize.Size = new System.Drawing.Size(162, 25);
            this.lbl_PopulationSize.TabIndex = 7;
            this.lbl_PopulationSize.Text = "Population Size";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(71, 585);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(230, 45);
            this.btn_Start.TabIndex = 8;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_Iterations
            // 
            this.lbl_Iterations.AutoSize = true;
            this.lbl_Iterations.Location = new System.Drawing.Point(73, 452);
            this.lbl_Iterations.Name = "lbl_Iterations";
            this.lbl_Iterations.Size = new System.Drawing.Size(118, 25);
            this.lbl_Iterations.TabIndex = 9;
            this.lbl_Iterations.Text = "# iterations";
            // 
            // txt_Iterations
            // 
            this.txt_Iterations.Location = new System.Drawing.Point(78, 480);
            this.txt_Iterations.Name = "txt_Iterations";
            this.txt_Iterations.Size = new System.Drawing.Size(223, 31);
            this.txt_Iterations.TabIndex = 10;
            this.txt_Iterations.Text = "20";
            // 
            // chbx_Elitism
            // 
            this.chbx_Elitism.AutoSize = true;
            this.chbx_Elitism.Checked = true;
            this.chbx_Elitism.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_Elitism.Location = new System.Drawing.Point(78, 276);
            this.chbx_Elitism.Name = "chbx_Elitism";
            this.chbx_Elitism.Size = new System.Drawing.Size(107, 29);
            this.chbx_Elitism.TabIndex = 11;
            this.chbx_Elitism.Text = "Elitism";
            this.chbx_Elitism.UseVisualStyleBackColor = true;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(28, 685);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(0, 25);
            this.lbl_Error.TabIndex = 12;
            // 
            // lbl_AverageFittness
            // 
            this.lbl_AverageFittness.AutoSize = true;
            this.lbl_AverageFittness.Location = new System.Drawing.Point(48, 20);
            this.lbl_AverageFittness.Name = "lbl_AverageFittness";
            this.lbl_AverageFittness.Size = new System.Drawing.Size(180, 25);
            this.lbl_AverageFittness.TabIndex = 13;
            this.lbl_AverageFittness.Text = "Average Fittness:";
            // 
            // lbl_BestFittness
            // 
            this.lbl_BestFittness.AutoSize = true;
            this.lbl_BestFittness.Location = new System.Drawing.Point(48, 81);
            this.lbl_BestFittness.Name = "lbl_BestFittness";
            this.lbl_BestFittness.Size = new System.Drawing.Size(143, 25);
            this.lbl_BestFittness.TabIndex = 14;
            this.lbl_BestFittness.Text = "Best Fittness:";
            // 
            // lbl_BestIndividual
            // 
            this.lbl_BestIndividual.AutoSize = true;
            this.lbl_BestIndividual.Location = new System.Drawing.Point(48, 146);
            this.lbl_BestIndividual.Name = "lbl_BestIndividual";
            this.lbl_BestIndividual.Size = new System.Drawing.Size(158, 25);
            this.lbl_BestIndividual.TabIndex = 15;
            this.lbl_BestIndividual.Text = "Best Individual:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_BestIndividual);
            this.panel1.Controls.Add(this.lbl_AverageFittness);
            this.panel1.Controls.Add(this.lbl_BestFittness);
            this.panel1.Location = new System.Drawing.Point(486, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 724);
            this.panel1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 787);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.chbx_Elitism);
            this.Controls.Add(this.txt_Iterations);
            this.Controls.Add(this.lbl_Iterations);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_PopulationSize);
            this.Controls.Add(this.lbl_MutationRate);
            this.Controls.Add(this.lbl_CrossoverRate);
            this.Controls.Add(this.txt_PopulationSize);
            this.Controls.Add(this.txt_MutationRate);
            this.Controls.Add(this.txt_CrossoverRate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_CrossoverRate;
        private System.Windows.Forms.TextBox txt_MutationRate;
        private System.Windows.Forms.TextBox txt_PopulationSize;
        private System.Windows.Forms.Label lbl_CrossoverRate;
        private System.Windows.Forms.Label lbl_MutationRate;
        private System.Windows.Forms.Label lbl_PopulationSize;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_Iterations;
        private System.Windows.Forms.TextBox txt_Iterations;
        private System.Windows.Forms.CheckBox chbx_Elitism;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_BestIndividual;
        private System.Windows.Forms.Label lbl_AverageFittness;
        private System.Windows.Forms.Label lbl_BestFittness;
    }
}

