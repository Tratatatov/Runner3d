using System.Collections.Generic;
using UnityEngine;

public class BonusesPool : MonoBehaviour
{
    private List<Bonus> _pool = new List<Bonus>();
    private void Awake()
    {
        _pool.AddRange(GetComponentsInChildren<Bonus>());
    }
    private void OnEnable()
    {
        foreach (var bonus in _pool)
            bonus.gameObject.SetActive(true);
    }
}
