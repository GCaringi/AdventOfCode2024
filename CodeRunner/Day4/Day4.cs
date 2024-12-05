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
                    //Controllo in alto
                    if (i >= 3)
                    {
                        var mobileIndex = i;
                        count = 0;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[mobileIndex][j] == targetSymbol[count])
                            {
                                mobileIndex = -1;
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

                    //Controllo in alto a sinistra
                    if (i >= 3 && j >= 3)
                    {
                        count = 0;
                        
                        var verticalIndex = i;
                        var orizontalIndex = j;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex = -1;
                                orizontalIndex = -1;
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

                    //Controllo in alto a destra
                    if (i >= 3 && j <= input.Matrix[i].Count - 4)
                    {
                        count = 0;
                        
                        var verticalIndex = i;
                        var orizontalIndex = j;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex]== targetSymbol[count])
                            {
                                verticalIndex = -1;
                                orizontalIndex = +1;
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
                    //Controllo la sinistra
                    if (j >= 3)
                    {
                        var mobileIndex = j;
                        count = 0;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[i][mobileIndex] == targetSymbol[count])
                            {
                                mobileIndex = -1;
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
                    
                    //Controllo la destra
                    if (j <= input.Matrix[i].Count - 4)
                    {
                        var mobileIndex = i;
                        count = 0;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[i][mobileIndex] == targetSymbol[count])
                            {
                                mobileIndex = +1;
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
                    //Controllo in basso
                    if (i <= input.Matrix.Count - 4)
                    {
                        var mobileIndex = i;
                        count = 0;
                        
                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[mobileIndex][j] == targetSymbol[count])
                            {
                                mobileIndex = +1;
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
                    
                    //Controllo in basso a sinistra
                    if (i <= input.Matrix.Count - 4 && j >= 3)
                    {
                        count = 0;
                        
                        var verticalIndex = i;
                        var orizontalIndex = j;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex = +1;
                                orizontalIndex = -1;
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
                    
                    //Controllo in basso a destra
                    if (i <= input.Matrix.Count - 4 && j <= input.Matrix.Count - 4)
                    {
                        count = 0;
                        
                        var verticalIndex = i;
                        var orizontalIndex = j;

                        while (count < 3 && correctValue)
                        {
                            if (input.Matrix[verticalIndex][orizontalIndex] == targetSymbol[count])
                            {
                                verticalIndex = +1;
                                orizontalIndex = +1;
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