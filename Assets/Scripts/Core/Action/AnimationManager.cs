using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class AnimationManager : MonoSingleton<AnimationManager>
    {
        private Dictionary<string, AnimationTargetBase> m_animationTargetMap = new Dictionary<string, AnimationTargetBase>();
        private Dictionary<string, IAnimateFunction> m_animationFunctionMap = new Dictionary<string, IAnimateFunction>();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_animationFunctionMap.Add("CharacterFadeIn", new CharacterFadeIn());
            m_animationFunctionMap.Add("CharacterFadeOut", new CharacterFadeOut());
        }

        public void Register(string key, AnimationTargetBase animatedTarget)
        {
            m_animationTargetMap.Add(key, animatedTarget);
        }

        // TODO : interrput

        public void PlayAnim(string targetKey, string functionKey)
        {
            var target = m_animationTargetMap[targetKey];
            var function = m_animationFunctionMap[functionKey];

            var functionInstance = function.CreateInstance();

            functionInstance.Play(target);
        }

    }
}