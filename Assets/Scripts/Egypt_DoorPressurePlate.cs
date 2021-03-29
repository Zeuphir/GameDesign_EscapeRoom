using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egypt_DoorPressurePlate : MonoBehaviour
{
	[SerializeField] private Animator anim;
	public int occupants;

    private void OnTriggerEnter2D(Collider2D other){
    	//player on trigger
    	if(other.tag == "Player" || other.tag == "Trigger"){
        		anim.SetBool("isOpen", true);
        		//anim.SetTrigger("OpenClose");
        		occupants++;
        		Debug.Log("Collider entered: " + other.tag + "# present: " + occupants);
	    }
    }

    private void OnTriggerExit2D(Collider2D other){
    	//player not on trigger
    	if((other.tag == "Player" || other.tag == "Trigger") && occupants > 0){
        		anim.SetBool("isOpen", true);
        		//anim.SetTrigger("OpenClose");
        		occupants--;
        		Debug.Log("Collider exited: " + other.tag + "# present: " + occupants);
	    }
	}

	/*private void OnTriggerStay2D(Collider2D other){
    	//player not on trigger
    	if(other.tag == "Player" || other.tag == "Trigger"){
        		anim.SetBool("isOpen", true);
        		Debug.Log("Collider exited: " + other.tag);
	    }
    }*/
}
