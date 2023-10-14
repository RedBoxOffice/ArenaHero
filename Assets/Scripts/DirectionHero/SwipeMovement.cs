using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float _speedHero = 10f;
    [SerializeField] private float _distanceMove;
    [SerializeField] private Hero _hero;
    private Vector3 _direction;        

    private void Update()
    {
        MoveHero();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {       
        SwipeDetected(eventData.delta.x, eventData.delta.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SwipeDeactivated(eventData.delta.x, eventData.delta.y);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    private void SwipeDeactivated(float deltaX, float deltaY)
    {
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                _direction = new Vector3(0, 0, 0);
            }
            else
            {
                _direction = new Vector3(0, 0, 0);
            }

        }
        else
        {
            if (deltaY > 0)
            {
                _direction = new Vector3(0, 0, 0);
            }
            else
            {
                _direction = new Vector3(0, 0, 0);
            }
        }
    }

    private void SwipeDetected(float deltaX, float deltaY)
    {
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                _direction = new Vector3(0, 0, 1);
            }
            else
            {
                _direction = new Vector3(0, 0, -1);
            }
            
        }
        else
        {
            if (deltaY > 0)
            {
                _direction = new Vector3(-1, 0, 0);
            }
            else
            {
                _direction = new Vector3(1, 0, 0);
            }           
        }
    } 
    
    private void MoveHero()
    {
        _hero.transform.position = _hero.transform.position + _direction * _speedHero * Time.deltaTime;
    }    
}
