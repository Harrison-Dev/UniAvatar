using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitMotion;

namespace UniAvatar
{
    public class CharacterHandler : AnimationTargetBase, IFlip, IPan, ITint, IJump, ISpriteChange
    {
        private Image m_targetImage;
        private MotionHandle? m_panTween;
        private MotionHandle? m_tintTween;

        [SerializeField]
        private Animator m_jumpAnimator;

        protected void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_targetImage = transform.GetComponentInChildren<Image>();
        }

        public void Flip()
        {
            float currentFlip = transform.localScale.x;
            transform.localScale = new Vector3(currentFlip * -1, 1, 1);
        }

        public void Pan(float localValue, float time)
        {
            var curPos = m_targetImage.transform.localPosition;
            var nextPos = new Vector3(curPos.x, localValue, curPos.z);
            m_panTween = LMotion.Create(curPos, nextPos, time)
                                .WithEase(Ease.OutSine)
                                .Bind(t => m_targetImage.transform.localPosition = t);
        }

        public void Tint(Color tintTarget, float time)
        {
            m_tintTween = LMotion.Create(m_targetImage.color, tintTarget, time)
                                 .WithEase(Ease.OutQuad)
                                 .Bind(t => m_targetImage.color = t);
        }

        public void InterruptPan()
        {
            // m_panTween?.Kill();
            if (!m_panTween.HasValue) return;
            m_panTween.Value.Cancel();
            m_panTween = null;
        }

        public void InterruptTint()
        {
            if (!m_tintTween.HasValue) return;
            m_tintTween.Value.Cancel();
            m_tintTween = null;
        }

        public void Jump()
        {
            m_jumpAnimator?.SetTrigger("Jump");
        }

        public void InterruptJump()
        {
            // Do nothing.
        }

        public void Change(Sprite sprite)
        {
            m_targetImage.sprite = sprite;
        }
    }
}