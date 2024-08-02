using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace net.narazaka.unity.material_variant_creator
{
    public class MaterialVariantCreator
    {
        [MenuItem("Assets/Create/Material Variants", false, 302)]
        static void CreateMaterialVariants()
        {
            foreach (Object obj in Selection.objects)
            {
                if (obj is Material)
                {
                    CreateMaterialVariant(obj as Material);
                }
            }
        }

        static void CreateMaterialVariant(Material material)
        {
            var path = AssetDatabase.GetAssetPath(material);
            var directory = Path.GetDirectoryName(path);
            var name = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var variantPath = Path.Combine(directory, name + " Variant" + extension);

            var variant = new Material(material);
            variant.parent = material;
            AssetDatabase.CreateAsset(variant, variantPath);
        }
    }
}
