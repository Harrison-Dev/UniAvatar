using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;
using UnityEngine.EventSystems;

namespace UniAvatar
{
    public class ChoiceView : UIBehaviour
    {
        [SerializeField] private Animator m_choiceAnimator;

        public Button Choice1;
        public Button Choice2;

#if TMP_SUPPORT
        private TMP_Text m_c1TMP;
        private TMP_Text m_c2TMP;
#else
        private Text m_c1Text;
        private Text m_c2Text;
#endif
        private IDisposable m_sub1;
        private IDisposable m_sub2;

        [Inject] private IFlagController _flagController;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        private void Init()
        {
#if TMP_SUPPORT
            m_c1TMP = Choice1.GetComponentInChildren<TMP_Text>();
            m_c2TMP = Choice2.GetComponentInChildren<TMP_Text>();
#else
            m_c1Text = Choice1.GetComponentInChildren<Text>();
            m_c2Text = Choice2.GetComponentInChildren<Text>();
#endif
        }

        public void ShowChoice(string flag, string c1Text, string c2Text, string c1Value, string c2Value, System.Action callback)
        {
#if TMP_SUPPORT
            m_c1TMP.text = c1Text;
            m_c2TMP.text = c2Text;
#else
            m_c1Text.text = c1Text;
            m_c2Text.text = c2Text; ;
#endif

            m_choiceAnimator.SetBool("Show", true);

            m_sub1 =
            Choice1.OnClickAsObservable()
                   .First()
                   .Subscribe(_ =>
                   {
                       _flagController.Set(flag, c1Value);
                       m_choiceAnimator.SetBool("Show", false);
                       m_sub1?.Dispose();
                       m_sub2?.Dispose();
                       Observable.Interval(TimeSpan.FromSeconds(1))
                                 .First()
                                 .Subscribe(__ => callback.Invoke());
                   });
            m_sub2 =
            Choice2.OnClickAsObservable()
                   .First()
                   .Subscribe(_ =>
                   {
                       _flagController.Set(flag, c2Value);
                       m_choiceAnimator.SetBool("Show", false);
                       m_sub1?.Dispose();
                       m_sub2?.Dispose();
                       Observable.Interval(TimeSpan.FromSeconds(1))
                                 .First()
                                 .Subscribe(__ => callback.Invoke());
                   });

        }

    }
}