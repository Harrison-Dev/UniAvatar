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
        public string Key;

        protected virtual void Awake()
        {
            Register();
        }

        protected void Register()
        {
            AnimationManager.Instance.Register(Key, this);
        }
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
        void Flip(System.Type animType);
    }

    interface IFade : IAnimateProp
    {
        void Fade(System.Type animType, float alpha, float time);
        void InterruptFade();
    }

    interface IPan : IAnimateProp
    {
        void Pan(System.Type animType, float localValue, float time);
        void InterruptPan();
    }

    interface ITint : IAnimateProp
    {
        void Tint(System.Type animType, Color tintTarget, float time);
        void InterruptTint();
    }

}