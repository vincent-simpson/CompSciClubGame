using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

     public float moveSpeed;
     public float jumpHeight;
     public CharacterController2D controller;
     public float horizontalMove = 0f;
     public float verticalMove = 0f;
     bool jump = false;
     public Animator animator;

     int jumpCount = 0; //keep track of the number of allowed jumps we have left
     int maxJumps = 1; //the total number of max jumps allowed

     // Use this for initialization
     void Start()
     {
          jumpCount = maxJumps;
     }

     // Update is called once per frame
     void Update()
     {
          horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
          verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;

          animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

          if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
          {
               jump = true;
               controller.Move(verticalMove, false, jump);
               jumpCount -= 1;

               animator.SetBool("Jump", true); //show jump animation. I noticed a small delay when this was placed in the Move() function
                                               //of character controller so it seems more responsive here.
               jump = false;
          }

          if (Input.GetKey(KeyCode.D))
          {
               controller.Move(horizontalMove, false, jump);
          }

          if (Input.GetKey(KeyCode.A))
          {
               controller.Move(horizontalMove, false, jump);
          }
     }

     public void m_Grounded()
     {
          animator.SetBool("Jump", false);
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          jumpCount = maxJumps;
          m_Grounded();
     }






}
