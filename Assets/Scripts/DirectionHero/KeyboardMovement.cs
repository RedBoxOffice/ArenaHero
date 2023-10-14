using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speedHero = 10f;

    private float _directionX;
    private float _directionZ;
    private float _defaultSpeedHero;
    private float _increasedSpeed = 2;
    private Vector3 _move;

    private void Start()
    {
        _defaultSpeedHero = _speedHero;
    }

    private void Update()
    {
        MoveHero();
    }

    private void MoveHero()
    {
        _directionX = Input.GetAxis("Horizontal");
        _directionZ = Input.GetAxis("Vertical");
        _move = transform.right * _directionX + transform.forward * _directionZ;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _speedHero = _defaultSpeedHero * _increasedSpeed;
        }
        else
        {
            _speedHero = _defaultSpeedHero;
        }

        _characterController.Move(_move * _speedHero * Time.deltaTime);
    }
}
