﻿// Licensed to the .NET Foundation under one or more agreements.

namespace CS1L.Shared.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string urlImage { get; set; }
    public IList<Answer> CorrectAnswers { get; set; } = new List<Answer>();
    public IList<Answer> AllAnswers { get; set; } = new List<Answer>();
}
   
