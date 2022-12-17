
namespace CS1L.Shared.Models;

public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string Text { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public IList<Answer> Answers { get; set; } = new List<Answer>();
}
   
