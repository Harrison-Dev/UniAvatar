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

    interface IAnimateProp { }

    interface IFlip : IAnimateProp
    {
        void Flip();
    }

    interface IFade : IAnimateProp
    {
        void Fade(float alpha, float time);
        void InterruptFade();
    }

    interface IPan : IAnimateProp
    {
        void Pan(float localValue, float time);
        void InterruptPan();
    }

    interface ITint : IAnimateProp
    {
        void Tint(Color tintTarget, float time);
        void InterruptTint();
    }

    interface IJump : IAnimateProp
    {
        void Jump();
        void InterruptJump();
    }

}