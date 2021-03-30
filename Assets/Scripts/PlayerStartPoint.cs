using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

	private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
     //Finds object that has the script PlayerController.cs attached to it.
     player = FindObjectOfType<PlayerController>();   
     player.transform.position = transform.position;
    }

}
