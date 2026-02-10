using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
/// 
/// This script will be used to do the movement of the flippers so it can be used to fling thoughts correctly
/// 
public class FlipperMovement : MonoBehaviour
{
    //Initialising variables
    [SerializeField] private Transform _transform;

    [SerializeField] private float _FlipperSpeed;
    [SerializeField] private float _FlipperAmount;
    [SerializeField] private float _FlipAngleEnd;
    [SerializeField] private float _FlipAngleStart;
    [SerializeField] private bool _IsFlipping;
    [SerializeField] private float _ReverseMultiplier;

    [SerializeField] private PlayerInput _InputActions;

    void Awake()
    {
        // this allows the script to interact with the playerinput asset
        _InputActions = new PlayerInput();

    }
   
    // Update is called once per frame
    void Update()
    {
        //"_IsFlipping" checks if the player has pressed the button, "_FlipperAmount" is used to store the angle of the flipper, 
        // "_ReverseMultiplier" is so that one flipper can rotate clockwise and one can go anti-clockwise with one script, 
        // "_FlipAngleEnd" means that the flipper has a spot to hit and then it will stop rotating
        if(_IsFlipping && _FlipperAmount * _ReverseMultiplier< _FlipAngleEnd)
        {
            // works out how much the flipper should change this frame
            _FlipperAmount += _FlipperSpeed * Time.deltaTime ; 
            //applys the previous calculation
            _transform.localRotation = Quaternion.Euler(0, 0, _FlipperAmount);
        }
        // does the same as the above, but happens when the flipper reaches the end angle to set it back to its origin
        else if (_FlipperAmount * _ReverseMultiplier> _FlipAngleStart)
        {
            // stops the flipper going back up and getting stuck
            _IsFlipping = false;
             // works out how much the flipper should change this frame, this time subtracting from the angle because its decreasing
            _FlipperAmount -= _FlipperSpeed * Time.deltaTime; 
            //applys the previous calculation
            _transform.localRotation = Quaternion.Euler(0, 0, _FlipperAmount);
        }
        else
        {
            //sets the angle to 0 so it always ends in the same place
            _FlipperAmount = 0;
            _transform.localRotation = Quaternion.Euler(0, 0, _FlipperAmount);
        }
        
    }

    // Method which allows the unity button objects to work the flipper 
    public void flipperMove()
    {
        _IsFlipping = true;
    }
}
