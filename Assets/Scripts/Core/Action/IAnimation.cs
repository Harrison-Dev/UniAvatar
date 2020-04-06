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

    public interface IAnimateFunction
    {
        void Play(AnimationTargetBase target);
        void Interrupt();
        IAnimateFunction CreateInstance();
    }

    // Some animation property in Animate Targets
    // TODO : Manage the interface with Scriptable Objects. (for setting)

    interface IAnimateProp { }

    interface IInterruptable
    {
        void Interrupt(System.Type animType);
    }

    interface IFlip : IAnimateProp
    {
        void Flip(System.Type animType);
    }

    interface IFade : IAnimateProp, IInterruptable
    {
        void Fade(System.Type animType, float alpha, float time);
    }

    interface IPan : IAnimateProp, IInterruptable
    {
        void Pan(System.Type animType, float localValue, float time);
    }

    interface ITint : IAnimateProp, IInterruptable
    {
        void Tint(System.Type animType, Color tintTarget, float time);
    }

}