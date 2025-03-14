namespace MyTestTask.Entities;

public class Interview
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public List<Result> Results { get; set; }
}