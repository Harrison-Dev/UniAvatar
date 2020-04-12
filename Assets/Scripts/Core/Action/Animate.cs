using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class Animate : IAction
    {
        public void Execute(string target, string function, string arg3, string arg4)
        {
            AnimationManager.Instance.PlayAnim(target, function);
        }
    }
}