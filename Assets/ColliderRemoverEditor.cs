#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ColliderRemoverEditor : Editor
{
    [MenuItem("Tools/Remove Colliders From Selection")]
    static void RemoveCollidersFromSelection()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject obj in selectedObjects)
        {
            Collider collider = obj.GetComponent<Collider>();

            if (collider != null)
            {
                DestroyImmediate(collider, true);
                Debug.Log("Collider removed from object: " + obj.name);
            }
            else
            {
                Debug.Log("Selected object " + obj.name + " does not have a collider to remove.");
            }
        }

        Debug.Log("Colliders removed from all selected objects.");
    }
}
#endif