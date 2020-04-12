using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    [System.Serializable]
    public class AnimationFunctionPair
    {
        public string Key;
        public AnimationFunctionBase AnimationFunction;
    }

    public class AnimationManager : MonoSingleton<AnimationManager>
    {
        public AnimationFunctionPair[] AnimationFunctionSetting;

        private Dictionary<string, AnimationTargetBase> m_animationTargetMap = new Dictionary<string, AnimationTargetBase>();
        private Dictionary<string, AnimationFunctionBase> m_animationFunctionMap = new Dictionary<string, AnimationFunctionBase>();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_animationFunctionMap = AnimationFunctionSetting.ToDictionary(key => key.Key, value => value.AnimationFunction);
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

            var functionInstnace = function.CreateInstance();
            functionInstnace.Play(target);
        }

        public void InterruptAnim(string targetKey, string functionKey)
        {
            var target = m_animationTargetMap[targetKey];
            var function = m_animationFunctionMap[functionKey];

            var functionInstnace = function.CreateInstance();
            functionInstnace.Interrupt();
        }

    }
}