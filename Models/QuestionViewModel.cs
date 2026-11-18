using System.ComponentModel.DataAnnotations;

namespace Quiz.Models;

public class QuestionViewModel
{
    public int QuestionId { get; set; }
    public int Number { get; set; }
    public int Total { get; set; }
    public string Text { get; set; } = "";
    public string[] Answers { get; set; } = [];

    [Required(ErrorMessage = "Choose one answer to continue.")]
    [Range(0, 3, ErrorMessage = "Choose one of the four answers.")]
    public int? SelectedAnswer { get; set; }
}
