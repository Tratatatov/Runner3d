#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class GPUInstancingActivator : MonoBehaviour
{
    [MenuItem("Tools/Activate GPU Instancing for Materials")]
    static void ActivateGPUInstancing()
    {
        string[] allMaterialGUIDs = AssetDatabase.FindAssets("t:Material");
        foreach (string materialGUID in allMaterialGUIDs)
        {
            string materialPath = AssetDatabase.GUIDToAssetPath(materialGUID);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

            if (material != null && !material.enableInstancing)
            {
                material.enableInstancing = true;
                Debug.Log("GPU Instancing activated for material: " + material.name);
            }
        }

        Debug.Log("GPU Instancing activation complete for all materials.");
    }
}
#endif