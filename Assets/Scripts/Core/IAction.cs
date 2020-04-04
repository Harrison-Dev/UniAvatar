using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public interface IAction
    {
        void Execute(string arg1, string arg2);
    }
}