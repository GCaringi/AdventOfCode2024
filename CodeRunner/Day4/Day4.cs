using System.Text;
using CodeRunner.Common;
using CodeRunner.Day4.Inputs;

namespace CodeRunner.Day4;

public class Day4(InputType type)
{
    private readonly string _filename = type.ToString();
    private readonly char[] targetSymbol = ['M', 'A', 'S'];
    public int SearchXmasWords()
    {
        var input = GetInput();

        int numberXmasWord = 0;
        
        for (var i = 0; i < input.Matrix.Count; i++)
        {
            for (var j = 0; j < input.Matrix[i].Count; j++)
            {
                if (input.Matrix[i][j] == 'X')
                {
                    bool correctValue = true;
                    int count = 0;
                    
                    //Check left-up - up - right-up
                    if (i >= 3)
                    {
                        correctValue = true;
                        var mobileIndex = i-1;
                        count = 0;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[mobileIndex][j] == targetSymbol[count])
                            {
                                mobileIndex -= 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }

                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    if (i >= 3 && j >= 3)
                    {   
                        correctValue = true;
                        count = 0;
                        
                        var verticalIndex = i-1;
                        var orizontalIndex = j-1;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex -= 1;
                                orizontalIndex -= 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    if (i >= 3 && j <= input.Matrix[i].Count - 4)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var verticalIndex = i-1;
                        var orizontalIndex = j+1;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex]== targetSymbol[count])
                            {
                                verticalIndex -= 1;
                                orizontalIndex += 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    //Check left - right
                    if (j >= 3)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var mobileIndex = j-1;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[i][mobileIndex] == targetSymbol[count])
                            {
                                mobileIndex -= 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    if (j <= input.Matrix[i].Count - 4)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var mobileIndex = j+1;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[i][mobileIndex] == targetSymbol[count])
                            {
                                mobileIndex += 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    //Check left-down - down - right-down
                    if (i <= input.Matrix.Count - 4)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var mobileIndex = i+1;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[mobileIndex][j] == targetSymbol[count])
                            {
                                mobileIndex += 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    if (i <= input.Matrix.Count - 4 && j >= 3)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var verticalIndex = i+1;
                        var orizontalIndex = j-1;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex += 1;
                                orizontalIndex -= 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                    
                    if (i <= input.Matrix.Count - 4 && j <= input.Matrix.Count - 4)
                    {
                        correctValue = true;
                        count = 0;
                        
                        var verticalIndex = i+1;
                        var orizontalIndex = j+1;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex += 1;
                                orizontalIndex += 1;
                                count++;
                            }
                            else
                            {
                                correctValue = false;
                            }
                        }
                        
                        if (count == 3)
                        {
                            numberXmasWord++;
                        }
                    }
                }
            }
        }
        
        
        return numberXmasWord;
    }
    
    public int SearchCrossXmasWords()
    {
        var input = GetInput();

        int numberXmasWord = 0;
        
        for (var i = 0; i < input.Matrix.Count; i++)
        {
            for (var j = 0; j < input.Matrix[i].Count; j++)
            {
                if (input.Matrix[i][j] == 'A')
                {
                    if (i != 0 && i < input.Matrix.Count - 1 && j != 0 && j < input.Matrix[i].Count - 1)
                    {
                        var firstString = string.Concat([
                            input.Matrix[i - 1][j - 1],input.Matrix[i][j],input.Matrix[i+1][j+1]
                        ]);

                        var secondString = string.Concat([
                            input.Matrix[i - 1][j + 1],input.Matrix[i][j],input.Matrix[i+1][j-1]
                        ]);

                        var reverseString = string.Concat(secondString.Reverse());

                        if ((firstString.Equals("SAM") || firstString.Equals("MAS")) && (firstString == secondString || firstString == reverseString))
                        {
                            numberXmasWord++;
                        }
                    }
                }
            }
        }
        
        
        return numberXmasWord;
    }
    
    private Day4InputData GetInput()
    {
        var result = new Day4InputData();
        
        var lines = File.ReadAllLines($"../../../Day4/Inputs/{_filename}.txt");
        
        foreach (var line in lines)
        {
            var row = new List<char>();

            var values = line.ToCharArray();

            row.AddRange(values);

            result.Matrix.Add(row);
        }
        
        return result;
    }
}