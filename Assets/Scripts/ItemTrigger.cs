using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Use item on an object in the world*/
public class ItemTrigger : MonoBehaviour
{
	[SerializeField] private Item item;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        	Debug.Log("Removing item: " + item);
			GameManager.instance.RemoveItem(item);	
        }
    }
}
