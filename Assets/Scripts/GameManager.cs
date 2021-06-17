using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public List<Item> items = new List<Item>(); //What kind of items we have
	public List<int> itemNumbers = new List<int>();//How many items we have
	public GameObject[] slots;

    private void Awake()
    {
    	if(instance == null){
    		instance = this;
    	} else {
    		if(instance != this){
    			Destroy(gameObject);
    		}
    	}
    	DontDestroyOnLoad(gameObject);      
    }

    private void Start(){
    	DisplayItems();
    }


    private void DisplayItems(){
    	//WE ignore the fact
    	for(int i = 0; i< slots.Length; i++){
    		if(i < items.Count){
	    		//Update slots item image
	    		slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
	    		slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

    		} else {
    			//Update slots item image
	    		slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
	    		slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
    		}
    	}
    }

	public void AddItem(Item _item){
		//If there is one existing item in the list
		if(!items.Contains(_item)){
			items.Add(_item);
			itemNumbers.Add(1); //Add one
		} else {
			//if _item is new in the list
			for(int i = 0; i < items.Count; i++){
				if(items[i] == _item){
					itemNumbers[i]++;
				}
			}
		}
		DisplayItems();
	}

	public void RemoveItem(Item _item)
	{
		//If item is in the list
		if(items.Contains(_item)){
			//Debug.Log(_item + " is in the list");
			for(int i = 0; i < items.Count; i++){
				itemNumbers[i]--;
				if(itemNumbers[i] == 0){
					items.Remove(_item);
					itemNumbers.Remove(itemNumbers[i]);
				}
			}
		}
		DisplayItems();
	}

	public bool itemPresent(Item _item)
    {
		if (items.Contains(_item))
		{
			//Debug.Log(_item + " is in the list");
			for (int i = 0; i < items.Count; i++)
			{
				itemNumbers[i]--;
				if (itemNumbers[i] == 0)
				{
					items.Remove(_item);
					itemNumbers.Remove(itemNumbers[i]);
				}
			}
			return true;
		}
		else
		{
			//If there is no item in the list
			//Debug.Log("There is no " + _item + " in the inventory");
			return false;
		}
	}
}
