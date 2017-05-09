namespace K_Meansv2
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
            this.lbl_amountOfClusters = new System.Windows.Forms.Label();
            this.lbl_amountOfIterations = new System.Windows.Forms.Label();
            this.txt_amountOfClusters = new System.Windows.Forms.TextBox();
            this.txt_amountOfIterations = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lbl_bestSSE = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_amountOfItemsInCluster = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lbl_amountOfClusters
            // 
            this.lbl_amountOfClusters.AutoSize = true;
            this.lbl_amountOfClusters.Location = new System.Drawing.Point(56, 100);
            this.lbl_amountOfClusters.Name = "lbl_amountOfClusters";
            this.lbl_amountOfClusters.Size = new System.Drawing.Size(221, 25);
            this.lbl_amountOfClusters.TabIndex = 0;
            this.lbl_amountOfClusters.Text = "Amount of clusters (k)";
            // 
            // lbl_amountOfIterations
            // 
            this.lbl_amountOfIterations.AutoSize = true;
            this.lbl_amountOfIterations.Location = new System.Drawing.Point(56, 222);
            this.lbl_amountOfIterations.Name = "lbl_amountOfIterations";
            this.lbl_amountOfIterations.Size = new System.Drawing.Size(203, 25);
            this.lbl_amountOfIterations.TabIndex = 1;
            this.lbl_amountOfIterations.Text = "Amount of Iterations";
            // 
            // txt_amountOfClusters
            // 
            this.txt_amountOfClusters.Location = new System.Drawing.Point(61, 140);
            this.txt_amountOfClusters.Name = "txt_amountOfClusters";
            this.txt_amountOfClusters.Size = new System.Drawing.Size(100, 31);
            this.txt_amountOfClusters.TabIndex = 2;
            this.txt_amountOfClusters.Text = "4";
            // 
            // txt_amountOfIterations
            // 
            this.txt_amountOfIterations.Location = new System.Drawing.Point(61, 263);
            this.txt_amountOfIterations.Name = "txt_amountOfIterations";
            this.txt_amountOfIterations.Size = new System.Drawing.Size(100, 31);
            this.txt_amountOfIterations.TabIndex = 3;
            this.txt_amountOfIterations.Text = "20";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(61, 353);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(216, 62);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(61, 456);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(0, 25);
            this.lbl_error.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(419, 80);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(332, 764);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // lbl_bestSSE
            // 
            this.lbl_bestSSE.AutoSize = true;
            this.lbl_bestSSE.Location = new System.Drawing.Point(414, 9);
            this.lbl_bestSSE.Name = "lbl_bestSSE";
            this.lbl_bestSSE.Size = new System.Drawing.Size(109, 25);
            this.lbl_bestSSE.TabIndex = 7;
            this.lbl_bestSSE.Text = "Best SSE:";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(810, 80);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(658, 1248);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(805, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selected cluster:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Clusters:";
            // 
            // lbl_amountOfItemsInCluster
            // 
            this.lbl_amountOfItemsInCluster.AutoSize = true;
            this.lbl_amountOfItemsInCluster.Location = new System.Drawing.Point(805, 9);
            this.lbl_amountOfItemsInCluster.Name = "lbl_amountOfItemsInCluster";
            this.lbl_amountOfItemsInCluster.Size = new System.Drawing.Size(265, 25);
            this.lbl_amountOfItemsInCluster.TabIndex = 11;
            this.lbl_amountOfItemsInCluster.Text = "Amount of Items in cluster:";
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(1536, 80);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(731, 1248);
            this.listView3.TabIndex = 12;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2372, 1400);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.lbl_amountOfItemsInCluster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.lbl_bestSSE);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_amountOfIterations);
            this.Controls.Add(this.txt_amountOfClusters);
            this.Controls.Add(this.lbl_amountOfIterations);
            this.Controls.Add(this.lbl_amountOfClusters);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_amountOfClusters;
        private System.Windows.Forms.Label lbl_amountOfIterations;
        private System.Windows.Forms.TextBox txt_amountOfClusters;
        private System.Windows.Forms.TextBox txt_amountOfIterations;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbl_bestSSE;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_amountOfItemsInCluster;
        private System.Windows.Forms.ListView listView3;
    }
}

