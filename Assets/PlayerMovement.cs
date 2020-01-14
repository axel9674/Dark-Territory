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

    public float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = horizontalJoystick.Horizontal * runSpeed;

        /*
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        */
        if (verticalJoystick.Vertical == 1)
        {
            jump = true;
        }
        /*
       if (Input.GetButtonDown("Crouch"))
       {
           crouch = true;
       } else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
       */
        if (verticalJoystick.Vertical == -1)
        {
            crouch = true;
        }
        else if (verticalJoystick.Vertical != -1)
        {
            crouch = false;
        }


    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
