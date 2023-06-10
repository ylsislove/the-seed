using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public GameObject playerCtrl;
    public VariableJoystick joystickLeft;
    public VariableJoystick joystickRight;
    private float _moveInputX;
    private float _moveInputY;
    private float _moveInputX1;
    private float _moveInputY1;
    private Vector3 _movement;
    private Vector3 _movement1;
    public float speed;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveInputX = joystickLeft.Direction.x;
        _moveInputY = joystickLeft.Direction.y;
        if (_moveInputX == 0 && _moveInputY == 0)
        {
            playerCtrl.GetComponent<Animator>().SetBool(IsRunning, false);
        }
        else
        {
            playerCtrl.GetComponent<Animator>().SetBool(IsRunning, true);
        }

        _moveInputX1 = joystickRight.Direction.x;
        _moveInputY1 = joystickRight.Direction.y;
        if (_moveInputX1 == 0 && _moveInputY1 == 0)
        {
            playerCtrl.GetComponent<Animator>().SetBool(IsWalking, false);
        }
        else
        {
            playerCtrl.GetComponent<Animator>().SetBool(IsWalking, true);
        }
    }

    private void FixedUpdate()
    {
        _movement = new Vector3(_moveInputY * -speed, 0, _moveInputX * speed);
        GetComponent<CharacterController>().Move(_movement);

        if (_moveInputX != 0 || _moveInputY != 0)
        {
            var lookDir = new Vector3(_movement.x, 0, _movement.z);
            playerCtrl.GetComponent<Transform>().rotation = Quaternion.LookRotation(lookDir);
        }
        
        _movement1 = new Vector3(_moveInputY1 * -speed, 0, _moveInputX1 * speed);
        GetComponent<CharacterController>().Move(_movement1);

        if (_moveInputX1 != 0 || _moveInputY1 != 0)
        {
            var lookDir1 = new Vector3(_movement1.x, 0, _movement1.z);
            playerCtrl.GetComponent<Transform>().rotation = Quaternion.LookRotation(lookDir1);
        }
    }

    public void animplay(string animClipname)
    {
        playerCtrl.GetComponent<Animator>().Play(animClipname);
    }
}
