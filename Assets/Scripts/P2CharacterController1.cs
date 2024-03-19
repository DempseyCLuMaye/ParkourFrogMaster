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
 
    public bool CanJump = true;

    public bool canScoreP2 = false;

    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;


    public CoinCount coinCount;

    private bool isBoosting = false;
 
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        var hInput = Input.GetAxis("P2Horizontal");
        var vInput = Input.GetAxis("P2Vertical");

        if (isBoosting == false)
        {
            speed = Random.Range(3f, 10f);
        }
    
 
        if(characterController.isGrounded)
        {
            CanJump = true;

            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            
            
        }


        if (Input.GetButtonDown("P2Ability") && coinCount.coinAmount > 0)
        {
            coinCount.coinAmount--;
            StartCoroutine(SpeedBoost());
        }
        

        if(CanJump == true)
        {
            if(Input.GetButtonDown("P2Jump"))
            {
                CanJump = false;
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

    IEnumerator SpeedBoost()
    {
        isBoosting = true;
        speed = 10;
        rotationSpeed = 200;
        jumpSpeed = 20;
        yield return new WaitForSeconds(8);
        speed = 3;
        rotationSpeed = 90;
        jumpSpeed = 15;
        isBoosting = false;
    }
}