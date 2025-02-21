using System.Collections.Generic;
using MornGlobal;
using UnityEngine;

namespace MornEnum
{
    public abstract class MornEnumGlobalBase<T> : MornGlobalBase<T> where T : MornEnumGlobalBase<T>
    {
        [SerializeField] private List<string> _flags = new();
        public List<string> Flags => _flags;
    }
}