using UnityEngine;

public class AlwaysShowCollider : MonoBehaviour
{
    private SphereCollider _collider;
    private void OnValidate()
    {
        if (_collider != null)
            return;
        _collider = GetComponent<SphereCollider>();
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _collider.radius);
        }
    }


}
