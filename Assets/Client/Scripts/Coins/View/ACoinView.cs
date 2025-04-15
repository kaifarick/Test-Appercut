using System;
using UnityEngine;

public abstract class ACoinView : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    public abstract CoinsTypeEnum CoinsType { get; }
    protected Vector3 _defaultScale { get; set; }

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public virtual void Spawn()
    {
        gameObject.SetActive(true);
        _boxCollider.enabled = true;
    }
    
    public virtual void Collected()
    {
        _boxCollider.enabled = false;
    }

    protected virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}
