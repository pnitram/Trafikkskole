using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using static System.Globalization.CultureInfo;
using static System.Web.Security.FormsAuthentication;

namespace Trafikkskole
{
    public partial class Register : System.Web.UI.Page
    {
        private string _myconnectionstring;
        private string _fornavn;
        private string _etternavn;
        private string _epost;
        private string _passord;
        private string _bekreftPassord;
        private string _bekreftetPassordHash;
        private string _sql;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"]!=null)
            {
                Response.Redirect("Default.aspx");
            }

        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            _fornavn = CurrentCulture.TextInfo.ToTitleCase(TextBox1.Text.ToLower());
            _etternavn = CurrentCulture.TextInfo.ToTitleCase(TextBox2.Text.ToLower());
            _epost = TextBox3.Text;
            _passord = TextBox4.Text;
            _bekreftPassord = TextBox5.Text;
            _bekreftetPassordHash = HashPasswordForStoringInConfigFile(_passord, "MD5");


            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || TextBox3.Text == string.Empty || TextBox4.Text == string.Empty || TextBox5.Text == string.Empty)
            {
                Label1.Text = "Alle felt må fylles ut";
                return;
            }

            if (string.Compare(_passord, _bekreftPassord) == 1)
            {
                Label1.Text = "Passordene er ikke like";
                return;
            }

            
            _myconnectionstring = "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = $"SELECT COUNT(email) FROM users WHERE email=\'{_epost}\'";

            try
            {
                using (MySqlConnection con = new MySqlConnection(_myconnectionstring))
                {
                    
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = _sql;
                    int antallRader = Convert.ToInt32(cmd.ExecuteScalar());

                    if (antallRader == 0)
                    {
                        _sql = $"INSERT INTO users(firstName, lastName, email, password) VALUES(\'{_fornavn}\',\'{_etternavn}\',\'{_epost}\',\'{_bekreftetPassordHash}\')";
                        cmd.CommandText = _sql;
                        cmd.ExecuteNonQuery();
                        Session["email"] = _epost;
                        Response.Redirect("Default.aspx");
                    }

                    else
                    {
                        Label1.Text = "Epost er allerede registrert!";
                        TextBox3.Text = "";
                    }
                    
                    con.Close();

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                
            }

        }
    }
}