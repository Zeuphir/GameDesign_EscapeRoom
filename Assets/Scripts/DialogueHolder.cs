using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;
    public string[] dialogueLines;

    private bool inside;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (inside &&  Input.GetKeyDown(KeyCode.F))
        {
           
                if (!dMan.dialogActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
        }
    }
}
