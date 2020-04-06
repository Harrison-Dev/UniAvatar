using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar.Example
{
    [CreateAssetMenu(fileName = "CharacterFadeIn", menuName = "UniAvatar/Animation/CharacterFadeIn")]
    public class CharacterFadeIn : AnimationFunctionBase
    {
        public float FadingTime = 0.7f;

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
            var tintColor = Color.white;
            m_tintTarget = targetTransform.GetComponent<ITint>();
            m_tintTarget?.Tint(typeof(ITint), tintColor, FadingTime);

            // Paning
            m_panTarget = targetTransform.GetComponent<IPan>();
            m_panTarget.Pan(typeof(IPan), 0, FadingTime);
        }
    }
}