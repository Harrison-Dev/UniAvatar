using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{

    public enum AnimateType
    {
        Character,
    }

    public abstract class AnimationTargetBase : MonoBehaviour
    {

    }

    public abstract class AnimationFunctionBase : ScriptableObject
    {
        public AnimationFunctionBase CreateInstance()
        {
            return Instantiate(this);
        }
        
        public abstract void Interrupt();
        public abstract void Play(AnimationTargetBase target);
    }

    // Some animation property in Animate Targets

    interface IAnimBase { void Interrupt(); }

    interface IFlip : IAnimBase
    {
        void Flip();
    }

    interface IFade : IAnimBase
    {
        void Fade(float alpha, float time);
    }

    interface IPan : IAnimBase
    {
        void Pan(float localValue, float time);
    }

    interface ITint : IAnimBase
    {
        void Tint(Color tintTarget, float time);
    }

    interface IJump : IAnimBase
    {
        void Jump();
    }

    interface ISpriteChange : IAnimBase
    {
        void Change(Sprite sprite);
    }

}