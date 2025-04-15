using DG.Tweening;
using UnityEngine;

public class GoldCoinView : ACoinView
{
    public override CoinsTypeEnum CoinsType => CoinsTypeEnum.GoldCoin;
    
    public override void Spawn()
    {
        base.Spawn();

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOScale(_defaultScale, 0.5f).SetEase(Ease.OutBack)).AppendCallback((() =>
        {
            
        }));
    }

    public override void Collected()
    {
        base.Collected();
        base.Disable();
    }
}
