using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

	[SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D other){
    	//player on trigger
    	if(other.tag == "Player" || other.tag == "Trigger"){
        		anim.SetBool("isOpen", true);
        		//Debug.Log("Collider enterd: " + other.tag);
	    }
    }

    private void OnTriggerExit2D(Collider2D other){
    	//player not on trigger
    	if(other.tag == "Player" || other.tag == "Trigger"){
        		anim.SetBool("isOpen", false);
        		//Debug.Log("Collider exited: " + other.tag);
	    }
    }
}
