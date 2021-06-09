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
    public partial class Recepies : Form
    {
        public Recepies()
        {
            InitializeComponent();
        }

        private void Recepies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodDataSet2.recipe' table. You can move, or remove it, as needed.
            this.recipeTableAdapter.Fill(this.foodDataSet2.recipe);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True");
            con.Open();
            string str1 = "select max(id) from recipe;";

            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True");
            con.Open();

            try
            {
                string str = " INSERT INTO recipe(r_name,descr,type) VALUES('" + textBox2.Text + "','" + textBox5.Text + "','" + textBox4.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from recipe;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("New Recipe Information Saved Successfully..");
                    textBox2.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";

                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM recipe";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                }

            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True");

            con.Open();
            if (textBox1.Text != "")
            {
                try
                {
                    string getCust = "select r_name,descr,type from recipe where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox2.Text = dr.GetValue(0).ToString();
                        textBox4.Text = dr.GetValue(1).ToString();
                        textBox5.Text = dr.GetValue(2).ToString();

                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + textBox1.Text + " Recipes is not Available.   ");
                        textBox1.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True");
            con.Open();
            try
            {
                string str = " Update recipe set r_name='" + textBox2.Text + "',descr='" + textBox5.Text + "',type='" + textBox4.Text + "' where id='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(id) from recipe;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + textBox2.Text + "'s Details is Updated Successfully.. ", "Important Message");
                    textBox2.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\onlinefastfoodsystem\OnlineFastFoodSystem\OnlineFastFoodSystem\food.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM recipe";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }

                }

            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";

        }
    }
}
