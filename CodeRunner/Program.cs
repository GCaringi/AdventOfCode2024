using CodeRunner.Common;
using CodeRunner.Day1;
using CodeRunner.Day2;

Console.WriteLine("Welcome to the Advent of Code 2024");

#region Instanciate Days Entities

Day1 day1 = new(InputType.Input);
Day2 day2 = new Day2(InputType.Example);

#endregion

#region Running Exercises

//Console.WriteLine(day1.CalculateDistance());
//Console.WriteLine(day1.CalculateSimilarity());

Console.WriteLine(day2.GetPositiveSafeReport());
Console.WriteLine(day2.GetPositiveSafeReportWithDampener());

#endregion