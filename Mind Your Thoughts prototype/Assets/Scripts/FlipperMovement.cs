using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
/// 
/// This script will be used to do the movement of the flippers so it can be used to fling thoughts correctly
/// 
public class FlipperMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _FlipperSpeed;
    [SerializeField] private float _FlipperAmount;

    [SerializeField] private PlayerInput _InputActions;

    void Awake()
    {
        _InputActions = new PlayerInput();

    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("W"))
        {
            _FlipperAmount += _FlipperSpeed * Time.deltaTime; 
        _transform.localRotation = Quaternion.Euler(0, 0, _FlipperAmount);
        }
        // Rotates the flippers
       
    }
}
