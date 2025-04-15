using DG.Tweening;
using UnityEngine;
using Zenject;

public class CopperCoinView : ACoinView
{
    [SerializeField] private AudioSource _audioSource;
    public override CoinsTypeEnum CoinsType => CoinsTypeEnum.CopperCoin;
    

    public override void Collected()
    {
        base.Collected();
        _audioSource.Play();
        
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(_audioSource.clip.length).AppendCallback(base.Disable);
        
    }
}
