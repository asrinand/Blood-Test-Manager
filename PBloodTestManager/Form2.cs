using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using ADODB;
using ADOX;

namespace PBloodTestManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1stData, "Load graphs");
            toolTip1.SetToolTip(this.buttonSave, "Save Graph 1");
            toolTip1.SetToolTip(this.buttonSave1, "Save Graph 2");
            toolTip1.SetToolTip(this.buttonSave2, "Save Graph 3");
            
        }

        private void button1stData_Click(object sender, EventArgs e)
        {
            button1stData.Enabled = false;
            //chart1.Visible = true;
            //chart2.Visible = true;
            //chart3.Visible = true;
            
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            
            OleDbConnection conn = new OleDbConnection(connectionString);
            

            try
            {
                conn.Open();
                OleDbCommand dbCmd = new OleDbCommand();
                dbCmd.Connection = conn;
                String query = "SELECT * FROM NEW_TABLE";
                dbCmd.CommandText = query;
                OleDbDataReader reader = dbCmd.ExecuteReader();
                
                
                while (reader.Read())
                {
                    chart1.Series["Glucose"].Points.AddXY(reader["TestDate"].ToString(), reader["Glucose"].ToString());
                    chart1.Series["Cholesterol"].Points.AddXY(reader["TestDate"].ToString(), reader["Cholesterol"].ToString());
                    chart1.Series["LDL"].Points.AddXY(reader["TestDate"].ToString(), reader["LDL"].ToString());
                    chart1.Series["HDL"].Points.AddXY(reader["TestDate"].ToString(), reader["HDL"].ToString());
                    chart1.Series["Triglycerides"].Points.AddXY(reader["TestDate"].ToString(), reader["Triglycerides"].ToString());

                    chart2.Series["Fibrinogen"].Points.AddXY(reader["TestDate"].ToString(), reader["Fibrinogen"].ToString());
                    chart2.Series["HemoglobinA1C"].Points.AddXY(reader["TestDate"].ToString(), reader["HemoglobinA1C"].ToString());
                    chart2.Series["DHEA"].Points.AddXY(reader["TestDate"].ToString(), reader["DHEA"].ToString());
                    chart2.Series["PSA"].Points.AddXY(reader["TestDate"].ToString(), reader["PSA"].ToString());
                    chart2.Series["Homocysteine"].Points.AddXY(reader["TestDate"].ToString(), reader["Homocysteine"].ToString());


                    chart3.Series["CRP"].Points.AddXY(reader["TestDate"].ToString(), reader["CRP"].ToString());
                    chart3.Series["TSH"].Points.AddXY(reader["TestDate"].ToString(), reader["TSH"].ToString());
                    chart3.Series["Testosterone"].Points.AddXY(reader["TestDate"].ToString(), reader["Testosterone"].ToString());
                    chart3.Series["Estradiol"].Points.AddXY(reader["TestDate"].ToString(), reader["Estradiol"].ToString());
                }

              


            }
            

            catch (OleDbException exp)
            {
                MessageBox.Show("Database Error:"
                              + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        
        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            button1stData.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog save = new SaveFileDialog();
            save.ValidateNames = true;
            save.DefaultExt = ".Jpeg";
            save.Filter = "JPEG Image (.jpeg)|";
            if(save.ShowDialog() == DialogResult.OK)
            {
               
              chart1.SaveImage(save.FileName, ChartImageFormat.Jpeg);
              //chart2.SaveImage(save.FileName, ChartImageFormat.Jpeg);
              //chart3.SaveImage(save.FileName, ChartImageFormat.Jpeg);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ValidateNames = true;
            save.DefaultExt = ".Jpeg";
            save.Filter = "JPEG Image (.jpeg)|";
            if (save.ShowDialog() == DialogResult.OK)
            {

                //chart1.SaveImage(save.FileName, ChartImageFormat.Jpeg);
                //chart2.SaveImage(save.FileName, ChartImageFormat.Jpeg);
                chart3.SaveImage(save.FileName, ChartImageFormat.Jpeg);

            }
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ValidateNames = true;
            save.DefaultExt = ".Jpeg";
            save.Filter = "JPEG Image (.jpeg)|";
            if (save.ShowDialog() == DialogResult.OK)
            {

                //chart1.SaveImage(save.FileName, ChartImageFormat.Jpeg);
                chart2.SaveImage(save.FileName, ChartImageFormat.Jpeg);
                //chart3.SaveImage(save.FileName, ChartImageFormat.Jpeg);

            }
        }
    }
}
