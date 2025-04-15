using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;using Zenject;

public class CoinsCounterController: IInitializable
{
    public ReactiveProperty<int> CoinsCount { get; } =  new();
    private int _lastCoinCollect;
    
    [Inject] private CoinsConfig _config;
    [Inject] private Player _player;
    
    public void Initialize()
    {
        _player.OnPlayerCollectedAction += CollectCoins;
    }
    
    private void CollectCoins(CoinsTypeEnum coinsType)
    {
        var coinConfig = _config.CoinsConfigs.FirstOrDefault((config => config.CoinType == coinsType));
        if (coinsType == CoinsTypeEnum.GoldCoin)
        {
            CoinsCount.Value += _lastCoinCollect;
        }
        else
        {
            CoinsCount.Value += coinConfig.CoinRewardCount;
            _lastCoinCollect = coinConfig.CoinRewardCount;
        }
    }
}
