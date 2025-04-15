using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CoinViewSpawner : MonoBehaviour, IInitializable   
{
    [SerializeField] private Collider _spawnPlace;
    
    [Inject] private CoinsConfig _coinsConfig;
    [Inject] private CoinsViewPool _coinsViewPool;
    
    
    public void Initialize()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            var selectCoin = _coinsConfig.CoinsConfigs[Random.Range(0, 3)];

            var randomXPos = Random.Range(_spawnPlace.bounds.min.x, _spawnPlace.bounds.max.x);
            var randomZPos = Random.Range(_spawnPlace.bounds.min.z, _spawnPlace.bounds.max.z);
            var selectPosition = new Vector3(randomXPos, _spawnPlace.bounds.max.y + 1.5f, randomZPos);

            var coin = _coinsViewPool.Spawn(selectCoin.CoinType, selectPosition, Quaternion.Euler(90,0,0));
            coin.Spawn();
            
            Debug.Log($"Coin spawn {selectCoin.CoinType}");
        }
    }
}
