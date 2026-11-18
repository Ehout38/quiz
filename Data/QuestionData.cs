using Quiz.Models;

namespace Quiz.Data;

public static class QuestionData
{
    public static readonly IReadOnlyList<Question> Questions = new List<Question>
    {
        new() { Id = 1, Text = "Which keyword defines a class in C#?", Answers = ["class", "function", "define", "module"], CorrectAnswer = 0 },
        new() { Id = 2, Text = "Which type stores true or false?", Answers = ["string", "bool", "double", "char"], CorrectAnswer = 1 },
        new() { Id = 3, Text = "Which collection grows dynamically?", Answers = ["int", "bool", "List<T>", "char"], CorrectAnswer = 2 },
        new() { Id = 4, Text = "Which HTTP method is normally used to read a page?", Answers = ["DELETE", "PATCH", "POST", "GET"], CorrectAnswer = 3 },
        new() { Id = 5, Text = "What does MVC stand for?", Answers = ["Model View Controller", "Main Virtual Class", "Model Value Container", "Module View Code"], CorrectAnswer = 0 },
        new() { Id = 6, Text = "Which Tag Helper binds an input to a model property?", Answers = ["asp-action", "asp-for", "asp-controller", "asp-route-id"], CorrectAnswer = 1 },
        new() { Id = 7, Text = "Which symbol starts an expression in a Razor view?", Answers = ["#", "$", "@", "%"], CorrectAnswer = 2 },
        new() { Id = 8, Text = "Which status code means a page was not found?", Answers = ["200", "201", "302", "404"], CorrectAnswer = 3 }
    }.AsReadOnly();
}
