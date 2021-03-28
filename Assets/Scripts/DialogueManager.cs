using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public string[] dialogueLines;
    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }
        if (currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
        }
        dText.text = dialogueLines[currentLine];
    }

    public void ShowBox(string dialog)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
        currentLine =  0;
    }

    public void ShowDialogue() {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
