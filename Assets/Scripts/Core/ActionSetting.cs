using System;
using System.Collections;
using System.Collections.Generic;
using Utopia;
using UnityEngine;

namespace UniAvatar
{
    [Serializable]
    public class ActionData
    {
        public int Step;
        public string Type;
        public string Arg1;
        public string Arg2;
        public string Arg3;
        public string Arg4;
    }

    [CreateAssetMenu(fileName = "ActionSetting", menuName = "UniAvatar/ActionSetting")]
    public class ActionSetting : ScriptableObject
    {
        public TextAsset ActionsheetCSV;
        public List<ActionData> ActionDatas = new List<ActionData>();


        public void SetUpActions()
        {
            string dataStr = ActionsheetCSV.text;

            var grid = CSVReader.SplitCsvGrid(dataStr);
            ActionDatas = new List<ActionData>();

            for (var i = 1; i < grid.GetLength(1); i++)
            {
                ActionData data = new ActionData();
                data.Step = Int32.Parse(grid[0, i]);
                data.Type = grid[1, i];
                data.Arg1 = grid[2, i];
                data.Arg2 = grid[3, i];
                data.Arg3 = grid[4, i];
                data.Arg4 = grid[4, i];


                if (!string.IsNullOrEmpty(data.Type))
                    ActionDatas.Add(data);
            }
        }
    }
}