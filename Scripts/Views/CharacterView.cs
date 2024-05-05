using UnityEngine;
using UnityEngine.UI;
using LitMotion;

namespace UniAvatar
{
    public class CharacterView : AnimationTargetBase, IFlip, IPan, ITint, IJump, ISpriteChange
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

        public void Jump()
        {
            m_jumpAnimator?.SetTrigger("Jump");
        }

        public void Change(Sprite sprite)
        {
            m_targetImage.sprite = sprite;
        }

        public void Interrupt()
        {
            m_panTween?.Cancel(); m_panTween = null;
            m_tintTween?.Cancel(); m_tintTween = null;
        }
    }
}