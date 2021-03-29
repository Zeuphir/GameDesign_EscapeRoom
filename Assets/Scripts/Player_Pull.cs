using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pull : MonoBehaviour
{
    public float pull_distance = 1f;
    public LayerMask box_mask;
    GameObject pullable;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
         
        RaycastHit2D right_hit = Physics2D.Raycast(transform.position, Vector2.right, pull_distance, box_mask);
        RaycastHit2D left_hit = Physics2D.Raycast(transform.position, Vector2.left, pull_distance, box_mask);
        RaycastHit2D up_hit = Physics2D.Raycast(transform.position, Vector2.up, pull_distance, box_mask);
        RaycastHit2D down_hit = Physics2D.Raycast(transform.position, Vector2.down, pull_distance, box_mask);




        if (right_hit.collider != null && right_hit.collider.gameObject.tag == "Trigger" && Input.GetKeyDown(KeyCode.E)) {
            pullable = right_hit.collider.gameObject;
            pullable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            pullable.GetComponent<FixedJoint2D>().enabled = true;
            pullable.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (up_hit.collider != null && up_hit.collider.gameObject.tag == "Trigger" && Input.GetKeyDown(KeyCode.E))
        {
            pullable = up_hit.collider.gameObject;
            pullable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            pullable.GetComponent<FixedJoint2D>().enabled = true;
            pullable.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (left_hit.collider != null && left_hit.collider.gameObject.tag == "Trigger" && Input.GetKeyDown(KeyCode.E))
        {
            pullable = left_hit.collider.gameObject;
            pullable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            pullable.GetComponent<FixedJoint2D>().enabled = true;
            pullable.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        else if (down_hit.collider != null && down_hit.collider.gameObject.tag == "Trigger" && Input.GetKeyDown(KeyCode.E))
        {
            pullable = down_hit.collider.gameObject;
            pullable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            pullable.GetComponent<FixedJoint2D>().enabled = true;
            pullable.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E)) {
            pullable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            pullable.GetComponent<FixedJoint2D>().enabled = false;
            pullable.GetComponent<FixedJoint2D>().connectedBody = null;

        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * pull_distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * pull_distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * pull_distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * pull_distance);
    }





}
