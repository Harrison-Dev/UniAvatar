using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    [Serializable]
    public class WordData
    {
        public string PrimaryKey;
        public string[] Contents;
    }

    [CreateAssetMenu(fileName = "WordSetting", menuName = "UniAvatar/WordSetting")]
    public class WordSetting : ScriptableObject
    {
        public TextAsset DataCSV;
        public List<WordData> WordSheet = new List<WordData>();

        public void ConvertCSV()
        {
            string dataStr = DataCSV.text;

            var grid = CSVReader.SplitCsvGrid(dataStr);

            WordSheet = new List<WordData>();

            for (var i = 1; i < grid.GetLength(1); i++)
            {
                WordData data = new WordData();
                data.PrimaryKey = grid[0, i];
                int colLen = grid.GetLength(0);
                data.Contents = new string[colLen - 1];
                for (var j = 1; j < colLen; j++)
                {
                    data.Contents[j - 1] = grid[j, i];
                }
                WordSheet.Add(data);
            }

            GC.Collect();
        }
    }
}