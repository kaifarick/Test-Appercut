using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinsSO", menuName = "ScriptableObjects/CoinsSO", order = 1)]
public class CoinsSO : ScriptableObject
{
    public List<ACoin> Coins;
}
