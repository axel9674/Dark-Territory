using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick horizontalJoystick;
    public Joystick verticalJoystick;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public float horizonatalDeadZone = .2f;
    public float verticalDeadZone = .7f;

    public float runSpeed = 40f;

    public float jumpRate = 2f;
    float nextJumpTime = 0f;

    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalJoystick.Horizontal >= horizonatalDeadZone)
        {
            horizontalMove = runSpeed;
        } else if (horizontalJoystick.Horizontal <= -horizonatalDeadZone)
        {
            horizontalMove = -runSpeed;
        } else
        {
            horizontalMove = 0;
        }

        /*
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        */
        if (horizontalJoystick.Vertical >= verticalDeadZone && Time.time >= nextJumpTime)
        {
            jump = true;
            nextJumpTime = Time.time + 1f / jumpRate;
        }

        /*
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
        if (horizontalJoystick.Vertical == -1)
        {
            crouch = true;
        } else if (horizontalJoystick.Vertical != -1)
        {
            crouch = false;
        }
        */
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
