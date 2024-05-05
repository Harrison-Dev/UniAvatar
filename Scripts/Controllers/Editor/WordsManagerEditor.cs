using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UniAvatar
{
    [CustomEditor(typeof(WordsController))]
    public class WordsControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var ControllerTarget = (WordsController)target;
            if (ControllerTarget.WordSetting == null)
                return;
            else
            {
                List<string> list = new List<string>();

                foreach (var language in ControllerTarget.WordSetting.Languages)
                {
                    list.Add(language);
                }

                int index = ControllerTarget.CurrentLanaguage;

                ControllerTarget.CurrentLanaguage = EditorGUILayout.Popup("Language ", index, list.ToArray());
            }

        }
    }
}