using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHolder : MonoBehaviour
{
    private ImageManager dimgMan;
    public Sprite spri;

    private bool inside;

    // Start is called before the first frame update
    void Start()
    {
        dimgMan = FindObjectOfType<ImageManager>();
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.F))
        {

            if (!dimgMan.imageActive)
            {
                dimgMan.ChangeSpriteAndShowIt(spri);
                dimgMan.ShowImage();
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
