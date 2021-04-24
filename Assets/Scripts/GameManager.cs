using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance; //MARKER SINGLETON PATTERN
	public bool isPaused;

	public List<Item> items = new List<Item>(); //What kind of items we have
	public List<int> itemNumbers = new List<int>();//How many intems we have
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

	    		//update slots count text
	    		slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,1);
	    		slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
    		} else {
    			//Update slots item image
	    		slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
	    		slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

	    		//update slots count text
	    		slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,0);
	    		slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
    		}
    	}
    }

	public void AddItem(Item _item){
		//If there is one existring item in out list
		if(!items.Contains(_item)){
			items.Add(_item);
			itemNumbers.Add(1); //Add one
		} else { //if htere is new _item in the list
			Debug.Log("You already  have this item.");
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
		//If there is one existing item in our list
		if(items.Contains(_item)){
			for(int i = 0; i < items.Count; i++){
				itemNumbers[i]--;
				if(itemNumbers[i] == 0){
					items.Remove(_item);
					itemNumbers.Remove(itemNumbers[i]);
				}
			}
		} else {
			//If there is no item inside list
			Debug.Log("There is no " + _item + " in the inventory");
		}
		DisplayItems();
	}
}
