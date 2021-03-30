using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

/**
 * Loads new scene if player triggers BoxCollider2D of door
 * and door is open.
 */
public class LoadNewScene : MonoBehaviour
{

	public string sceneToLoad;
	public GameObject door;
	private Animator doorAnimator;	


	void Start(){
		door = GameObject.Find("Door");
		doorAnimator = door.GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D other){
    	Debug.Log("COllision");
    	if(other.tag == "Player" && doorAnimator.GetBool("isOpen") == true){
    		SceneManager.LoadScene(sceneToLoad);
    	}
    }
}
