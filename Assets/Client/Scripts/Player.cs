using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    
    public ReactiveProperty<int> CoinsCount { get; private set; } =  new ReactiveProperty<int>();
    private int _lastCoinCollect;

    private void FixedUpdate()
    {
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        _characterController.Move(move * Time.deltaTime * _moveSpeed);

        if (input.x != 0 || input.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(_characterController.velocity);
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
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
