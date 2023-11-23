using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text _counter;

    [Inject] private Player _player;

    private void Start()
    {
        _player.CoinsCount.SubscribeToText(_counter);
    }
}
