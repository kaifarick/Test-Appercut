

using DG.Tweening;
using UnityEngine;

public class SilverCoinView : ACoinView
{
    
    public override CoinsTypeEnum CoinsType => CoinsTypeEnum.SilverCoin;

    public override void Collected()
    {
        base.Collected();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0,0.5f)).AppendCallback(base.Disable);
        
    }
}
