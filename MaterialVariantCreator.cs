using System.IO;
using UnityEngine;
using UnityEditor;

namespace net.narazaka.unity.material_variant_creator
{
    public class MaterialVariantCreator
    {
        [MenuItem("Assets/Create/Material Variants", false, 302)]
        static void CreateMaterialVariants()
        {
            CreateMaterialVariants(" Variant");
        }

        [MenuItem("Assets/Create/Material Variants (with custom suffix)", false, 302)]
        static void CreateMaterialVariantsWithCustomName()
        {
            var window = EditorWindow.GetWindowWithRect<InputNameDialog>(new Rect(0, 0, 320, 60));
            window.Show();
        }

        internal static void CreateMaterialVariants(string suffix)
        {
            foreach (Object obj in Selection.objects)
            {
                if (obj is Material)
                {
                    CreateMaterialVariant(obj as Material, suffix);
                }
            }
        }

        static void CreateMaterialVariant(Material material, string suffix)
        {
            var path = AssetDatabase.GetAssetPath(material);
            var directory = Path.GetDirectoryName(path);
            var name = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var variantPath = Path.Combine(directory, name + suffix + extension);

            var variant = new Material(material);
            variant.parent = material;
            AssetDatabase.CreateAsset(variant, variantPath);
        }
    }
}
