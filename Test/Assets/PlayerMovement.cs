// this player controller is based off of 
// http://www.instructables.com/id/Unity-25D-Character-Control-in-Platform-Side-scrol/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator anim;
    public float smooth = 1f;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Quaternion lookLeft;
    private Quaternion lookRight;
    private Vector3 moveDirection = Vector3.zero;
    

    void Start()
    {
        Cursor.visible = true;
        
        Time.timeScale = 1;

        lookRight = Quaternion.Euler(0, 90, 0);
        lookLeft = Quaternion.Euler(0, -90, 0);
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {

            //anim.SetBool("IsRunning", false);

            //moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            moveDirection = new Vector3(Input.GetAxis("Vertical"), 0,0);

            //if (Input.GetKey(KeyCode.A))
            //{

            //    // Convert the euler angles to transform positions
            //    Vector3 currentRotation = transform.eulerAngles;


            //    if (currentRotation.y > -90)
            //    {
            //        currentRotation.y = currentRotation.y - 2;
            //        transform.rotation = Quaternion.Euler(currentRotation);
            //    }





            //    //moveDirection = transform.TransformDirection(-moveDirection);
            //    //moveDirection *= speed;

            ////   // anim.SetBool("IsRunning", true);

            //}

            //if (Input.GetKey(KeyCode.D))
            //{
            //    //    transform.rotation = lookRight;
            //    transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z), lookRight, Time.time);
            //    //    moveDirection = transform.TransformDirection(moveDirection);
            //    //    moveDirection *= speed;
            //    //    //anim.SetBool("IsRunning", true);
            //}
            Move();



        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * speed * Time.deltaTime);
        
    }



    void Move()
    {

        // This is the jump movement
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z), lookLeft, Time.time * 0.5f);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z), lookRight, Time.time * 0.5f);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }



        }

    void Turn(string direction)
    {

    }



}
