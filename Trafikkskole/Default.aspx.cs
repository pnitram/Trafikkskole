using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Trafikkskole
{
    public partial class _Default : Page
    {

        QuestionsAndAnswers _questionsAndAnswers = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> _questionsAndAnswersList = new List<QuestionsAndAnswers>();
        List<Users> _userList = new List<Users>();

        private string _myconnectionstring;
        private string _sql;
        private int _numRows;
        private int _questionNumber;
        private int _score;

        //Start Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
//            Session["email"] = "martin.pedersen@me.com";
//            Session["firstNAme"] = "Martin";
            _questionNumber = 0;

            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else if ((string) Session["admin"] == "isAdmin")
            {
                UsersFromDatabaseToList();
                GetHtmlForUserList();
            }

            else
            {
                if (!Page.IsPostBack)
                {
                    _questionsAndAnswersList.Clear();
                    QuestionsFromDatabaseToList();
                    _questionNumber = 1;
                    Session["questionNumber"] = _questionNumber;
                    _score = 0;
                    Session["score"] = _score;
                    QuestionLabel.Visible = false;
                    AnswerAlt1.Visible = false;
                    AnswerAlt2.Visible = false;
                    AnswerAlt3.Visible = false;
                    AnswerAlt4.Visible = false;
                    R1.Visible = false;
                    R2.Visible = false;
                    R3.Visible = false;
                    R4.Visible = false;
                }

                //Henter spørsmål og svar objekter fra sesjonen opprettet i QuestionsFromDatabaseToList()
                _questionsAndAnswersList = (List<QuestionsAndAnswers>) Session["QaList"];


                Label1.Text = Session["firstName"].ToString();
                _questionNumber = (int) Session["questionNumber"];
                _score = (int) Session["score"];

                foreach (QuestionsAndAnswers questionsAndAnswersObject in _questionsAndAnswersList)
                {

                    if (questionsAndAnswersObject.QuestionsId == _questionNumber)
                    {
                        QuestionLabel.Text = questionsAndAnswersObject.Question;
                        AnswerAlt1.Text = questionsAndAnswersObject.AnswerAlt1;
                        AnswerAlt2.Text = questionsAndAnswersObject.AnswerAlt2;
                        AnswerAlt3.Text = questionsAndAnswersObject.AnswerAlt3;
                        AnswerAlt4.Text = questionsAndAnswersObject.AnswerAlt4;

                    }
                }

            }
        }

        private void GetHtmlForUserList()
        {
            StringBuilder html = new StringBuilder();

            html.Append("<table border = '1'>");
            html.Append("<tr>");
            html.Append("<th>");
            html.Append("BrukerId");
            html.Append("</th>");
            html.Append("<th>");
            html.Append("Fornavn");
            html.Append("</th>");
            html.Append("<th>");
            html.Append("Etternavn");
            html.Append("</th>");
            html.Append("<th>");
            html.Append("E-post");
            html.Append("</th>");
            html.Append("<th>");
            html.Append("Siste poengsum");
            html.Append("</th>");
            html.Append("<th>");
            html.Append("Høyeste poengsum");
            html.Append("</th>");
            html.Append("</tr>");


            foreach (Users user in _userList)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(user.UserId);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(user.FirstName);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(user.LastName);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(user.Email);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(user.LastScore);
                html.Append("</td>");
                html.Append("<td>");
                html.Append(user.HighScore);
                html.Append("</td>");
                html.Append("</tr>");
            }


            html.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal {Text = html.ToString()});
        }

        //End Page_Load

        //Method to fill list with questions and answers objects from database
        private void QuestionsFromDatabaseToList()
        {
            _myconnectionstring =
                "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = "SELECT * FROM questionsAndAnswers ORDER BY rand()"; //Randomize query

            try
            {
                using (MySqlConnection con = new MySqlConnection(_myconnectionstring))
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = _sql;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    _numRows = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuestionsAndAnswers qr = new QuestionsAndAnswers();
                            qr.QuestionsId = _numRows + 1; // Create new ids after random query
                            qr.Question = (string) reader[1];
                            qr.AnswerAlt1 = (string) reader[2];
                            qr.AnswerAlt2 = (string) reader[3];
                            qr.AnswerAlt3 = (string) reader[4];
                            qr.AnswerAlt4 = (string) reader[5];
                            qr.IsCorrectAlt1 = (int) reader[6];
                            qr.IsCorrectAlt2 = (int) reader[7];
                            qr.IsCorrectAlt3 = (int) reader[8];
                            qr.IsCorrectAlt4 = (int) reader[9];
                            qr.MultipleChoice = (int) reader[10];
                            qr.IsUrl = (int) reader[11];
                            qr.Url = (string) reader[12];
                            _questionsAndAnswersList.Add(qr);
                            _numRows++;
                        }

                    }
                    else
                    {
                        Label1.Text = "No rows found";
                        Console.WriteLine("No rows found");
                    }

                    Session["QaList"] = _questionsAndAnswersList;

                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                QuestionLabel.Text = "Failed to get questions!";
                Label1.Text = "Failed to get questions!";
                Console.WriteLine("Failed to get questions!");
            }

        }

        private void UsersFromDatabaseToList()
        {
            _myconnectionstring =
                "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = "SELECT userId, firstName, lastName, email, lastScore, highScore FROM users"; 

            try
            {
                using (MySqlConnection con = new MySqlConnection(_myconnectionstring))
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = _sql;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    _numRows = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Users qr = new Users();
                            qr.UserId = (int)reader[0];
                            qr.FirstName = (string)reader[1];
                            qr.LastName = (string)reader[2];
                            qr.Email = (string)reader[3];
                            qr.LastScore = (int)reader[4];
                            qr.HighScore = (int)reader[5];
                            _userList.Add(qr);
                            _numRows++;
                        }

                    }
                    else
                    {
                        Label1.Text = "No rows found";
                        Console.WriteLine("No rows found");
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                QuestionLabel.Text = "Failed to get users!";
                Label1.Text = "Failed to get users!";
                Console.WriteLine("Failed to get users!");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_questionsAndAnswersList.Count == 0)
            {
                Button1.Text = "Kunne ikke hente fra database!";
                return;
            }

            Button1.Text = "Neste spørsmål";
            QnrLabel.Text = $"{_questionNumber}/{_questionsAndAnswersList.Count}:";
            QuestionLabel.Visible = true;
            AnswerAlt1.Visible = true;
            AnswerAlt2.Visible = true;
            AnswerAlt3.Visible = true;
            AnswerAlt4.Visible = true;
            R1.Visible = true;
            R2.Visible = true;
            R3.Visible = true;
            R4.Visible = true;


            //Foreach questionsAndAnswersObject in list
            try
            {
                foreach (QuestionsAndAnswers questionsAndAnswersObject in _questionsAndAnswersList)
                {

                    //To check if radio, checkbox or url
                    if (questionsAndAnswersObject.QuestionsId == _questionNumber)
                    {
                        if (questionsAndAnswersObject.MultipleChoice == 1)
                        {
                            R1.Visible = false;
                            R2.Visible = false;
                            R3.Visible = false;
                            R4.Visible = false;
                            C1.Visible = true;
                            C2.Visible = true;
                            C3.Visible = true;
                            C4.Visible = true;
                        }
                        if (questionsAndAnswersObject.MultipleChoice == 0)
                        {
                            R1.Visible = true;
                            R2.Visible = true;
                            R3.Visible = true;
                            R4.Visible = true;
                            C1.Visible = false;
                            C2.Visible = false;
                            C3.Visible = false;
                            C4.Visible = false;
                        }
                        if (questionsAndAnswersObject.IsUrl == 1)
                        {
                            Image1.ImageUrl = questionsAndAnswersObject.Url;
                            Image1.Visible = true;
                        }

                        if (questionsAndAnswersObject.IsUrl == 0)
                        {
                            Image1.Visible = false;
                        }

                    }

                    //Test if answer is correct
                    if (questionsAndAnswersObject.QuestionsId == _questionNumber - 1)
                    {
                        if ((R1.Checked || C1.Checked) && questionsAndAnswersObject.IsCorrectAlt1 == 1)
                        {
                            _score++;
                            Session["score"] = _score;
                            ScoreLabel.Visible = true;
                            ScoreLabel.Text = _score.ToString();
                        }
                        if ((R2.Checked || C2.Checked) && questionsAndAnswersObject.IsCorrectAlt2 == 1)
                        {
                            _score++;
                            Session["score"] = _score;
                            ScoreLabel.Visible = true;
                            ScoreLabel.Text = _score.ToString();
                        }
                        if ((R3.Checked || C3.Checked) && questionsAndAnswersObject.IsCorrectAlt3 == 1)
                        {
                            _score++;
                            Session["score"] = _score;
                            ScoreLabel.Visible = true;
                            ScoreLabel.Text = _score.ToString();
                        }
                        if ((R4.Checked || C4.Checked) && questionsAndAnswersObject.IsCorrectAlt4 == 1)
                        {
                            _score++;
                            Session["score"] = _score;
                            ScoreLabel.Visible = true;
                            ScoreLabel.Text = _score.ToString();
                        }

                    }
                    if (_questionNumber == _questionsAndAnswersList.Count)
                    {
                        Button1.Text = "Se resultat!";
                    }

                    if (_questionNumber > _questionsAndAnswersList.Count)
                    {

                        _myconnectionstring = "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
                        _sql = $"SELECT highScore FROM users WHERE email=\'{Session["email"]}\'";

                        try
                        {
                            using (MySqlConnection con = new MySqlConnection(_myconnectionstring))
                            {

                                con.Open();
                                MySqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = _sql;
                                int highScore = Convert.ToInt32(cmd.ExecuteScalar());

                                if (highScore > _score)
                                {
                                    _sql = $"UPDATE users SET lastScore ={_score} WHERE email='{Session["email"]}'";
                                    cmd.CommandText = _sql;
                                    cmd.ExecuteNonQuery();
                                    Response.Redirect("Default.aspx");
                                }
                                else if (highScore < _score)
                                {
                                    _sql = $"UPDATE users SET lastScore ={_score} WHERE email='{Session["email"]}'";
                                    cmd.CommandText = _sql;
                                    cmd.ExecuteNonQuery();
                                    _sql = $"UPDATE users SET highScore ={_score} WHERE email='{Session["email"]}'";
                                    cmd.CommandText = _sql;
                                    cmd.ExecuteNonQuery();
                                    Response.Redirect("Default.aspx");
                                }


                                else
                                {
                                    Label1.Text = "Kunne ikke registrere poengsum!";
                                }

                                con.Close();

                            }

                        }
                        catch
                        {
                            Console.WriteLine("Kunne ikke registrere poengsum");
                        }

                        Button1.Text = "Ikke fornøyd? Prøv igjen!";
                            AnswerAlt1.Text = $"Du oppnådde {_score} poeng!";
                            AnswerAlt1.Visible = true;
                            AnswerAlt2.Visible = false;
                            AnswerAlt3.Visible = false;
                            AnswerAlt4.Visible = false;
                            R1.Visible = false;
                            R2.Visible = false;
                            R3.Visible = false;
                            R4.Visible = false;
                            QnrLabel.Visible = false;
                            QuestionLabel.Visible = false;
                            _questionsAndAnswersList.Clear();
                            _score = 0;
                            Session["score"] = _score;
                            Button1.OnClientClick = "window.location.href='Default.aspx'; return false;";
                            _questionNumber = 1;
                            Session["questionNumber"] = _questionNumber;
                    }
                }

                
                }

                catch (Exception exception)
                {
                    Console.WriteLine(exception);

            }
                //End foreach

                _questionNumber++;
                Session["questionNumber"] = _questionNumber;

                //First radio button selected by default 
                R1.Checked = true;
                R2.Checked = false;
                R3.Checked = false;
                R4.Checked = false;
        }
    }
}

    
