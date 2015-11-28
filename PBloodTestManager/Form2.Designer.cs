namespace PBloodTestManager
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1stData = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSave1 = new System.Windows.Forms.Button();
            this.buttonSave2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-29, 62);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Emboss";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.Name = "Glucose";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "DrawingStyle=Emboss";
            series2.Legend = "Legend1";
            series2.Name = "Cholesterol";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "DrawingStyle=Emboss";
            series3.Legend = "Legend1";
            series3.Name = "LDL";
            series4.ChartArea = "ChartArea1";
            series4.CustomProperties = "DrawingStyle=Emboss";
            series4.Legend = "Legend1";
            series4.Name = "HDL";
            series5.ChartArea = "ChartArea1";
            series5.CustomProperties = "DrawingStyle=Emboss, DrawSideBySide=True";
            series5.Legend = "Legend1";
            series5.Name = "Triglycerides";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1368, 223);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // button1stData
            // 
            this.button1stData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1stData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1stData.BackgroundImage")));
            this.button1stData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1stData.Location = new System.Drawing.Point(29, 8);
            this.button1stData.Name = "button1stData";
            this.button1stData.Size = new System.Drawing.Size(63, 48);
            this.button1stData.TabIndex = 2;
            this.button1stData.UseVisualStyleBackColor = false;
            this.button1stData.Click += new System.EventHandler(this.button1stData_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.SystemColors.Control;
            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart2.BackSecondaryColor = System.Drawing.Color.White;
            this.chart2.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(-29, 267);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series6.ChartArea = "ChartArea1";
            series6.CustomProperties = "DrawingStyle=Emboss";
            series6.Legend = "Legend1";
            series6.MarkerBorderColor = System.Drawing.Color.White;
            series6.Name = "Fibrinogen";
            series7.ChartArea = "ChartArea1";
            series7.CustomProperties = "DrawingStyle=Emboss";
            series7.Legend = "Legend1";
            series7.Name = "HemoglobinA1C";
            series8.ChartArea = "ChartArea1";
            series8.CustomProperties = "DrawingStyle=Emboss";
            series8.Legend = "Legend1";
            series8.Name = "DHEA";
            series9.ChartArea = "ChartArea1";
            series9.CustomProperties = "DrawingStyle=Emboss";
            series9.Legend = "Legend1";
            series9.Name = "PSA";
            series10.ChartArea = "ChartArea1";
            series10.CustomProperties = "DrawingStyle=Emboss, DrawSideBySide=True";
            series10.Legend = "Legend1";
            series10.Name = "Homocysteine";
            this.chart2.Series.Add(series6);
            this.chart2.Series.Add(series7);
            this.chart2.Series.Add(series8);
            this.chart2.Series.Add(series9);
            this.chart2.Series.Add(series10);
            this.chart2.Size = new System.Drawing.Size(1386, 223);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.SystemColors.Control;
            this.chart3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart3.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Area3DStyle.IsClustered = true;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(-29, 478);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series11.ChartArea = "ChartArea1";
            series11.CustomProperties = "DrawingStyle=Emboss";
            series11.Legend = "Legend1";
            series11.MarkerBorderColor = System.Drawing.Color.White;
            series11.Name = "CRP";
            series12.ChartArea = "ChartArea1";
            series12.CustomProperties = "DrawingStyle=Emboss";
            series12.Legend = "Legend1";
            series12.Name = "TSH";
            series13.ChartArea = "ChartArea1";
            series13.CustomProperties = "DrawingStyle=Emboss";
            series13.Legend = "Legend1";
            series13.Name = "Testosterone";
            series14.ChartArea = "ChartArea1";
            series14.CustomProperties = "DrawingStyle=Emboss";
            series14.Legend = "Legend1";
            series14.Name = "Estradiol";
            this.chart3.Series.Add(series11);
            this.chart3.Series.Add(series12);
            this.chart3.Series.Add(series13);
            this.chart3.Series.Add(series14);
            this.chart3.Size = new System.Drawing.Size(1368, 223);
            this.chart3.TabIndex = 5;
            this.chart3.Text = "chart3";
            this.chart3.Click += new System.EventHandler(this.chart3_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave.BackgroundImage")));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSave.Location = new System.Drawing.Point(1194, 175);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(63, 48);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave1.BackgroundImage")));
            this.buttonSave1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSave1.Location = new System.Drawing.Point(1194, 378);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(63, 48);
            this.buttonSave1.TabIndex = 7;
            this.buttonSave1.UseVisualStyleBackColor = false;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // buttonSave2
            // 
            this.buttonSave2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave2.BackgroundImage")));
            this.buttonSave2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSave2.Location = new System.Drawing.Point(1194, 577);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(63, 48);
            this.buttonSave2.TabIndex = 8;
            this.buttonSave2.UseVisualStyleBackColor = false;
            this.buttonSave2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 742);
            this.Controls.Add(this.buttonSave2);
            this.Controls.Add(this.buttonSave1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.button1stData);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Graphical View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1stData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSave1;
        private System.Windows.Forms.Button buttonSave2;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}