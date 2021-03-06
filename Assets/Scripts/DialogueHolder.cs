using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
	[SerializeField] private Animator anim; //Talking animation for cats
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
        if (inside && Input.GetKeyDown(KeyCode.F))
        {
            if (!dMan.dialogActive)
            {
                if (anim)
                {
                    anim.SetBool("isTalking", true);
                }
	
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
            }

        }

        if (!dMan.dialogActive)
        {
            if (anim)
            {
                anim.SetBool("isTalking", false);
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

    public void setDLines(string[] lines)
    {
        dialogueLines = lines;
    }
}