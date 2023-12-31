using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{   
    [SerializeField] private float _speedHero = 10f;
    [SerializeField] private float _distanceMove = 5f;

    private Vector3 _direction;
    private bool _isUseKeyboard = false;

    private void Update()
    {
        ChooseDirection();

        if (_isUseKeyboard == true)
        {
            MoveHero();
        }
    }  

    private void ChooseDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = transform.position + Vector3.left * _distanceMove;
            _isUseKeyboard = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = transform.position + Vector3.right * _distanceMove;
            _isUseKeyboard = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = transform.position + Vector3.back * _distanceMove;
            _isUseKeyboard = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = transform.position + Vector3.forward * _distanceMove;
            _isUseKeyboard = true;
        }       
    }

    private void MoveHero()
    {
        transform.position = Vector3.MoveTowards(transform.position, _direction, _speedHero * Time.deltaTime);

        if (transform.position == _direction)
        {
            _isUseKeyboard = false;
        }
    }
}
