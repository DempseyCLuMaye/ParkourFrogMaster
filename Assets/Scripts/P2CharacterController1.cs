using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class P2PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
 
    public bool canScoreP2 = false;

    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;
 
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        var hInput = Input.GetAxis("P2Horizontal");
        var vInput = Input.GetAxis("P2Vertical");

        speed = Random.Range(3f, 10f);
 
        if(characterController.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            
            if(Input.GetButtonDown("P2Jump"))
            {
                canScoreP2 = true;
                moveVelocity.y = jumpSpeed;
            }
            else
            {
                canScoreP2 = false;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

    public bool CanScoreP2()
    {
        return canScoreP2;
    }
}