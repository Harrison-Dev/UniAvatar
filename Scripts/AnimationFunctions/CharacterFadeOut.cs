using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar.Example
{
    [CreateAssetMenu(fileName = "CharacterFadeOut", menuName = "UniAvatar/Animation/CharacterFadeOut")]
    public class CharacterFadeOut : AnimationFunctionBase
    {
        public float FadingTime = 0.7f;
        public float FadeoutOffsetY = -10f;
        public Color TintColor = new Color(0.7f, 0.7f, 0.7f);

        private IFade m_fadeTarget;
        private ITint m_tintTarget;
        private IPan m_panTarget;

        public override void Interrupt()
        {
            m_fadeTarget?.InterruptFade();
            m_tintTarget?.InterruptTint();
            m_panTarget?.InterruptPan();
        }

        public override void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Tinting
            var tintColor = TintColor;
            m_tintTarget = targetTransform.GetComponent<ITint>();
            m_tintTarget?.Tint(tintColor, FadingTime);

            // Paning
            m_panTarget = targetTransform.GetComponent<IPan>();
            m_panTarget.Pan(FadeoutOffsetY, FadingTime);
        }
    }
}