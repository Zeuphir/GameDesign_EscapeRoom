using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroScript : MonoBehaviour
{
	public string sceneToLoad;
	public float wait_time = 14f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }


    IEnumerator Wait_for_intro() {
    	//Wait
    	yield return new WaitForSeconds(wait_time);

    	//Load next scene
    	SceneManager.LoadScene(sceneToLoad);
	}
}
