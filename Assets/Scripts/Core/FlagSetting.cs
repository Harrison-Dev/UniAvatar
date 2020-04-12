using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utopia;
using TMPro;

namespace UniAvatar
{

    [CreateAssetMenu(fileName = "FlagSetting", menuName = "UniAvatar/FlagSetting")]
    public class FlagSetting : ScriptableObject
    {
        [Header("Word Settings")]
        public TextAsset WordsheetCSV;
        public List<string> Flags;

        public void SetUpFlag()
        {
            string dataStr = WordsheetCSV.text;

            var grid = CSVReader.SplitCsvGrid(dataStr);

            Flags = new List<string>();

            for (var i = 1; i < grid.GetLength(1); i++)
            {
                Flags.Add(grid[0, i]);
            }

            GC.Collect();
        }
    }
}