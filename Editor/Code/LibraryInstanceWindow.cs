using SunSharp.ThinWrapper;
using UnityEditor;
using UnityEngine;

namespace SunSharp.Unity.Editor
{
    public class LibraryInstanceWindow : EditorWindow
    {
        private const string _windowName = "SunVox management";

        [MenuItem("Window/SunSharp/Instance Management")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(LibraryInstanceWindow));
        }

        private void OnGUI()
        {
            name = _windowName;
            if (GUILayout.Button("Reload window"))
            {
                Repaint();
            }
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label($"Engine SunVox instance state: {(EditorLibrary.WrapperInstance.Initialized ? "Initialized" : "Not initialized")}");
            }

            if (GUILayout.Button("Dry run"))
            {
                LibraryBorrower.RunUsingSunVox(sv => { });
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label($"Runtime SunVox instance state: {(Library.Initialized ? "Initialized" : "Not initialized")}");
                if (GUILayout.Button("Initialize"))
                {
                    Library.Instance.Init(-1);
                }
                if (GUILayout.Button("Deinitialize"))
                {
                    Library.Instance.Deinit();
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}
