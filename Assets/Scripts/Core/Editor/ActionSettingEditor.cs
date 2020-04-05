using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniAvatar;

[CustomEditor(typeof(ActionSetting))]
public class ActionSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        bool clickBtn = GUILayout.Button("Setup Action Setting");
        if (clickBtn)
        {
            var actionSetting = (ActionSetting)target;
            actionSetting.SetUpActions();
            EditorUtility.SetDirty(actionSetting);
            AssetDatabase.SaveAssets();
        }

        base.OnInspectorGUI();
    }
}
