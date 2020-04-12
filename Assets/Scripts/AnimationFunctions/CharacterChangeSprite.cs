using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar.Example
{
    [CreateAssetMenu(fileName = "CharacterChangeSprite", menuName = "UniAvatar/Animation/CharacterChangeSprite")]
    public class CharacterChangeSprite : AnimationFunctionBase
    {
        public Sprite Sprite;

        public override void Interrupt()
        {

        }

        public override void Play(AnimationTargetBase target)
        {
            var targetTransform = target.transform;

            // Change sprite
            var changeTaarget = targetTransform.GetComponent<ISpriteChange>();
            changeTaarget?.Change(Sprite);
        }
    }
}