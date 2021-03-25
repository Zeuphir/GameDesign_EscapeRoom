using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask obj_mask;

    private Rigidbody2D rigid_body;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Player") { rigid_body.isKinematic = false; }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { rigid_body.isKinematic = true; }
        rigid_body.velocity = Vector2.zero;
    }

    

}
