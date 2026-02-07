using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace SunSharp.Unity.Editor
{
    [ScriptedImporter(1, "sunvox")]
    public class SongAssetImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var asset = ScriptableObject.CreateInstance<SongAsset>();
            var data = File.ReadAllBytes(ctx.assetPath);
            var lengthInLines = 0;
            var lengthInSeconds = 0.0;
            var patternCount = 0;
            var moduleCount = 0;
            var title = string.Empty;
            SunSharpEditorLibraryBorrower.RunUsingSunVox(lib =>
            {
                using var sunVox = SunVox.WithUserManagedAudio(lib, 48000, OutputType.Int16);
                var slot = sunVox.Slots[0];
                slot.Open();
                slot.Load(data);
                title = slot.GetSongName();
                var patterns = slot.Timeline as IEnumerable<PatternHandle>;
                var min = patterns.Min(p => p.GetPosition().x);
                var max = patterns.Max(p => p.GetPosition().x + p.GetLength());
                if (min != max)
                {
                    var timeMap = slot.GetTimeMapFrames(min, max);
                    var last = timeMap.Last();
                    lengthInSeconds = last / (double)sunVox.SampleRate;
                    lengthInLines = max - min;
                }
                patternCount = patterns.Count();
                moduleCount = (slot.Synthesizer as IEnumerable<SynthModuleHandle>).Count();
                slot.Close();
            });

            asset.SetData(data, title, lengthInLines, lengthInSeconds, patternCount, moduleCount);
            
            var icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.sotakebk.sunsharp.unity/Editor/Icons/songasset_icon.png");
            if (icon != null)
            {
                EditorGUIUtility.SetIconForObject(asset, icon);
            }
            
            ctx.AddObjectToAsset("SongAsset", asset);
            ctx.SetMainObject(asset);
        }
    }
}
