// Licensed to the .NET Foundation under one or more agreements.

namespace CS1L.Shared.Models;

public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string Text { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public IList<Answer> CorrectAnswers { get; set; } = new List<Answer>();
    public IList<Answer> IncorrectAnswers { get; set; } = new List<Answer>();
}

