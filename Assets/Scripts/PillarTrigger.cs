using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrigger : MonoBehaviour
{

	[SerializeField] private Animator animPillar;
	[SerializeField] private Animator animPressurePlate;

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "Trigger"){
        		animPillar.SetBool("isActive", true);
        		animPressurePlate.SetBool("isActive", true);
	    }
    }

    private void OnTriggerExit2D(Collider2D other){
    	if(other.tag == "Trigger"){
        		animPillar.SetBool("isActive", false);
        		animPressurePlate.SetBool("isActive", false);
	    }
    }
}
