namespace Quiz.Models;

public class ResultViewModel
{
    public int Correct { get; set; }
    public int Total { get; set; }
    public int Percentage => (int)Math.Round(100.0 * Correct / Total);
    public List<ResultItem> Items { get; set; } = [];
}

public class ResultItem
{
    public string Question { get; set; } = "";
    public string Selected { get; set; } = "";
    public string Correct { get; set; } = "";
    public bool IsCorrect { get; set; }
}
