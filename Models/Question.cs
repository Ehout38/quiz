namespace Quiz.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public string[] Answers { get; set; } = [];
    public int CorrectAnswer { get; set; }
}
