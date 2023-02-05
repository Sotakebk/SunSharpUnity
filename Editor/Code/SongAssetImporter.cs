using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace SunSharp.Unity.Editor
{
    [ScriptedImporter(0, "sunvox")]
    public class SongAssetImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var asset = ScriptableObject.CreateInstance<SongAsset>();
            var data = File.ReadAllBytes(ctx.assetPath);
            asset.SetData(data);
            ctx.AddObjectToAsset("SongAsset", asset);
            ctx.SetMainObject(asset);
        }
    }
}
