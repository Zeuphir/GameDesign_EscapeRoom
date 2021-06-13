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
	public float transitionTime = 1f;
	[SerializeField] private Animator transitionAnim;


	void Start(){
		door = GameObject.Find("Door");
		if(door != null){
			doorAnimator = door.GetComponent<Animator>();	
		}
		
	}


    void OnTriggerEnter2D(Collider2D other){
    	if(doorAnimator != null){
	    	if(other.tag == "Player" && doorAnimator.GetBool("isOpen") == true){
	    		StartCoroutine(LoadLevel());
	    	}
    	} else {
    		if(other.tag == "Player"){
    		StartCoroutine(LoadLevel());
    	}
    	}


    }

    IEnumerator LoadLevel() {
    	//Play transition animation
    	transitionAnim.SetTrigger("Start");

    	//Wait
    	yield return new WaitForSeconds(transitionTime);

    	//Load next scene
    	SceneManager.LoadScene(sceneToLoad);
    }

}
