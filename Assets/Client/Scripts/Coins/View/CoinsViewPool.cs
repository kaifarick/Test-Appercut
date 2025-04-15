using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CoinsViewPool : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private Transform _coinContainer;
    
    private Dictionary<CoinsTypeEnum, Queue<ACoinView>> _inactivePools = new();
    private Dictionary<CoinsTypeEnum, ACoinView> _prefabs = new();
    private const int InitialPoolSize = 10;
    
    [Inject] private DiContainer _diContainer;
    [Inject] private CoinsConfig _config;

    public void Initialize()
    {
        _inactivePools = new Dictionary<CoinsTypeEnum, Queue<ACoinView>>();
        _prefabs = new Dictionary<CoinsTypeEnum, ACoinView>();
        
         foreach (CoinsTypeEnum element in Enum.GetValues(typeof(CoinsTypeEnum)))
         {
             
             ACoinView prefab = _config.CoinsConfigs.FirstOrDefault((config => config.CoinType == element)).coinViewPrefab;

            _prefabs[element] = prefab;
            Queue<ACoinView> queue = new Queue<ACoinView>();
            _inactivePools[element] = queue;
            
            for (int i = 0; i < InitialPoolSize; i++)
            {
                ACoinView instance = _diContainer.InstantiatePrefabForComponent<ACoinView>(prefab, _poolContainer);
                instance.gameObject.SetActive(false);
                queue.Enqueue(instance);
            }
        }
    }

    public ACoinView Spawn(CoinsTypeEnum element, Vector3 position, Quaternion rotation)
    {
        if (!_prefabs.ContainsKey(element))
        {
            Debug.LogError($"No prefab for element {element}");
            return null;
        }

        Queue<ACoinView> queue = _inactivePools[element];
        ACoinView coinView;

        if (queue.Count > 0)
        {
            coinView = queue.Dequeue();
        }
        else
        {
            coinView = _diContainer.InstantiatePrefabForComponent<ACoinView>(_prefabs[element], _coinContainer);
        }

        coinView.transform.SetParent(_coinContainer);
        coinView.transform.position = position;
        coinView.transform.rotation = rotation;
        coinView.gameObject.SetActive(true);
        return coinView;
    }

    public void Despawn(ACoinView coinView)
    {
        CoinsTypeEnum element = coinView.CoinsType;
        if (!_inactivePools.ContainsKey(element))
        {
            Destroy(coinView.gameObject);
            return;
        }

        coinView.gameObject.SetActive(false);
        coinView.transform.SetParent(_poolContainer);
        _inactivePools[element].Enqueue(coinView);
    }

    public void Dispose()
    {
        foreach (var queue in _inactivePools.Values)
        {
            while (queue.Count > 0)
            {
                ACoinView blockView = queue.Dequeue();
                if (blockView != null)
                {
                    Destroy(blockView.gameObject);
                }
            }
        }
        _inactivePools.Clear();
        _prefabs.Clear();
    }
}