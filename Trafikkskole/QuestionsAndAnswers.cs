namespace Trafikkskole
{
    public class QuestionsAndAnswers
    {
        public int QuestionsId { get; set; }
        public string Question { get; set; }
        public string AnswerAlt1 { get; set; }
        public string AnswerAlt2 { get; set; }
        public string AnswerAlt3 { get; set; }
        public string AnswerAlt4 { get; set; }
        public int IsCorrectAlt1 { get; set; }
        public int IsCorrectAlt2 { get; set; }
        public int IsCorrectAlt3 { get; set; }
        public int IsCorrectAlt4 { get; set; }
        public int MultipleChoice { get; set; }
        public int IsUrl { get; set; }
        public string Url { get; set; }
    }
}