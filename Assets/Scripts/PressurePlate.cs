using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Generic pressure plate trigger script.
 * For use: set object name(s) that should trigger pressre plate,
 * add animator in the Unity UI and make sure that the animator 
 * has a isOpen parameter.  
 */
public class PressurePlate : MonoBehaviour
{
	public string validTrigger; //Object name that can trigger pressure plate
	[SerializeField] private Animator anim;
	[SerializeField] private int limit; // number necessary triggers for event to happen
	private SFXManager sfxManager;
	public static int count = 0;


    private void OnTriggerEnter2D(Collider2D other){
    	sfxManager = FindObjectOfType<SFXManager>();
    	if(validTrigger == other.name){
    		count++;	
    	}
    	
    	if(validTrigger == other.name && count == limit){
        		sfxManager.doorOpen.Play(); //Play door opening sound
        		anim.SetBool("isOpen", true);

	    }
	    //Debug.Log("Enter: " + count);
    }

    private void OnTriggerExit2D(Collider2D other){    	
    	if(validTrigger == other.name){
    		count--;	
    	}
    	if(validTrigger == other.name && count != limit){
        		anim.SetBool("isOpen", false);
	    }
	    //Debug.Log("Exit: " + count);
	}

    public void SETSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void SETValidTrigger(string newTrigger)
    {
        this.validTrigger = newTrigger;
    }
}
