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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (imageActive && Input.GetKeyDown(KeyCode.Space))
        {
            imageActive = false;
            imgBox.SetActive(false);
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
    }
}
