using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CoinsCounterView : MonoBehaviour  
{
    [SerializeField] private Text _counter;

    [Inject] private CoinsCounterController _coinsCounterController;

    public void Start()
    {
        _coinsCounterController.CoinsCount.SubscribeToText(_counter);
    }
}
