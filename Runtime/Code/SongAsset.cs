using System;
using UnityEngine;

namespace SunSharp.Unity
{
    public class SongAsset : ScriptableObject
    {
        [SerializeField] private bool _constructed;
        [HideInInspector][SerializeField] private byte[] _data;

        public byte[] Data => _data;

        public void SetData(byte[] data)
        {
            if (_constructed)
                throw new InvalidOperationException();

            _constructed = true;
            _data = data;
        }
    }
}
