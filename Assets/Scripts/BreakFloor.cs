using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BreakFloor : MonoBehaviour
{

	public string sceneToLoad;
	public float transitionTime = 1f;
	[SerializeField] private Animator floorAnim;
	[SerializeField] private Animator transitionAnim;


	void Start(){
		
	}


    void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			StartCoroutine(LoadLevel());
		}
    }

    IEnumerator LoadLevel() {
		floorAnim.SetTrigger("startFloorBreaking");
		yield return new WaitForSeconds(5f);
    	//Play transition animation
    	transitionAnim.SetTrigger("Start");

    	//Wait
    	yield return new WaitForSeconds(transitionTime);

    	//Load next scene
    	SceneManager.LoadScene(sceneToLoad);
    }

}
