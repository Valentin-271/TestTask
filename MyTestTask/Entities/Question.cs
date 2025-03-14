namespace MyTestTask.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int SurveyId { get; set; }
    public List<Answer> Answers { get; set; }
}