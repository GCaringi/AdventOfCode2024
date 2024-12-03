using System.Text.RegularExpressions;
using CodeRunner.Common;

namespace CodeRunner.Day3;

public class Day3(InputType type)
{
    private readonly string _filename = type.ToString();

    public long CalculateMult()
    {
        var content = File.ReadAllText($"../../../Day3/Inputs/{_filename}.txt");
        
        var matches = Regex.Matches(content, @"mul[(]\d+,\d+[)]");

        long totalSum = 0; 
        
        foreach (Match match in matches)
        {
            var numberMatches = Regex.Matches(match.Value, @"\d+");

            var localMult = 1;
            
            foreach (Match number in numberMatches)
            {
                localMult *= int.Parse(number.Value);
            }
            
            totalSum += localMult;
        }
        
        return totalSum;
    }

    public long CalculateMultWithCommand()
    {
        var content = File.ReadAllText($"../../../Day3/Inputs/{_filename}.txt");
        
        long totalSum = 0; 
        
        var calculateArray = content.Split("do()", StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int i = 0; i < calculateArray.Count; i++)
        {
            var actualPart = calculateArray[i];
            
            actualPart = actualPart.Split("don't()", StringSplitOptions.RemoveEmptyEntries)[0];
            
            var matches = Regex.Matches(actualPart, @"mul[(]\d+,\d+[)]");
            
            foreach (Match match in matches)
            {
                var numberMatches = Regex.Matches(match.Value, @"\d+");

                var localMult = 1;
            
                foreach (Match number in numberMatches)
                {
                    localMult *= int.Parse(number.Value);
                }
            
                totalSum += localMult;
            }
        }
        
        return totalSum;
    }
}