using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class WordsManager : MonoSingleton<WordsManager>
    {
        public TextAsset WordsCSV;

        private Dictionary<string, string> m_wordMap = new Dictionary<string, string>();

        private void Init()
        {
            
        }

        private void Start()
        {
            
        }
        
    }
}