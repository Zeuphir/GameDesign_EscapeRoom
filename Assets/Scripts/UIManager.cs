using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public GameObject pauseMenu;
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        PauseControl();
    }

    private void PauseControl()
    {	if(Input.GetKeyDown(KeyCode.P)){
	    	if(GameManager.instance.isPaused){
	    	//if game is paused, press Escape, Resume game
	    		Resume();
    		//if game is resume, press Escape, Pause the 
	    	} else {
	    		Pause();
	    	}
    	}
    }

    private void Resume(){
    	pauseMenu.gameObject.SetActive(false);
    	Time.timeScale = 1.0f; // Real time is 1 
    	GameManager.instance.isPaused = false;
    }

    private void Pause(){
    	pauseMenu.gameObject.SetActive(true);
    	Time.timeScale = 0.0f; //Stop the time
    	GameManager.instance.isPaused = true;
    }
}