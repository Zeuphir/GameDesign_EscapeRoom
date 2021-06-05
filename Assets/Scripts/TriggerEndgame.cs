using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndgame : MonoBehaviour
{

    public string sceneToLoad;
    public float transitionTime = 1f;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load next scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
