using System;

namespace SunSharp.Unity.Editor
{
    public static class LibraryBorrower
    {
        private static object _lock = new object();

        /// <summary>
        /// Run an action with an uninitialized instance of the SunVox library.
        /// DO NOT RUN ANY LONG-RUNNING ACTIONS OR STORE THE INSTANCE OF THE LIBRARY!
        /// </summary>
        /// <param name="action"></param>
        public static void RunUsingSunVox(Action<ISunVoxLib> action)
        {
            lock (_lock)
            {
                var wrapper = EditorLibrary.WrapperInstance;
                var library = EditorLibrary.Instance;
                if (wrapper.Initialized)
                    library.sv_deinit();

                var proxy = new LibraryProxy(library);
                try
                {
                    action(proxy);
                }
                finally
                {
                    proxy.Destroy();
                    if (wrapper.Initialized)
                        library.sv_deinit();
                }
            }
        }
    }
}
