using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data;
using Quiz.Models;

namespace Quiz.Controllers;

public class QuizController : Controller
{
    private const string SessionKey = "QuizState";

    public IActionResult Index() => View(QuestionData.Questions.Count);

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Start()
    {
        Save(new QuizState());
        return RedirectToAction(nameof(Question));
    }

    public IActionResult Question()
    {
        var state = Load();
        if (state == null) return RedirectToAction(nameof(Index));
        if (state.Answers.Count >= QuestionData.Questions.Count)
            return RedirectToAction(nameof(Result));
        return View(CreateQuestion(state));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Answer(QuestionViewModel model)
    {
        var state = Load();
        if (state == null) return RedirectToAction(nameof(Index));
        if (state.Answers.Count >= QuestionData.Questions.Count)
            return RedirectToAction(nameof(Result));

        var current = CreateQuestion(state);
        if (model.QuestionId != current.QuestionId)
            return RedirectToAction(nameof(Question));
        if (!ModelState.IsValid) return View("Question", current);

        state.Answers.Add(model.SelectedAnswer!.Value);
        Save(state);
        return RedirectToAction(nameof(Question));
    }

    public IActionResult Result()
    {
        var state = Load();
        if (state == null) return RedirectToAction(nameof(Index));
        if (state.Answers.Count < QuestionData.Questions.Count)
            return RedirectToAction(nameof(Question));

        var items = QuestionData.Questions.Select((question, index) => new ResultItem
        {
            Question = question.Text,
            Selected = question.Answers[state.Answers[index]],
            Correct = question.Answers[question.CorrectAnswer],
            IsCorrect = state.Answers[index] == question.CorrectAnswer
        }).ToList();

        return View(new ResultViewModel
        {
            Correct = items.Count(item => item.IsCorrect),
            Total = items.Count,
            Items = items
        });
    }

    private QuizState? Load()
    {
        var json = HttpContext.Session.GetString(SessionKey);
        return json == null ? null : JsonSerializer.Deserialize<QuizState>(json);
    }

    private void Save(QuizState state) =>
        HttpContext.Session.SetString(SessionKey, JsonSerializer.Serialize(state));

    private static QuestionViewModel CreateQuestion(QuizState state)
    {
        var question = QuestionData.Questions[state.Answers.Count];
        return new QuestionViewModel
        {
            QuestionId = question.Id,
            Number = state.Answers.Count + 1,
            Total = QuestionData.Questions.Count,
            Text = question.Text,
            Answers = question.Answers
        };
    }
}
