using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Use item on an object in the world*/
public class ItemTrigger : MonoBehaviour
{
	[SerializeField] private Animator anim; //Animation that should play when event is triggered
	[SerializeField] private Item item; //Item necessary to trigger event
	[SerializeField] private Item rewardItem; //Item is then added in the inventory
    
    private bool inside;

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.Space))
        { 
	        if (GameManager.instance.itemPresent(item))
	        {
	            Debug.Log("Removing item: " + item);
	            GameManager.instance.RemoveItem(item);
	                
	            anim.SetTrigger("Open");
	            GameManager.instance.AddItem(rewardItem);
	        }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = false;
        }
    }
}