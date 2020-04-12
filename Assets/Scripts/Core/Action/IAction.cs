using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public interface IAction
    {
        void Execute(string arg1, string arg2, string arg3, string arg4, string arg5);
    }
}