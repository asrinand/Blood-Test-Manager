using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADOX;
using ADODB;
using System.Reflection;

namespace PBloodTestManager
{
    public partial class Form1 : Form
    {
        public Form1()
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

            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;
            OleDbConnection conn = new OleDbConnection(connectionString);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            toolTip1.SetToolTip(this.buttonInsert, "Insert Records");
            toolTip1.SetToolTip(this.buttonDelete, "Delete Records");
            toolTip1.SetToolTip(this.buttonUpdate, "Update Records");
            toolTip1.SetToolTip(this.buttonShowForm, "Open Graphical view window");
            toolTip1.SetToolTip(this.buttonClear1, "Clear all text fields");
            toolTip1.SetToolTip(this.buttonClear, "Clear all text fields");
            toolTip1.SetToolTip(this.buttonConvert, "Convert International Unit to Gravimetric Unit");
            
            

            labelIntUnit.Text = "";
            labelGravUnit.Text = "";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            System.IO.Directory.CreateDirectory("C:\\PBloodTestManager\\");
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Create the Database
            try
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                cat.Create(connectionString);
                //Now Close the database
                ADODB.Connection con =
                     cat.ActiveConnection as ADODB.Connection;
                if (con != null)
                    con.Close();

                MessageBox.Show("Database '"
                          + db_name + "' Created");
            }
            catch (Exception)
            {
                MessageBox.Show("Database already exists");
            }

            String tableName = "NEW_TABLE";
            String createSQL = "CREATE TABLE " + tableName + "("
               + "SNo Integer PRIMARY KEY,"
               + "TestDate Date,"
               + " Glucose Double,"
               + " Cholesterol Double,"
               + " LDL Double,"
               + " HDL Double,"
               + " Triglycerides Double,"
               + " Fibrinogen Double,"
               + " HemoglobinA1C Double,"
               + " DHEA Double,"
               + " PSA Double,"
               + " Homocysteine Double,"
               + " CRP Double,"
               + " TSH Double,"
               + " Testosterone Double,"
               + " Estradiol Double"
               + ")";
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                conn.Open();

                //MessageBox.Show(createSQL);
                dbCmd.Connection = conn;
                dbCmd.CommandText = createSQL;
                dbCmd.ExecuteNonQuery();

                MessageBox.Show("Table Created");

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

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Delete Table
            String tableName = "NEW_TABLE";
            String dropTableSQL = "DROP TABLE " + tableName;
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                conn.Open();

                MessageBox.Show(dropTableSQL);
                dbCmd.Connection = conn;
                dbCmd.CommandText = dropTableSQL;
                dbCmd.ExecuteNonQuery();
                dbCmd.Connection.Close();

