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
        List<QuestionsAndAnswers> _questionsAndAnswersList = new List<QuestionsAndAnswers>();

        private string _myconnectionstring;
        private string _sql;
        private int _numRows;
        private int _questionNumber;
        private int _score;


        protected void Page_Load(object sender, EventArgs e)
        {
//            Session["email"] = "martin.pedersen@me.com";
//            Session["firstNAme"] = "Martin";

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
                

            }
        }

        private void QuestionsFromDatabaseToList()
        {
            _myconnectionstring = "Database=trafikkskole; Data Source = localhost; User = trafikkskole; Password = trafikkskole";
            _sql = "Select * from questionsAndAnswers";

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
                            qr.QuestionsId = (int) reader[0];
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
            _questionNumber = (int)Session["questionNumber"];

            foreach (QuestionsAndAnswers questionsAndAnswersObject in _questionsAndAnswersList)
            {

                if (questionsAndAnswersObject.QuestionsId == _questionNumber)
                {
                    if (R1.Checked && questionsAndAnswersObject.IsCorrectAlt1 == 1)
                    {
                        _score++;
                        ScoreLabel.Visible = true;
                        ScoreLabel.Text = _score.ToString();
                    }
                    if (R2.Checked && questionsAndAnswersObject.IsCorrectAlt2 == 1)
                    {
                        _score++;
                        ScoreLabel.Visible = true;
                        ScoreLabel.Text = _score.ToString();
                    }
                    if (R3.Checked && questionsAndAnswersObject.IsCorrectAlt3 == 1)
                    {
                        _score++;
                        ScoreLabel.Visible = true;
                        ScoreLabel.Text = _score.ToString();
                    }
                    if (R4.Checked && questionsAndAnswersObject.IsCorrectAlt4 == 1)
                    {
                        _score++;
                        ScoreLabel.Visible = true;
                        ScoreLabel.Text = _score.ToString();
                    }

                }

                if (questionsAndAnswersObject.QuestionsId == _questionNumber)
                {
                 
                    QuestionLabel.Text = questionsAndAnswersObject.Question;
                    AnswerAlt1.Text = questionsAndAnswersObject.AnswerAlt1;
                    AnswerAlt2.Text = questionsAndAnswersObject.AnswerAlt2;
                    AnswerAlt3.Text = questionsAndAnswersObject.AnswerAlt3;
                    AnswerAlt4.Text = questionsAndAnswersObject.AnswerAlt4;
                    
                }


                /*                      intQuestionID = objQuestion.intQuestionID;
                                        strQuestionDescription = objQuestion.strQuestionDescription;
                                        radioButton1.Text = objQuestion.strAnswer1Description;
                                        radioButton2.Text = objQuestion.strAnswer2Description;
                                        radioButton3.Text = objQuestion.strAnswer3Description;
                                        intCorrectAnswerID = objQuestion.intCorrectAnswerID;
                                        strCorrectAnswerDescription = objQuestion.strCorrectAnswerDescription;
                                        Session["m_strAnswer1Description"] = objQuestion.strAnswer1Description;
                                        Session["m_strAnswer2Description"] = objQuestion.strAnswer2Description;
                                        Session["m_strAnswer3Description"] = objQuestion.strAnswer3Description;
                                        Session["m_intCorrectAnswerID"] = intCorrectAnswerID;
                                        Session["m_strQuestionDescription"] = strQuestionDescription;
                                        Session["m_strCorrectAnswerDescription"] = strCorrectAnswerDescription;*/
            }


            _questionNumber++;
            Session["questionNumber"] = _questionNumber;

            QuestionLabel.Visible = true;
            AnswerAlt1.Visible = true;
            AnswerAlt2.Visible = true;
            AnswerAlt3.Visible = true;
            AnswerAlt4.Visible = true;
            R1.Visible = true;
            R2.Visible = true;
            R3.Visible = true;
            R4.Visible = true;
            R1.Checked = true;
            R2.Checked = false;
            R3.Checked = false;
            R4.Checked = false;



            if (_questionNumber>20)
            {
                Button1.Text = "Siste spørsmål! Se resultat :)";
            }


        }
    }
}