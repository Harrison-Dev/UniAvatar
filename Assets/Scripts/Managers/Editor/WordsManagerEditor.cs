using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UniAvatar
{
    [CustomEditor(typeof(WordsManager))]
    public class WordsManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var managerTarget = (WordsManager)target;
            if (managerTarget.WordSetting == null)
                return;
            else
            {
                List<string> list = new List<string>();

                foreach (var language in managerTarget.WordSetting.Languages)
                {
                    list.Add(language);
                }

                int index = managerTarget.CurrentLanaguage;

                managerTarget.CurrentLanaguage = EditorGUILayout.Popup("Language ", index, list.ToArray());
            }

        }
    }
}