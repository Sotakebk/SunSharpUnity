using UnityEditor;
using UnityEngine;

namespace SunSharp.Unity.Editor
{
    [CustomEditor(typeof(SongAsset))]
    [CanEditMultipleObjects]
    public class SongAssetEditor : UnityEditor.Editor
    {
        private SongAsset songAsset;

        private void OnEnable()
        {
            songAsset = (SongAsset)target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Title", songAsset.Title);
            EditorGUILayout.LabelField("Length in lines", songAsset.LengthInLines.ToString());
            EditorGUILayout.LabelField("Length in seconds", songAsset.LengthInSeconds.ToString("F2"));
            EditorGUILayout.LabelField("Pattern count", songAsset.PatternCount.ToString());
            EditorGUILayout.LabelField("Module count", songAsset.ModuleCount.ToString());
            EditorGUILayout.LabelField("This asset is generated from .sunvox files. Please do not modify it directly.");
        }
    }
}
