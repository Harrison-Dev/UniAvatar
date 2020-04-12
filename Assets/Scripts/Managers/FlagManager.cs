using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    [System.Serializable]
    public class Flag
    {
        public Flag(string key)
        {
            this.Key = key;
        }
        public string Key;
        public int Value;
    }

    public class FlagManager : MonoSingleton<FlagManager>
    {
        public FlagSetting FlagSetting;
        public List<Flag> RuntimeFlags = new List<Flag>();
        private Dictionary<string, Flag> m_flagMap = new Dictionary<string, Flag>();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            foreach (var flag in FlagSetting.Flags)
            {
                RuntimeFlags.Add(new Flag(flag));
            }

            m_flagMap = RuntimeFlags.ToDictionary(key => key.Key, value => value);
        }

        public void Set(string flagName, int value)
        {
            if (m_flagMap.ContainsKey(flagName) == false)
            {
                Debug.LogError($"Not found a flag named {flagName}");
                return;
            }

            m_flagMap[flagName].Value = value;
        }

        public int Get(string flagName)
        {
            if (m_flagMap.ContainsKey(flagName) == false)
            {
                Debug.LogError($"Not found a flag named {flagName}");
                return -1;
            }

            return m_flagMap[flagName].Value;
        }

    }
}