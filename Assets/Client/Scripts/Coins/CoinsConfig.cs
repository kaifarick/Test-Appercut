using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CoinsConfig), menuName = "ScriptableObjects/" + nameof(CoinsConfig), order = 1)]
public class CoinsConfig : ScriptableObject
{
    public List<CoinConfig> CoinsConfigs;
}
