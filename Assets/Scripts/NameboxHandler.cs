using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UniAvatar
{
    public class NameboxHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text m_nameBox;

        public void SetName(string name)
        {
            m_nameBox.text = name;
        }
    }
}