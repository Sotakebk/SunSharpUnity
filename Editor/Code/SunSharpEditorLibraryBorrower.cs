using System;
using SunSharp.Native;

namespace SunSharp.Unity.Editor
{
    public static class SunSharpEditorLibraryBorrower
    {
        private static object _lock = new();

        /// <summary>
        /// Run an action with an uninitialized instance of the SunVox library.
        /// DO NOT RUN ANY LONG-RUNNING ACTIONS OR STORE THE INSTANCE OF THE LIBRARY!
        /// </summary>
        /// <param name="action"></param>
        public static void RunUsingSunVox(Action<ISunVoxLibC> action)
        {
            lock (_lock)
            {
                var lib = new SunVoxLibCForEditorWithTrackedState();
                var proxy = new LibraryProxy(lib);

                try
                {
                    action(proxy);
                }
                finally
                {
                    proxy.Destroy();
                    lib.MaybeDeinitialize();
                }
            }
        }
    }
}
