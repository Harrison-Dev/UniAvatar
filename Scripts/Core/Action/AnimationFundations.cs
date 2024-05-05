using UnityEngine;

namespace UniAvatar
{
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
}