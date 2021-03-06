using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

	[SerializeField] private Animator anim;
	private SFXManager sfxManager;

    private void OnTriggerEnter2D(Collider2D other){
    	sfxManager = FindObjectOfType<SFXManager>();
    	if(other.tag == "Trigger"){
        		anim.SetBool("isOpen", true);
        		sfxManager.doorOpen.Play(); //Play door opening sound
	    }
    }

    private void OnTriggerExit2D(Collider2D other){
    	if(other.tag == "Trigger"){
        		anim.SetBool("isOpen", false);
	    }
    }
}
