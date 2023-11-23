using System;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private float _moveSpeed;
    
    public ReactiveProperty<int> CoinsCount { get; private set; } =  new ReactiveProperty<int>();
    private int _lastCoinCollect;

    private void FixedUpdate()
    {
        _characterController.Move( new Vector3(_fixedJoystick.Horizontal * _moveSpeed,
            _characterController.velocity.y, +_fixedJoystick.Vertical * _moveSpeed));

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_characterController.velocity);
        }
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (hit.gameObject.TryGetComponent<ACoin>(out ACoin coin))
        {
            coin.Collected();
            
            if (coin.CoinsType == ACoin.CoinsTypeEnum.GoldCoin)
            {
                CoinsCount.Value += _lastCoinCollect;
            }
            else
            {
                CoinsCount.Value += coin.Cost;
                _lastCoinCollect = coin.Cost;
            }
        }
    }
}
