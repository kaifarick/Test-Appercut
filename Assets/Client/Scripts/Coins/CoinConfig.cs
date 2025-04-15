using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = nameof(CoinConfig), menuName = "ScriptableObjects/" + nameof(CoinConfig), order = 1)]
public class CoinConfig : ScriptableObject
{
    public CoinsTypeEnum CoinType;
    [FormerlySerializedAs("CoinPrefab")] public ACoinView coinViewPrefab;
    public int CoinRewardCount;
}

public enum CoinsTypeEnum
{
    CopperCoin,
    SilverCoin,
    GoldCoin
}