                MessageBox.Show("Table Deleted");

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
                DataTable DT = (DataTable)dataGridView1.DataSource;
                if (DT != null)
                    DT.Clear();
                dataGridView1.Columns.Clear();
            }

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Delete Table
            //String tableName = "NEW_TABLE";
            String InsertTableSQL = "INSERT INTO NEW_TABLE (SNo,TestDate,Glucose,Cholesterol,LDL,HDL,Triglycerides,Fibrinogen,HemoglobinA1C,DHEA,PSA,Homocysteine,CRP,TSH,Testosterone,Estradiol) VALUES('" + textSNo.Text + "','" + dateTimePicker1.Value + "','" + textGlucose.Text + "','" + textCholesterol.Text + "','" + textLDL.Text + "','" + textHDL.Text + "','" + textTriglycerides.Text + "','" + textFibrinogen.Text + "','" + textHemoglobinA1C.Text + "','" + textDHEA.Text + "','" + textPSA.Text + "','" + textHomocysteine.Text + "','" + textCRP.Text + "','" + textTSH.Text + "','" + textTestosterone.Text + "','" + textEstradiol.Text + "')";
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();
            String LoadTableSQL = "SELECT * FROM NEW_TABLE ORDER BY SNo ASC";
            if (textSNo.Text==""||textGlucose.Text == "" || textCholesterol.Text == "" || textLDL.Text == "" || textHDL.Text == "" || textTriglycerides.Text == "" || textFibrinogen.Text == "" || textHemoglobinA1C.Text == "" || textDHEA.Text == "" || textPSA.Text == "" || textHomocysteine.Text == "" || textCRP.Text == "" || textTSH.Text == "" || textTestosterone.Text == "" || textEstradiol.Text == "")
            {
                MessageBox.Show("No text field can be blank. Enter 0 if field is not going to be needed.", "Text Field Blank !!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();

                    //MessageBox.Show(InsertTableSQL);
                    dbCmd.Connection = conn;
                    dbCmd.CommandText = InsertTableSQL;
                    dbCmd.ExecuteNonQuery();

                    MessageBox.Show("Values Inserted");

                    dbCmd.Connection = conn;
                    dbCmd.CommandText = LoadTableSQL;
                    dataGridView1.Enabled = true;
                    OleDbDataAdapter da = new OleDbDataAdapter(dbCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dbCmd.Connection.Close();

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
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Delete Table
            //String tableName = "NEW_TABLE";
            String UpdateTableSQL = "UPDATE NEW_TABLE SET TestDate='" + dateTimePicker1.Value + "' ,Glucose ='" + textGlucose.Text + "' ,Cholesterol='" + textCholesterol.Text + "' ,LDL='" + textLDL.Text + "' ,HDL='" + textHDL.Text + "' ,Triglycerides='" + textTriglycerides.Text + "' ,Fibrinogen='" + textFibrinogen.Text + "' ,HemoglobinA1C='" + textHemoglobinA1C.Text + "' ,DHEA='" + textDHEA.Text + "' ,PSA='" + textPSA.Text + "' ,Homocysteine='" + textHomocysteine.Text + "' ,CRP='" + textCRP.Text + "' ,TSH='" + textTSH.Text + "' ,Testosterone='" + textTestosterone.Text + "' ,Estradiol='" + textEstradiol.Text + "' where SNo=" + textSNo.Text + "";
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();
            String LoadTableSQL = "SELECT * FROM NEW_TABLE ORDER BY SNo ASC";
            if (textSNo.Text == "" || textGlucose.Text == "" || textCholesterol.Text == "" || textLDL.Text == "" || textHDL.Text == "" || textTriglycerides.Text == "" || textFibrinogen.Text == "" || textHemoglobinA1C.Text == "" || textDHEA.Text == "" || textPSA.Text == "" || textHomocysteine.Text == "" || textCRP.Text == "" || textTSH.Text == "" || textTestosterone.Text == "" || textEstradiol.Text == "")
            {
                MessageBox.Show("No text field can be blank. Enter 0 if field is not going to be needed.", "Text Field Blank !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();

                    //MessageBox.Show(UpdateTableSQL);
                    dbCmd.Connection = conn;
                    dbCmd.CommandText = UpdateTableSQL;
                    dbCmd.ExecuteNonQuery();
                    //dbCmd.Connection.Close();

                    MessageBox.Show("Values Updated");
                    dbCmd.Connection = conn;
                    dbCmd.CommandText = LoadTableSQL;
                    dataGridView1.Enabled = true;
                    OleDbDataAdapter da = new OleDbDataAdapter(dbCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dbCmd.Connection.Close();
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
        }

        private void buttonLoadDatabase_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            String LoadTableSQL = "SELECT * FROM NEW_TABLE";
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                conn.Open();

                
                dbCmd.Connection = conn;
                dbCmd.CommandText = LoadTableSQL;

                OleDbDataAdapter da = new OleDbDataAdapter(dbCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dbCmd.Connection.Close();

                

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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
                e.Cancel = true;
            }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Delete Table
            //String tableName = "NEW_TABLE";
            String dropColSQL = "DELETE FROM NEW_TABLE WHERE SNo= " + textSNo.Text + "";
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();
            String LoadTableSQL = "SELECT * FROM NEW_TABLE ORDER BY SNo ASC";

            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the column from the table ?"+"\n"+"Rollback of the particular action is not possible afterwards !!","Delete Column", MessageBoxButtons.YesNo);
                switch (dr)
                {
                case DialogResult.Yes:
                conn.Open();

                //MessageBox.Show(dropColSQL);
                dbCmd.Connection = conn;
                dbCmd.CommandText = dropColSQL;
                dbCmd.ExecuteNonQuery();
                //dbCmd.Connection.Close();

                MessageBox.Show("Column Deleted");

                dbCmd.Connection = conn;
                dbCmd.CommandText = LoadTableSQL;
                dataGridView1.Enabled = true;
                OleDbDataAdapter da = new OleDbDataAdapter(dbCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dbCmd.Connection.Close();
                break;

                case DialogResult.No:
                Form1 frm = new Form1();
                frm.Activate();
                break;
            }

            }
            catch (OleDbException exp)
            {
                MessageBox.Show("Database Error: "
                              + exp.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                textSNo.Text = "";
                dateTimePicker1.Text = "";
                textGlucose.Text = "";
                textCholesterol.Text = "";
                textLDL.Text = "";
                textHDL.Text = "";
                textTriglycerides.Text = "";
                textFibrinogen.Text = "";
                textHemoglobinA1C.Text = "";
                textDHEA.Text = "";
                textPSA.Text = "";
                textHomocysteine.Text = "";
                textCRP.Text = "";
                textTSH.Text = "";
                textTestosterone.Text = "";
                textEstradiol.Text = "";
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                textSNo.Text = dr.Cells["SNo"].Value.ToString();
                dateTimePicker1.Text = dr.Cells["TestDate"].Value.ToString();
                textGlucose.Text = dr.Cells["Glucose"].Value.ToString();
                textCholesterol.Text = dr.Cells["Cholesterol"].Value.ToString();
                textLDL.Text = dr.Cells["LDL"].Value.ToString();
                textHDL.Text = dr.Cells["HDL"].Value.ToString();
                textTriglycerides.Text = dr.Cells["Triglycerides"].Value.ToString();
                textFibrinogen.Text = dr.Cells["Fibrinogen"].Value.ToString();
                textHemoglobinA1C.Text = dr.Cells["HemoglobinA1C"].Value.ToString();
                textDHEA.Text = dr.Cells["DHEA"].Value.ToString();
                textPSA.Text = dr.Cells["PSA"].Value.ToString();
                textHomocysteine.Text = dr.Cells["Homocysteine"].Value.ToString();
                textCRP.Text = dr.Cells["CRP"].Value.ToString();
                textTSH.Text = dr.Cells["TSH"].Value.ToString();
                textTestosterone.Text = dr.Cells["Testosterone"].Value.ToString();
                textEstradiol.Text = dr.Cells["Estradiol"].Value.ToString();
            }
            catch (Exception e12)
            {
                MessageBox.Show("Wrongful Access : " + e12.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable DT = (DataTable)dataGridView1.DataSource;
            if (DT != null)
                DT.Clear();
            dataGridView1.Columns.Clear();

        }

        private void textGlucose_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled=true;
            }
        }

        private void textSNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textCholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textLDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textHDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textTriglycerides_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textFibrinogen_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textHemoglobinA1C_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textDHEA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textPSA_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textHomocysteine_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textCRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textTSH_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textTestosterone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textEstradiol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxIntUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBoxGravUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            double a, b;
            

            if (textBoxIntUnit.Text == "")
            {
                MessageBox.Show("Text field is empty");
            }
            else{
                a = double.Parse(textBoxIntUnit.Text);
                if (radioButtonGlucose.Checked == true || radioButtonDHEA.Checked == true || radioButtonCholesterol.Checked == true || radioButtonTriglycerides.Checked == true || radioButtonEstradiol.Checked == true || radioButtonTestosterone.Checked == true || radioButtonCRP.Checked == true || radioButtonPSA.Checked == true || radioButtonHomocysteine.Checked == true || radioButtonFibrinogen.Checked == true)
                {
                    if (radioButtonGlucose.Checked == true)
                    {
                        //labelIntUnit.Text = "mmol/L";
                        //labelGravUnit.Text = "mg/dL";
                        b = a / 0.0555;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonCholesterol.Checked == true)
                    {
                        //labelIntUnit.Text = "mmol/L";
                        //labelGravUnit.Text = "mg/dL";
                        b = a / 0.0259;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonTriglycerides.Checked == true)
                    {
                        //labelIntUnit.Text = "mmol/L";
                        //labelGravUnit.Text = "mg/dL";
                        b = a / 0.0113;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonDHEA.Checked == true)
                    {
                        //labelIntUnit.Text = "nmol/L";
                        //labelGravUnit.Text = "ng/dL";
                        b = a / 0.0347;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonTestosterone.Checked == true)
                    {
                        //labelIntUnit.Text = "pmol/L";
                        //labelGravUnit.Text = "pg/mL";
                        b = a / 3.47;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonEstradiol.Checked == true)
                    {
                        //labelIntUnit.Text = "pmol/L";
                        //labelGravUnit.Text = "pg/mL";
                        b = a / 3.67;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonCRP.Checked == true)
                    {
                        //labelIntUnit.Text = "nmol/L";
                        //labelGravUnit.Text = "mg/L";
                        b = a / 9.524;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonPSA.Checked == true)
                    {
                        //labelIntUnit.Text = "μg/L";
                        //labelGravUnit.Text = "ng/mL";
                        b = a / 1;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonHomocysteine.Checked == true)
                    {
                        //labelIntUnit.Text = "μmol/L";
                        //labelGravUnit.Text = "mg/L";
                        b = a / 7.397;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }
                    if (radioButtonFibrinogen.Checked == true)
                    {
                        //labelIntUnit.Text = "g/L";
                        //labelGravUnit.Text = "mg/dL";
                        b = a / 0.01;
                        textBoxGravUnit.Text = b.ToString("#.##");
                    }

                }
                else
                {
                    MessageBox.Show("No option selected to convert");
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelIntUnit.Text = "";
            labelGravUnit.Text = "";
            textBoxGravUnit.Text = "";
            textBoxIntUnit.Text = "";
            radioButtonCholesterol.Checked = false;
            radioButtonCRP.Checked = false;
            radioButtonDHEA.Checked = false;
            radioButtonEstradiol.Checked = false;
            radioButtonFibrinogen.Checked = false;
            radioButtonGlucose.Checked = false;
            radioButtonHomocysteine.Checked = false;
            radioButtonPSA.Checked = false;
            radioButtonTestosterone.Checked = false;
            radioButtonTriglycerides.Checked = false;

        }

        private void radioButtonGlucose_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "mmol/L";
            labelGravUnit.Text = "mg/dL";
        }

        private void radioButtonCholesterol_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "mmol/L";
            labelGravUnit.Text = "mg/dL";
        }

        private void radioButtonTriglycerides_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "mmol/L";
            labelGravUnit.Text = "mg/dL";
        }

        private void radioButtonDHEA_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "nmol/L";
            labelGravUnit.Text = "ng/dL";
        }

        private void radioButtonTestosterone_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "pmol/L";
            labelGravUnit.Text = "pg/mL";
        }

        private void radioButtonEstradiol_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "pmol/L";
            labelGravUnit.Text = "pg/mL";
        }

        private void radioButtonCRP_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "nmol/L";
            labelGravUnit.Text = "mg/L";
        }

        private void radioButtonPSA_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "μg/L";
            labelGravUnit.Text = "ng/mL";
        }

        private void radioButtonHomocysteine_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "μmol/L";
            labelGravUnit.Text = "mg/L";
        }

        private void radioButtonFibrinogen_CheckedChanged(object sender, EventArgs e)
        {
            labelIntUnit.Text = "g/L";
            labelGravUnit.Text = "mg/dL";
        }

        private void createDatabaseTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Create the Database
            try
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                cat.Create(connectionString);
                //Now Close the database
                ADODB.Connection con =
                     cat.ActiveConnection as ADODB.Connection;
                if (con != null)
                    con.Close();

                MessageBox.Show("Database '"
                          + db_name + "' Created in C:\\PBloodTestManager\\");
            }
            catch (Exception)
            {
                MessageBox.Show("Database already exists");
            }

            String tableName = "NEW_TABLE";
            String createSQL = "CREATE TABLE " + tableName + "("
               + "SNo Integer PRIMARY KEY,"
               + "TestDate Date,"
               + " Glucose Double,"
               + " Cholesterol Double,"
               + " LDL Double,"
               + " HDL Double,"
               + " Triglycerides Double,"
               + " Fibrinogen Double,"
               + " HemoglobinA1C Double,"
               + " DHEA Double,"
               + " PSA Double,"
               + " Homocysteine Double,"
               + " CRP Double,"
               + " TSH Double,"
               + " Testosterone Double,"
               + " Estradiol Double"
               + ")";
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                conn.Open();

                //MessageBox.Show(createSQL);
                dbCmd.Connection = conn;
                dbCmd.CommandText = createSQL;
                dbCmd.ExecuteNonQuery();

                MessageBox.Show("Table NEW_TABLE Created");

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

        private void deleteDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            //Delete Table
            String tableName = "NEW_TABLE";
            String dropTableSQL = "DROP TABLE " + tableName;
            OleDbConnection conn =
                    new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the existing table from the database ?","Delete Table", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes: 
                        conn.Open();
                        //MessageBox.Show(dropTableSQL);
                        dbCmd.Connection = conn;
                        dbCmd.CommandText = dropTableSQL;
                        dbCmd.ExecuteNonQuery();
                        dbCmd.Connection.Close();

                        MessageBox.Show("Table NEW_TABLE Deleted");
                        break;

                    case DialogResult.No:
                        Form1 frm = new Form1();
                        frm.Activate();
                        break;
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
                DataTable DT = (DataTable)dataGridView1.DataSource;
                if (DT != null)
                    DT.Clear();
                dataGridView1.Columns.Clear();

                DialogResult dr1 = MessageBox.Show("Do you want to delete the database file - NEWDB ?", "Delete Database", MessageBoxButtons.YesNo);
                switch (dr1)
                {
                    case DialogResult.Yes:
                        string destinationFile = @"C:\PBloodTestManager\NEWDB.accdb";
                        try
                        {
                            File.Delete(destinationFile);
                        }
                        catch (IOException iox)
                        {
                            MessageBox.Show(iox.Message);
                        }
                        finally
                        {
                            MessageBox.Show("Database NEWDB deleted");
                        }
                        break;
                    case DialogResult.No:
                        Form1 frm = new Form1();
                        frm.Activate();
                        break;
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String db_name = "NEWDB.accdb";
            String connectionString =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data"
                + @" Source=C:\PBloodTestManager\" + db_name;

            String LoadTableSQL = "SELECT * FROM NEW_TABLE ORDER BY SNo ASC";
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand dbCmd = new OleDbCommand();

            try
            {
                conn.Open();


                dbCmd.Connection = conn;
                dbCmd.CommandText = LoadTableSQL;
                dataGridView1.Enabled = true;
                OleDbDataAdapter da = new OleDbDataAdapter(dbCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dbCmd.Connection.Close();



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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void buttonShowForm_Click(object sender, EventArgs e)
        {
            Form2 frm1 = new Form2();
            Form1 frm = new Form1();
            frm1.Show();
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            textSNo.Text = "";
            dateTimePicker1.Text = "";
            textGlucose.Text = "";
            textCholesterol.Text = "";
            textLDL.Text = "";
            textHDL.Text = "";
            textTriglycerides.Text = "";
            textFibrinogen.Text = "";
            textHemoglobinA1C.Text = "";
            textDHEA.Text = "";
            textPSA.Text = "";
            textHomocysteine.Text = "";
            textCRP.Text = "";
            textTSH.Text = "";
            textTestosterone.Text = "";
            textEstradiol.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is used to manage the most common and generalised blood tests which usually taken." + "\n" + "\n" + "Database Options -" + "\n" + "\n" + "1.) Create - Creates a Microsoft Access Database in the C:\\ Directory (Administer Privileges are a must) and also creates a new table inside the database." + "\n" + "\n" + "2.) Delete - This deletes only the table which was created inside the database but not the database itself." + "\n" + "\n" + "3.) Load - This loads the table data values inside the database to the main form, from where user can manage the data values." + "\n" + "\n" + "Other controls include -" + "\n" + "\n" + "Insert - Insert records into the database." + "\n" + "\n" + "Update - Update records into the database (Serial Number has to be mentioned which would indicate the record to be updated)." + "\n" + "\n" + "Delete - delete records from the database (Serial Number has to be mentioned which would indicate the record to be deleted). "+ "\n" + "\n" + "Graph View - Takes user into another window from where a graphical view of all the blood test values can be observed and compared.", "Blood Test Report Manager");
        }

        private void termsLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To use this program you must accept the following terms and conditions :" + "\n" + "\n" + "> This program is freeware and can be distributed by everyone." + "\n" + "\n" + "> No person or company or organisation may charge a fee for the distribution of this product." + "\n" + "\n" + "> No warranty of any kind is implied or expressed. User uses at own risk. The author will not be liable for data loss,damages,loss of profits or any other kind of loss while using or misusing this program." + "\n" + "\n" + "> You may not rent,lease,sell this program. Any such unauthorised use shall result in an immediate and automatic termination of this license and may result in criminal and/or civil prosecution." + "\n" + "\n" + "> The author will not be responsible for what is made with this program" + "\n" + "\n" + "Using this program signifies acceptance of these terms and conditions of the license." + "\n" + "\n" + "\n" + "\n" + "Program Developed by - Srinand Arunkumar" + "\n" + "Email : asrinand@gmail.com", "Terms And Conditions");
        }

        private void textBoxIntUnit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textBoxIntUnit, "Enter International Unit to convert");
        }

        private void textBoxGravUnit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textBoxGravUnit, "Gravimetric Unit");
        }

        private void textGlucose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textGlucose, "Reference Range : 60 - 100 mg/dL");

        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.dateTimePicker1, "Select date of the record");
        }

        private void textSNo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textSNo, "Serial number to identify the record");
        }

        private void textCholesterol_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textCholesterol, "Reference Range : 120 - 200 mg/dL");
        }

        private void textLDL_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textLDL, "Low-density lipoprotein" + "\n" + "Reference Range : 80 - 120 mg/dL");
        }

        private void textHDL_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textHDL, "High-density lipoprotein" + "\n" + "Reference Range : 35 - 80 mg/dL");
        }

        private void textTriglycerides_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textTriglycerides, "Reference Range : 70 - 150 mg/dL");
        }

        private void textFibrinogen_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textFibrinogen, "Reference Range : 200 - 400 mg/dL");
        }

        private void textHemoglobinA1C_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textHemoglobinA1C, "Reference Range : 3.6 - 5.0 % of Hb");
        }

        private void textDHEA_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textDHEA, "Dehydroepiandrosterone" + "\n" + "Reference Range : 146 - 850 ng/dL");
        }

        private void textPSA_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textPSA, "Prostate-Specific Antigen" + "\n" + "Reference Range : PSA level of 4.0 ng/mL and below");
        }

        private void textHomocysteine_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textHomocysteine, "Reference Range : 0.54 - 2.16 mg/L");
        }

        private void textCRP_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textCRP, "C-reactive protein" + "\n" + "Reference Range : CRP level of 6 mg/L and below");
        }

        private void textTSH_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textTSH, "Thyroid Stimulating Hormone"+"\n"+"Reference Range : 0.3 - 6.0 mU/L or mIU/L");
        }

        private void textTestosterone_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textTestosterone, "Reference Range : Men(50 - 210 pg/mL or 270-1070 ng/dL), Women(1.0 - 8.5 pg/mL or 5 - 70 ng/dL)");
        }

        private void textEstradiol_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.textEstradiol, "Reference Range : 14 - 55 pg/mL");
        }

        private void aboutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.Black;
        }

        private void aboutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = sender as ToolStripMenuItem;
            TSMI.ForeColor = Color.White;
        }

        private void databaseToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI1 = sender as ToolStripMenuItem;
            TSMI1.ForeColor = Color.Black;
        }

        private void databaseToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI1 = sender as ToolStripMenuItem;
            TSMI1.ForeColor = Color.White;
        }
        }

    }

   


