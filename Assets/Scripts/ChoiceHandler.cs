using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

namespace UniAvatar
{
    public class ChoiceHandler : MonoBehaviour
    {
        [SerializeField] private Animator m_choiceAnimator;

        public Button Choice1;
        public Button Choice2;

        private TMP_Text m_c1Text;
        private TMP_Text m_c2Text;

        private IDisposable m_sub1;
        private IDisposable m_sub2;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_c1Text = Choice1.GetComponentInChildren<TMP_Text>();
            m_c2Text = Choice2.GetComponentInChildren<TMP_Text>();
        }

        public void ShowChoice(string flag, string c1Text, string c2Text, string c1Value, string c2Value, System.Action callback)
        {
            m_c1Text.text = c1Text;
            m_c2Text.text = c2Text;

            m_choiceAnimator.SetBool("Show", true);

            m_sub1 =
            Choice1.OnClickAsObservable()
                   .First()
                   .Subscribe(_ =>
                   {
                       FlagManager.Instance.Set(flag, c1Value);
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
                       FlagManager.Instance.Set(flag, c2Value);
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