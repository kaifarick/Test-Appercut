using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CopperCoin : ACoin
{
    [SerializeField] private AudioSource _audioSource;
    public override void Collected()
    {
        base.Collected();
        _audioSource.Play();
        
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(_audioSource.clip.length).AppendCallback(base.Disable);
        
    }
}
