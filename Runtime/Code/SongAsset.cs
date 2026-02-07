using System;
using UnityEngine;

namespace SunSharp.Unity
{
    public class SongAsset : ScriptableObject
    {
        [SerializeField] private bool _constructed;
        [HideInInspector][SerializeField] private byte[] _data;
        [HideInInspector][SerializeField] private string _title;
        [HideInInspector][SerializeField] private int _lengthInLines;
        [HideInInspector][SerializeField] private double _lengthInSeconds;
        [HideInInspector][SerializeField] private int _patternCount;
        [HideInInspector][SerializeField] private int _moduleCount;

        public byte[] Data => _data.Clone() as byte[];
        public string Title => _title;
        public int LengthInLines => _lengthInLines;
        public double LengthInSeconds => _lengthInSeconds;
        public int PatternCount => _patternCount;
        public int ModuleCount => _moduleCount;

        public void SetData(byte[] data, string title, int lengthInLines, double lengthInSeconds, int patternCount, int moduleCount)
        {
            if (_constructed)
            {
                throw new InvalidOperationException();
            }

            _constructed = true;
            _data = data;
            _title = title;
            _lengthInLines = lengthInLines;
            _lengthInSeconds = (int)lengthInSeconds;
            _patternCount = patternCount;
            _moduleCount = moduleCount;
        }
    }
}
