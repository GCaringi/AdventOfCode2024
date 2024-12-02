using CodeRunner.Common;
using CodeRunner.Day2.Inputs;

namespace CodeRunner.Day2;

public class Day2(InputType type)
{
    private readonly string _filename = type.ToString();

    public int GetPositiveSafeReport()
    {
        var input = GetInput();

        int positiveCount = 0;
        
        foreach (var row in input.Matrix)
        {
            bool safe = true;
            bool decreasing = row[1] < row[0];
            
            //Define limits
            int minDiff = decreasing ? -3 : 1;
            int maxDiff = decreasing ? -1 : 3;
            
            for (var i = 0; i < row.Count - 1; i++)
            {
                if (row[i + 1] < row[i] + minDiff || row[i + 1] > row[i] + maxDiff)
                {
                    safe = false;
                    break;
                }
            }

            positiveCount = safe ? positiveCount +1 : positiveCount;
        }
        
        return positiveCount;
    }
    public int GetPositiveSafeReportWithDampener()
    {
        var input = GetInput();

        int positiveCount = 0;
        
        foreach (var row in input.Matrix)
        {
            for (int j = 0; j < row.Count; j++)
            {
                int probablyIssue = row[j];
                row.RemoveAt(j);
                
                bool firstIssue = false;
                bool decreasing = row[1] < row[0];
            
                //Define limits
                int minDiff = decreasing ? -3 : 1;
                int maxDiff = decreasing ? -1 : 3;
                
            
                for (int i = 0; i < row.Count - 1; i++)
                {
                    if (row[i + 1] < row[i] + minDiff || row[i + 1] > row[i] + maxDiff)
                    {
                        firstIssue = true;
                        break;
                    }
                }

                if (!firstIssue)
                {
                    positiveCount++;
                    break;
                }
                
                row.Insert(j, probablyIssue);
            }
        }
        
        return positiveCount;
    }

    private Day2InputData GetInput()
    {
        var result = new Day2InputData();
        
        var lines = File.ReadAllLines($"../../../Day2/Inputs/{_filename}.txt");
        
        foreach (var line in lines)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var row = values.Select(int.Parse).ToList();

            result.Matrix.Add(row);
        }
        
        return result;
    }
}