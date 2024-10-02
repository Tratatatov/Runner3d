using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float _time;
    void Awake()
    {
        Destroy(gameObject, _time);
    }

}
