namespace StudentInfoSystem
{
    partial class DataVisualize
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbChart = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChartBack = new System.Windows.Forms.Button();
            this.txtTotalStd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 65);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(759, 345);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.Chart1_Click);
            // 
            // cmbChart
            // 
            this.cmbChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChart.FormattingEnabled = true;
            this.cmbChart.Items.AddRange(new object[] {
            "Pie",
            "Pyramid",
            "Line"});
            this.cmbChart.Location = new System.Drawing.Point(360, 22);
            this.cmbChart.Name = "cmbChart";
            this.cmbChart.Size = new System.Drawing.Size(121, 21);
            this.cmbChart.TabIndex = 6;
            this.cmbChart.SelectedIndexChanged += new System.EventHandler(this.CmbChart_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(197, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Choose Chart Type";
            // 
            // btnChartBack
            // 
            this.btnChartBack.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnChartBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartBack.Location = new System.Drawing.Point(633, 431);
            this.btnChartBack.Name = "btnChartBack";
            this.btnChartBack.Size = new System.Drawing.Size(122, 25);
            this.btnChartBack.TabIndex = 7;
            this.btnChartBack.Text = "Back To Home";
            this.btnChartBack.UseVisualStyleBackColor = false;
            this.btnChartBack.Click += new System.EventHandler(this.BtnChartBack_Click);
            // 
            // txtTotalStd
            // 
            this.txtTotalStd.Enabled = false;
            this.txtTotalStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalStd.Location = new System.Drawing.Point(321, 433);
            this.txtTotalStd.Name = "txtTotalStd";
            this.txtTotalStd.Size = new System.Drawing.Size(100, 22);
            this.txtTotalStd.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Number of Students:";
            // 
            // DataVisualize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 467);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalStd);
            this.Controls.Add(this.btnChartBack);
            this.Controls.Add(this.cmbChart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chart1);
            this.MaximumSize = new System.Drawing.Size(818, 506);
            this.MinimumSize = new System.Drawing.Size(818, 506);
            this.Name = "DataVisualize";
            this.Text = "DataVisualize";
            this.Load += new System.EventHandler(this.DataVisualize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cmbChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChartBack;
        private System.Windows.Forms.TextBox txtTotalStd;
        private System.Windows.Forms.Label label1;
    }
}