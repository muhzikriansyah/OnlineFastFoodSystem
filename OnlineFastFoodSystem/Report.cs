using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineFastFoodSystem
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True"))
            {

                string str = "SELECT * FROM ordr WHERE Id = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = new BindingSource(dt, null);
            }

        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet.ordr' table. You can move, or remove it, as needed.
            this.ordrTableAdapter.Fill(this.foodDataSet.ordr);

        }
    }
}
