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
            m_fadeTarget?.Interrupt();
            m_tintTarget?.Interrupt();
            m_panTarget?.Interrupt();
        }

        public override void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Tinting
            var tintColor = Color.white;
            m_tintTarget = targetTransform.GetComponent<ITint>();
            m_tintTarget?.Tint(tintColor, FadingTime);

            // Paning
            m_panTarget = targetTransform.GetComponent<IPan>();
            m_panTarget.Pan(0, FadingTime);
        }
    }
}