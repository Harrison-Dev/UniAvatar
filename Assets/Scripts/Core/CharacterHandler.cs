using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UniAvatar
{
    public class CharacterHandler : AnimationTargetBase, IFlip, IPan, ITint
    {
        private Dictionary<System.Type, Tween> m_animationMap = new Dictionary<System.Type, Tween>();

        private Image m_targetImage;

        protected override void Awake()
        {
            base.Awake();
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

        public void Flip(System.Type anim)
        {
            // No Register : A one step animation.
            Flip();
        }

        public void Pan(System.Type anim, float localValue, float time)
        {
            var tween = m_targetImage.transform.DOLocalMoveY(localValue, time);
            tween.SetEase(Ease.OutSine);
            m_animationMap.Add(anim, tween);

            tween.OnComplete(() => m_animationMap.Remove(anim));
            tween.OnKill(() =>
            {
                m_animationMap.Remove(anim);
                m_targetImage.transform.SetLocalPositionY(localValue);
            });
        }

        public void Tint(System.Type anim, Color tintTarget, float time)
        {
            var tween = m_targetImage.DOColor(tintTarget, time);
            tween.SetEase(Ease.OutQuad);
            m_animationMap.Add(anim, tween);

            tween.OnComplete(() => m_animationMap.Remove(anim));
            tween.OnKill(() =>
            {
                m_animationMap.Remove(anim);
                m_targetImage.color = tintTarget;
            });
        }

        public void Interrupt(System.Type anim)
        {
            if (m_animationMap.ContainsKey(anim) == false)
                return;

            m_animationMap[anim].Kill();
        }


        // TODO :　This method is temp for testing
        [ContextMenu("Fade in")]
        public void FadeIn()
        {
            var fadeIn = new CharacterFadeIn();
            fadeIn.Play(this);
        }

        [ContextMenu("Fade out")]
        public void FadeOut()
        {
            var fadeOut = new CharacterFadeOut();
            fadeOut.Play(this);
        }

    }

    public class PlayerFlip : IAnimateFunction
    {
        public IAnimateFunction CreateInstance()
        {
            return new PlayerFlip();
        }

        public void Interrupt()
        {
            // do nothing
        }

        public void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;
            var flipTarget = targetTransform.GetComponent<IFlip>();
            flipTarget?.Flip(typeof(IFlip));
        }
    }

    public class CharacterFadeIn : IAnimateFunction
    {

        private IFade m_fadeTarget;
        private ITint m_tintTarget;
        private IPan m_panTarget;

        public IAnimateFunction CreateInstance()
        {
            return new CharacterFadeIn();
        }

        public void Interrupt()
        {
            m_fadeTarget?.Interrupt(typeof(IFade));
            m_tintTarget?.Interrupt(typeof(ITint));
            m_panTarget?.Interrupt(typeof(IPan));
        }

        public void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Tinting
            var tintColor = Color.white;
            m_tintTarget = targetTransform.GetComponent<ITint>();
            m_tintTarget?.Tint(typeof(ITint), tintColor, 0.7f);

            // Paning
            m_panTarget = targetTransform.GetComponent<IPan>();
            m_panTarget.Pan(typeof(IPan), 0, 0.7f);
        }
    }

    public class CharacterFadeOut : IAnimateFunction
    {
        private IFade m_fadeTarget;
        private ITint m_tintTarget;
        private IPan m_panTarget;

        public IAnimateFunction CreateInstance()
        {
            return new CharacterFadeOut();
        }

        public void Interrupt()
        {
            m_fadeTarget?.Interrupt(typeof(IFade));
            m_tintTarget?.Interrupt(typeof(ITint));
            m_panTarget?.Interrupt(typeof(IPan));
        }

        public void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Tinting
            var tintColor = new Color(0.7f, 0.7f, 0.7f);
            m_tintTarget = targetTransform.GetComponent<ITint>();
            m_tintTarget?.Tint(typeof(ITint), tintColor, 0.7f);

            // Paning
            m_panTarget = targetTransform.GetComponent<IPan>();
            m_panTarget.Pan(typeof(IPan), -10f, 0.7f);
        }
    }
}