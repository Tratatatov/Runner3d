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
                // ���� ������ ��������� Hidden/InternalErrorShader, �������� ��� �� Mobile/Diffuse
                material.shader = Shader.Find("Mobile/Diffuse");
                Debug.Log("������ ��������� " + material.name + " ��� Hidden/InternalErrorShader. ������� �� Mobile/Diffuse.");
            }
        }
    }
}
#endif