using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public GameObject imgBox;
    public Image image;
    public Sprite spriteToChangeItTo;
    public bool imageActive;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (imageActive && Input.GetKeyDown(KeyCode.Space))
        {
            imageActive = false;
            imgBox.SetActive(false);
            thePlayer.canMove = true;
        }
    }

    public void ChangeSpriteAndShowIt(Sprite sprite)
    {
        image.overrideSprite = sprite;
    }

    public void ShowImage()
    {
        imageActive = true;
        imgBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
