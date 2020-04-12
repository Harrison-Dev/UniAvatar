using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniAvatar;

[CustomEditor(typeof(FlagSetting))]
public class FlagSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        bool clickBtn = GUILayout.Button("Setup Flag Setting");
        if (clickBtn)
        {
            var flagSetting = (FlagSetting)target;
            flagSetting.SetUpFlag();
            EditorUtility.SetDirty(flagSetting);
            AssetDatabase.SaveAssets();
        }

        base.OnInspectorGUI();
    }
}
