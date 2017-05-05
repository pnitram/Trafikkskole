using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using static System.Web.Security.FormsAuthentication;

namespace Trafikkskole
{
    public partial class Login : System.Web.UI.Page
    {
        private string _myconnectionstring;
        private string _epost;
        private string _passord;
        private string _sql;
        private string _bekreftetPassordHash;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"]!=null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _epost = TextBox1.Text;
            _passord = TextBox2.Text;
            _bekreftetPassordHash = HashPasswordForStoringInConfigFile(_passord, "MD5");
            _myconnectionstring = "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = $"SELECT * FROM users WHERE email=\'{_epost}\' AND password=\'{_bekreftetPassordHash}\'";
          

            try
            {
                using (MySqlConnection con = new MySqlConnection(_myconnectionstring))
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = _sql;
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        int x = (int)dr["isAdmin"];

                        if (x == 1)
                        {
                            Session["admin"] = "isAdmin";
                        }

                        Session["email"] = dr["email"].ToString();
                        Session["firstName"] = dr["firstName"].ToString();
                        Response.Redirect("Default.aspx");
                    }
                    
                    con.Close();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label1.Text = "Ugyldig brukernavn eller passord";
                }

            }
            catch (Exception exception)
            {
                Label1.Text = "Ikke kontakt med database!";

            }

            
        }
    }
}