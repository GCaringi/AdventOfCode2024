using CodeRunner.Common;
using CodeRunner.Day1.Inputs;

namespace CodeRunner.Day1;

public class Day1(InputType type)
{
    private readonly string _filename = type.ToString();


    public int CalculateDistance()
    {
        var input = GetInput();

        input.FirstColumn = input.FirstColumn.Order().ToList();
        input.SecondColumn = input.SecondColumn.Order().ToList();

        return input.FirstColumn.Select((actualNumber, index) => Math.Abs(actualNumber - input.SecondColumn[index])).Sum();
    }

    public int CalculateSimilarity()
    {
        var input = GetInput();

        return input.FirstColumn.Sum(actualNumber => actualNumber * (input.SecondColumn.Count(n => n == actualNumber)));  
    }
    
    private Day1InputData GetInput()
    {
        var result = new Day1InputData();
        
        var lines = File.ReadAllLines($"../../../Day1/Inputs/{_filename}.txt");

        foreach (var line in lines)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            result.FirstColumn.Add(int.Parse(values[0]));
            result.SecondColumn.Add(int.Parse(values[1]));
        }
        
        return result;
    }
}