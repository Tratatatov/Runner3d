using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class ShaderChecker : MonoBehaviour
{
    private void Start()
    {
        string[] allMaterialGUIDs = AssetDatabase.FindAssets("t:Material");

        foreach (string materialGUID in allMaterialGUIDs)
        {
            string materialPath = AssetDatabase.GUIDToAssetPath(materialGUID);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

            if (material.shader != null && material.shader.name == "Hidden/InternalErrorShader")
            {
                // Если шейдер материала Hidden/InternalErrorShader, заменяем его на Mobile/Diffuse
                material.shader = Shader.Find("Mobile/Diffuse");
                Debug.Log("Шейдер материала " + material.name + " был Hidden/InternalErrorShader. Заменен на Mobile/Diffuse.");
            }
        }
    }
}
#endif