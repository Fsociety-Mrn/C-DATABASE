using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_C_sharp
{
    public partial class Form1 : Form
    {
         Database_MYSQL databse = new Database_MYSQL();
        public Form1()
        {
            InitializeComponent();

            // when form to load it will load the data from database
            update_datagridview();
        }

        private void update_datagridview()
        {
            // Get data from the database
            DataSet dataSet = databse.GetDataForDataGridView();

            // Check if data retrieval was successful
            if (dataSet != null)
            {
                // Set the DataSet as the DataSource for your DataGridView
                dataGridView1.DataSource = dataSet.Tables["YourData"];
            }
            else
            {
                // Handle the case where data retrieval failed
                MessageBox.Show("Failed to retrieve data from the database.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // insert data in database
            bool result = databse.InsertData(textBox1.Text);

            // verify result
            if (result)
            {
                MessageBox.Show("data insert success");

                // update datagridview if successfully inserted the data
                update_datagridview();
            }
            else
            {
                MessageBox.Show("invalid insert");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (databse.OpenConnection())
            {
                MessageBox.Show("gooods");
            }
            else
            {
                MessageBox.Show("not gooods");
            }
            
        }
    }
}
