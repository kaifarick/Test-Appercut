using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ACoin : MonoBehaviour
{
    public CoinsTypeEnum CoinsType => coinsTypeEnum;
    public int Cost => _cost;

    [SerializeField] private int _cost;
    [FormerlySerializedAs("_coinsType")] [SerializeField] private CoinsTypeEnum coinsTypeEnum;
    [SerializeField] private BoxCollider _boxCollider;

    protected const int START_SCALE = 10;
    public virtual void Spawn()
    {
        gameObject.SetActive(true);
        _boxCollider.enabled = true;
    }
    
    public virtual void Collected()
    {
        _boxCollider.enabled = false;
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
    
    public enum CoinsTypeEnum
    {
        CopperCoin,
        SilverCoin,
        GoldCoin
    }
}
