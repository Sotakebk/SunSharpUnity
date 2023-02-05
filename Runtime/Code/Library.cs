using UnityEditor;

#if UNITY_EDITOR

using UnityEngine;

#endif

namespace SunSharp.Unity
{
    [InitializeOnLoad]
    public static class Library
    {
        private static LibraryProxy _proxy;
        private static LibraryInstance _instance;
        public static ISunVoxLib Instance => _proxy;

        public static bool Initialized => _instance.Initialized;

        static Library()
        {
            _instance = new LibraryInstance();
            _proxy = new LibraryProxy(_instance);
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
                TryUnloadLibrary();
        }

        private static void AssemblyReloadEvents_OnBeforeAssemblyReload()
        {
            TryUnloadLibrary();
        }

        private static void TryUnloadLibrary()
        {
            _instance.RunInLock(() =>
            {
                if (_instance.Initialized)
                    (_instance as ISunVoxLib).sv_deinit();
            });
            Debug.Log($"TryUnloadLibrary ran!");
        }

#endif
    }
}
