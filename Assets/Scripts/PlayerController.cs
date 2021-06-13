using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D myRigidbody;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {   

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        // RIGHT || LEFT
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
        }

        // UP || DOWN
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x , Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        //Stop at barrier - horizontal
        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f){
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        //Stop at barrier - vertical
        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f){
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }




}
