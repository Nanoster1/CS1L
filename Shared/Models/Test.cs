
namespace CS1L.Shared.Models;

public class Test
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<Question> Questions { get; set; } = new List<Question>();

}
