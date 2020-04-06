using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar.Example
{
     [CreateAssetMenu(fileName = "CharacterFlip", menuName = "UniAvatar/Animation/CharacterFlip")]
    public class CharacterFlip : AnimationFunctionBase
    {
        public override void Interrupt()
        {
            // do nothing
        }

        public override void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;
            var flipTarget = targetTransform.GetComponent<IFlip>();
            flipTarget?.Flip(typeof(IFlip));
        }
    }
}