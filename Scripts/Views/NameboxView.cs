using UnityEngine;
using UnityEngine.UI;

namespace UniAvatar
{
    public class NameboxView : MonoBehaviour
    {

        [SerializeField]
        private GameObject m_nameBox;

#if TMP_SUPPORT
        private TMP_Text m_nameBoxTMP;
#else
        private Text m_nameBoxText;
#endif

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
#if TMP_SUPPORT
            m_nameBoxTMP = m_nameBox.GetComponent<TMP_Text>();
#else
            m_nameBoxText = m_nameBox.GetComponent<Text>();
#endif
        }

        public void SetName(string name)
        {
#if TMP_SUPPORT
            m_nameBoxTMP.text = name;
#else
            m_nameBoxText.text = name;
#endif
        }
    }
}