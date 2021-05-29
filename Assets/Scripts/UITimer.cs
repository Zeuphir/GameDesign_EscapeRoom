using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITimer : MonoBehaviour
{
    public Text TimerText;
    public bool playing;
    private float timer = 1800;
    public string game_over_scene_name;
    private bool reached_zero;

    // Start is called before the first frame update
    void Start()
    {
        reached_zero = false;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!reached_zero) { 
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
        TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
            CheckIfOver();
        }
    }

    void CheckIfOver() {
        if (timer<=0) {
            reached_zero = true;
            TimerText.text = "Failed";
            SceneManager.LoadScene(game_over_scene_name);
   
        }
        
    }
}
