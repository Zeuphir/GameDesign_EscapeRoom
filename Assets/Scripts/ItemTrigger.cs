using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Use item on an object in the world*/
public class ItemTrigger : MonoBehaviour
{
	[SerializeField] private Animator anim; //Animation that should play when event is triggered
	[SerializeField] private Item triggerItem; //Item necessary to trigger event
	[SerializeField] private Item rewardItem; //Item is then added in the inventory
    
    private bool inside;

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        { 
	        if (GameManager.instance.itemPresent(triggerItem))
	        {
	           // Debug.Log("Removing item: " + triggerItem);
	            GameManager.instance.RemoveItem(triggerItem);
	                
	            anim.SetBool("isOpen", true);
	
               if(rewardItem != null) {
                    GameManager.instance.AddItem(rewardItem);
                } 

	        } else if (triggerItem == null){ //Animation triggered without triggerItem
                anim.SetBool("isOpen", true);

                if(rewardItem != null) {
                    GameManager.instance.AddItem(rewardItem);
                }              
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