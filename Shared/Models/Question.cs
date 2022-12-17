// Licensed to the .NET Foundation under one or more agreements.

namespace CS1L.Shared.Models;

public class Question
{
    private int Id { get; set; }
    private string Test { get; set; }
    private string urlImage { get; set; }
    private IList<Answer> CorrectAnswers { get; set; }
    private IList<Answer> IncorrectAnswers { get; set; }
}
   
