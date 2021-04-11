using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Generic pressure plate trigger script.
 * For use: add animator in the Unity UI and 
 * make sure that the animator has a isOpen parameter.  
 */
public class PressurePlate : MonoBehaviour
{
	[SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "Trigger"){
        		anim.SetBool("isOpen", true);
	    }
    }

    private void OnTriggerExit2D(Collider2D other){
    	if(other.tag == "Trigger"){
        		anim.SetBool("isOpen", false);
	    }
	}

}
