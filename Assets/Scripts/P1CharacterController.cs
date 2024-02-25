using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class P1PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;

    public bool CanJump = true;

    public bool canScoreP1 = false;
 
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;
 
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        var hInput = Input.GetAxis("P1Horizontal");
        var vInput = Input.GetAxis("P1Vertical");

        speed = Random.Range(3f, 10f);
 
        if(characterController.isGrounded)
        {
            CanJump = true;

            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            
            
        }

        if(CanJump == true)
        {
            if(Input.GetButtonDown("P1Jump"))
            {
                CanJump = false;
                canScoreP1 = true;
                moveVelocity.y = jumpSpeed;

            }
            else
            {
                canScoreP1 = false;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

    public bool CanScoreP1()
    {
        return canScoreP1;
    }
}