using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
	public AudioSource egyptianTheme;
	public AudioSource doorOpen;
	private SFXManager sfxManager;
	//private static bool sfxmanagerExists;
    // Start is called before the first frame update
    void Start()
    {
    	sfxManager = FindObjectOfType<SFXManager>();
        sfxManager.egyptianTheme.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
