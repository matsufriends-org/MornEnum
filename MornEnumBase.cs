using System;
using UnityEngine;

namespace MornEnum
{
    public abstract class MornEnumBase
    {
        [SerializeField] private string _key;
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        public int Index
        {
            get => Array.IndexOf(Values, _key);
            set => _key = Values[value];
        }
        protected abstract string[] Values { get; }
    }
}