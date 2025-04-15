using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private CoinViewSpawner _coinViewSpawner;
    [SerializeField] private CoinsViewPool _coinsViewPool;
    [SerializeField] private CoinsConfig _coinsConfig;
    public override void InstallBindings()
    {
        Container.Bind<CoinsConfig>().FromScriptableObject(_coinsConfig).AsSingle();
        
        Container.BindInterfacesAndSelfTo<CoinsViewPool>().FromInstance(_coinsViewPool).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CoinViewSpawner>().FromInstance(_coinViewSpawner).AsSingle().NonLazy();
        
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        
        Container.BindInterfacesAndSelfTo<CoinsCounterController>().AsSingle().NonLazy();
    }
}