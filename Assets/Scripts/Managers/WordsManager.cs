using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class WordsManager : MonoSingleton<WordsManager>
    {
        public WordSetting WordSetting;

        [HideInInspector]
        public int CurrentLanaguage = 0;

        private Dictionary<string, WordData> m_wordSettingMap;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_wordSettingMap = WordSetting.WordSheet.ToDictionary(x => x.PrimaryKey);
        }

        public string GetSWordByKey(string key)
        {
            return m_wordSettingMap[key].Contents[CurrentLanaguage];
        }

    }
}