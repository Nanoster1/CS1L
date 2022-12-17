// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CS1L.Shared.Models;

public record Question(
    int Id,
    string Test,
    string urlImage,
    IList<Answer> CorrectAnswers,
    IList<Answer> IncorrectAnswers);
