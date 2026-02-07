# SunSharp Unity

This is a Unity package for using the SunVox library in Unity projects. It contains the [SunSharp](https://github.com/Sotakebk/SunSharp) C# wrapper for the SunVox library, as well as the native libraries for Windows, Linux, and macOS.

Target SunVox version: 2.1.4

SunVox is licensed under the MIT license, and so is this package. See the [LICENSE](LICENSE.md) file for more details.

SunVox requires attribution, so please consult the library's license for more details on how to properly attribute it in your project.

## How to install

* Open the Package Manager in Unity (`Window -> Package Management -> Package Manager`).
* Press the big '+' button in the top-left corner, then click on 'Add package from git URL'.
* Fill out the field with this repository's URL: `https://github.com/Sotakebk/SunSharpUnity.git`
* The package should now be available to use.

## How to use

Here's a quick sample of how to use the package:

```csharp
using SunSharp.Unity;
using SunSharpUnity_VRDemo.ScopeView;
using UnityEngine;

namespace SunSharpUnity_VRDemo
{
    public class SongManager : MonoBehaviour
    {
        [SerializeField] private SongAsset song;

        public SunVox SunVoxInstance { get; private set; }

        private void Awake()
        {
            SunVoxInstance = SunVox.WithOwnAudioStream(SunSharpLibraryLoader.Instance);
        }

        private void Start()
        {
            var sv = SunVoxInstance;
            var slot = sv.Slots[0];

            slot.Open();
            slot.Load(song.Data);
            slot.StartPlaybackFromBeginning();
            slot.Synthesizer.TryGetModule(0, out var module);
            OutputScopeView._module = module;
        }

        private void OnDestroy()
        {
            SunVoxInstance.Dispose();
        }
    }
}
```

There is an additional project (old, development hell) in the SunSharpUnity VR Demo repository [available here](https://github.com/Sotakebk/SunSharpUnity_VRDemo) that contains some example code for using the package in a Unity project.

For more detailed usage instructions, please refer to the [SunSharp documentation](https://github.com/Sotakebk/SunSharp).

## Known Issues

For some reason after initializing the SunVox instance, the editor's camera controls (AWSD movement) stop working. This only happens in the editor, and not in builds.

If you need support, feel free to open an issue in the repository or contact me directly.
