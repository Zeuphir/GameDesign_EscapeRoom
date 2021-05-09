using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{   

    public BoxCollider2D door_collider;


    public Animator door_animation;
    public SFXManager sfxManager;
    public int limit;
    public int count = 0;
    public string door_name;
    public bool debug_mode;

    private bool already_open;



    void Start()
    {
        already_open = false;
    }


    public void openDoor() {
        door_collider.enabled = false;
        //GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        door_animation.SetBool("isOpen", true);
        //sfxManager.doorOpen.Play(); //Play door opening sound
    }

    public void closeDoor() {
        door_collider.enabled = true;
        //GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        door_animation.SetBool("isOpen", false);
        //sfxManager.doorOpen.Play(); //Play door opening sound
    }

    public bool check_if_openable() {
        return count >= limit;
    }

    public void increase_count() {

            count++;
            check_and_change_door();
            if (debug_mode) { Debug.Log("Count has increased for " + door_name + ". Count is now: " + count); }
        
    }

    public void decrease_count() {

            count--;
            check_and_change_door();
            if (debug_mode) { Debug.Log("Count has decreased for " + door_name+". Count is now: "+count); }
        
    }

    public void check_and_change_door() {
        if (check_if_openable())
        {
            if (!already_open)
            {
                already_open = true;
                openDoor();
                if (debug_mode) { Debug.Log("Door " + door_name + " has been opened."); }
            }
        }
        else
        {
            if (already_open)
            {
                already_open = false;
                closeDoor();
                if (debug_mode) { Debug.Log("Door " + door_name + " has been closed."); }
            }
        }

    }

}
