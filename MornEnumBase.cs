using System;
using UnityEngine;

namespace MornEnum
{
    [Serializable]
    public abstract class MornEnumBase<T> where T : MornEnumGlobalBase<T>
    {
        [SerializeField] private string _key;
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        public int Index => Global.Flags.IndexOf(_key);
        protected abstract T Global { get; }
    }
}