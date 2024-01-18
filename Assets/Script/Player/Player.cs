using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    public float speedRun = 1.5f;

    private float vSpeed = 0f;
    
    [Header("Player Controller")]
    public KeyCode jumpKeyCode = KeyCode.Space;
    public KeyCode runKeyCode = KeyCode.LeftShift;
    
    [Header("Animator Setings")]
    public Animator animator;

    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;
        
        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if(Input.GetKeyDown(jumpKeyCode)) 
            {
                vSpeed = jumpSpeed;
            }
        }

        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        var isWaking = inputAxisVertical != 0;

        if (isWaking)
        {
            if (Input.GetKey(runKeyCode))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }

            else
            {
                animator.speed = 1f;
            }
        }

        animator.SetBool("Run", inputAxisVertical != 0);
    }
}
