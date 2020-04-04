using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public static class CSVReader
{
    static public void DebugOutputGrid(string[,] grid)
    {
        string textOutput = "";
        for (int y = 0; y < grid.GetUpperBound(1); y++)
        {
            for (int x = 0; x < grid.GetUpperBound(0); x++)
            {

                textOutput += grid[x, y];
                textOutput += "|";
            }
            textOutput += "\n";
        }
        Debug.Log(textOutput);
    }

    // splits a CSV file into a 2D string array
    static public string[,] SplitCsvGrid(string csvText)
    {
        string[] lines = csvText.Split("\n"[0]);

        // finds the max width of row
        int width = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = SplitCsvLine(lines[i]);
            width = Mathf.Max(width, row.Length);
        }

        // creates new 2D string grid to output to
        string[,] outputGrid = new string[width, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = SplitCsvLine(lines[y]);
            for (int x = 0; x < row.Length; x++)
            {
                outputGrid[x, y] = row[x];

                // This line was to replace "" with " in my output. 
                // Include or edit it as you wish.
                outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
            }
        }

        return outputGrid;
    }

    private static string[] SplitCsvLine(string line)
    {
        List<string> result = new List<string>();
        string[] word = line.Split(',');

        bool hasOddQuota = false;
        for (int i = 0; i < word.Length; i++)
        {
            StringBuilder sb = new StringBuilder(word[i]);
            do
            {
                int countQuota = 0;
                for (int j = 0; j < word[i].Length; j++)
                {
                    if (word[i][j] == '"') countQuota++;
                }
                hasOddQuota = countQuota % 2 == 1 ^ hasOddQuota;
                if (hasOddQuota)
                {
                    i++;
                    sb.Append("," + word[i]);
                }
            } while (hasOddQuota);

            string s = sb.ToString();
            if (s.Length >= 2 && s[0] == '"')
                s = s.Remove(sb.Length - 1, 1).Remove(0, 1).Replace("\"\"", "\"");
            result.Add(s);
        }

        return result.ToArray();
    }
}