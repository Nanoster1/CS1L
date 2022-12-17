
namespace CS1L.Shared.Models;

public class Question
{
    public string Text { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public IList<Answer> Answers { get; set; } = new List<Answer>();
}
