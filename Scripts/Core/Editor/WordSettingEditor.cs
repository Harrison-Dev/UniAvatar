using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniAvatar;

[CustomEditor(typeof(WordSetting))]
public class WordSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        bool clickBtn = GUILayout.Button("Setup Word Setting");
        if (clickBtn)
        {
            var wordSetting = (WordSetting)target;
            wordSetting.SetUpWord();
            EditorUtility.SetDirty(wordSetting);
            AssetDatabase.SaveAssets();
        }

        base.OnInspectorGUI();
    }
}
