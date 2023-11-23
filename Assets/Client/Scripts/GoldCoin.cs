using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoldCoin : ACoin
{
    public override void Spawn()
    {
        base.Spawn();

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOScale(new Vector3(START_SCALE, START_SCALE, START_SCALE), 0.5f)
            .SetEase(Ease.OutBack));
    }

    public override void Collected()
    {
        base.Collected();
        base.Disable();
    }
}
