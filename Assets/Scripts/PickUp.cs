using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Item itemData;

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "Player"){
    		//Add item to inventory
    		GameManager.instance.AddItem(itemData);
    		Destroy(gameObject);
    	}
    	
    }
}
