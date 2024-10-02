using UnityEngine;

public class AlwaysShowAnotherCollider : MonoBehaviour
{
    private Collider _collider;
    private void OnValidate()
    {
        if (_collider != null)
            return;
        _collider = GetComponent<Collider>();
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, _collider.bounds.size);
        }
    }


}
