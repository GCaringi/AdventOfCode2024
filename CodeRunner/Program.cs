using CodeRunner.Common;
using CodeRunner.Day1;
using CodeRunner.Day2;
using CodeRunner.Day3;
using CodeRunner.Day4;

Console.WriteLine("Welcome to the Advent of Code 2024");

#region Instanciate Days Entities

Day1 day1 = new(InputType.Input);
Day2 day2 = new(InputType.Input);
Day3 day3 = new(InputType.Input);
Day4 day4 = new(InputType.Example);

#endregion

#region Running Exercises

//Console.WriteLine(day1.CalculateDistance());
//Console.WriteLine(day1.CalculateSimilarity());

//Console.WriteLine(day2.GetPositiveSafeReport());
//Console.WriteLine(day2.GetPositiveSafeReportWithDampener());

//Console.WriteLine(day3.CalculateMult());
//Console.WriteLine(day3.CalculateMultWithCommand());

Console.WriteLine(day4.SearchXmasWords());

#endregion