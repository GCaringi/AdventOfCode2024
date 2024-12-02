using CodeRunner.Common;
using CodeRunner.Day1;

Console.WriteLine("Welcome to the Advent of Code2024 code runner");

#region Instanciate Days Entities

Day1 day1 = new(InputType.Input);

#endregion

#region Running Exercises

Console.WriteLine(day1.CalculateDistance());
Console.WriteLine(day1.CalculateSimilarity());

#endregion

Console.ReadKey();