using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar.Example
{
    [CreateAssetMenu(fileName = "CharacterJump", menuName = "UniAvatar/Animation/CharacterJump")]
    public class CharacterJump : AnimationFunctionBase
    {
        private IJump m_jumpTarget;

        public override void Interrupt()
        {
            m_jumpTarget?.InterruptJump();
        }

        public override void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Jumping
            m_jumpTarget = targetTransform.GetComponent<IJump>();
            m_jumpTarget.Jump();
        }
    }
}