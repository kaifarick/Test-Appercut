using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinsSO _coinsSo;
    [SerializeField] private Collider _spawnPlace;

    private List<ACoin> _spawnedCoins = new List<ACoin>();
    

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            var selectCoin = _coinsSo.Coins[Random.Range(0, 3)];
           // selectCoin = _coinsSo.Coins[1];//remove

            var randomXPos = Random.Range(_spawnPlace.bounds.min.x, _spawnPlace.bounds.max.x);
            var randomZPos = Random.Range(_spawnPlace.bounds.min.z, _spawnPlace.bounds.max.z);
            var selectPosition = new Vector3(randomXPos, _spawnPlace.bounds.max.y + 1.5f, randomZPos);

            if (_spawnedCoins.Where((coin => coin.CoinsType == selectCoin.CoinsType))
                .Any(coin => !coin.isActiveAndEnabled))
            {
                var coin = _spawnedCoins.Where((coin => coin.CoinsType == selectCoin.CoinsType))
                    .First((aCoin => !aCoin.isActiveAndEnabled));
                
                coin.transform.position = selectPosition;
                coin.Spawn();
            }

            else
            {
                var instCoin = Instantiate(selectCoin, selectPosition, selectCoin.transform.rotation,_spawnPlace.transform);
                instCoin.Spawn();
                _spawnedCoins.Add(instCoin);
            }
            Debug.Log($"Coin spawn {selectCoin.CoinsType}");
            
        }
    }
}
