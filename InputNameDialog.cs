using UnityEditor;
using UnityEngine;

namespace net.narazaka.unity.material_variant_creator
{
    public class InputNameDialog : EditorWindow
    {
        public string suffix = " Variant";

        void OnGUI()
        {
            suffix = EditorGUILayout.TextField("Suffix", suffix);

            if (GUILayout.Button("Create"))
            {
                MaterialVariantCreator.CreateMaterialVariants(suffix);
                Close();
            }
        }
    }
}
