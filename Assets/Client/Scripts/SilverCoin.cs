

using DG.Tweening;
using UnityEngine;

public class SilverCoin : ACoin
{
    public override void Spawn()
    {
        base.Spawn();
        transform.localScale = new Vector3(START_SCALE, START_SCALE, START_SCALE);
    }

    public override void Collected()
    {
        base.Collected();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0,0.5f)).AppendCallback(base.Disable);
        
    }
}
