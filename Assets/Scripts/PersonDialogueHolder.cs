using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    public string[] firstDialogueLines;
    public string[] secondDialogueLines;
    public GameObject parent;

    private bool firstTalk;
    private bool inside;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        inside = false;
        firstTalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.F))
        {

            if (!dMan.dialogActive && !firstTalk)
            {
                firstTalk = true;
                dMan.dialogueLines = firstDialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
            }
            else if (!dMan.dialogActive && firstTalk)
            {
                parent.transform.gameObject.tag = "Trigger";
                dMan.dialogueLines = secondDialogueLines;
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
