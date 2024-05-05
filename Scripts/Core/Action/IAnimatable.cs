using UnityEngine;

namespace UniAvatar
{
    interface IAnimatable { void Interrupt(); }

    interface IFlip : IAnimatable
    {
        void Flip();
    }

    interface IFade : IAnimatable
    {
        void Fade(float alpha, float time);
    }

    interface IPan : IAnimatable
    {
        void Pan(float localValue, float time);
    }

    interface ITint : IAnimatable
    {
        void Tint(Color tintTarget, float time);
    }

    interface IJump : IAnimatable
    {
        void Jump();
    }

    interface ISpriteChange : IAnimatable
    {
        void Change(Sprite sprite);
    }

}