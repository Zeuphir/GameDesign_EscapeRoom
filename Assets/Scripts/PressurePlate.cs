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
	[SerializeField] private int limit; // number necessary triggers for event to happen
	private SFXManager sfxManager;
	public static int count = 0;


    private void OnTriggerEnter2D(Collider2D other){
    	sfxManager = FindObjectOfType<SFXManager>();
    	count++;
    	if(other.tag == "Trigger" && count == limit){
        		sfxManager.doorOpen.Play(); //Play door opening sound
        		anim.SetBool("isOpen", true);

	    }
	    Debug.Log("Enter: " + count);
    }

    private void OnTriggerExit2D(Collider2D other){
    	count--;
    	if(other.tag == "Trigger" && count == limit){
        		anim.SetBool("isOpen", false);
	    }
	    Debug.Log("Exit: " + count);
	}


}
