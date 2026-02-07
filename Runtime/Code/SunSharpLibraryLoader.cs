using System;
using SunSharp.Native;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace SunSharp.Unity
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public static class SunSharpLibraryLoader
    {
        private static SunVoxLibCWithTrackedState _instance;

        public static ISunVoxLibC Instance => _instance;

        static bool IsInitialized => _instance.IsInitialized;

        static SunSharpLibraryLoader()
        {
            _instance = new SunVoxLibCWithTrackedState();
#if UNITY_EDITOR
            AssemblyReloadEvents.beforeAssemblyReload += AssemblyReloadEvents_OnBeforeAssemblyReload;
            EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
#endif
        }

#if UNITY_EDITOR

        private static void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingEditMode
                || obj == PlayModeStateChange.EnteredEditMode)
            {
                MaybeDeinitialize();
            }
        }

        private static void AssemblyReloadEvents_OnBeforeAssemblyReload()
        {
            MaybeDeinitialize();
        }

        private static void MaybeDeinitialize()
        {
            try
            {
                _instance.MaybeDeinitialize();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                Debug.LogError("Failed to deinitialize SunSharp library before assembly reload. This may cause issues such as memory leaks or crashes. Please report this issue to the developers.");
            }
        }

#endif
    }
}
