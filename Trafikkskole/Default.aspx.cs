using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Trafikkskole
{
    public partial class _Default : Page
    {

        QuestionsAndAnswers _questionsAndAnswers = new QuestionsAndAnswers();
        readonly List<QuestionsAndAnswers> _questionsAndAnswersList = new List<QuestionsAndAnswers>();

        private string _myconnectionstring;
        private string _sql;
        private int _numRows;
        private int _questionNumber;
        private int _score;

        //Start Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["email"] = "martin.pedersen@me.com";
            Session["firstNAme"] = "Martin";
            _questionNumber = 0;

            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {
                if (!Page.IsPostBack)
                {
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

                QuestionsFromDatabaseToList();
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
        //End Page_Load

        //Method to fill list with questions and answers objects from database
        private void QuestionsFromDatabaseToList()
        {
            _myconnectionstring =
                "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = "Select * from questionsAndAnswers order by rand(123)"; //Randomize query

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
                            qr.QuestionsId = _numRows+1; // Create new ids after random query
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
                        Console.WriteLine("No rows found");
                    }

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get questions!");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Text = "Neste spørsmål";
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
                if (questionsAndAnswersObject.QuestionsId == _questionNumber -1)
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

                if (_questionNumber > 20)
                {
                    Button1.Text = "Siste spørsmål! Se resultat :)";
                }

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