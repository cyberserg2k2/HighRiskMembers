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

namespace HighRiskMembers
{
    public partial class HighRiskForm : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LICUReports;Initial Catalog=Emortelle;Integrated Security=True");

        public HighRiskForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

              
                con.Open();

                CheckConnectionLabel.Text = "Connection Successful";

                con.Close();
            }

            catch (Exception ex)

            {

                MessageBox.Show("Error:" + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();


            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select * from Users where CAID = '" + txtUserName.Text + "' and HighRiskFormPassword = '" + txtPassword.Text + "'";

            cmd.ExecuteNonQuery();

                                            

            //DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login success");

            }
            else
            {

                MessageBox.Show("Invalid Login");


            }


            //sa.Fill(dt);




            con.Close();

                                                                    
        }

        private void GrpLogin_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = SystemColors.Control;
        }
    }
}
