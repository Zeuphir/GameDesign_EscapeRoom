using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_DoorHandler : MonoBehaviour
{

    public DoorHandler door;
    public float radius = 1.0f;
    public string plate_name;
    public bool debug;
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;

    }

    private void Update()
    {

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(GetComponent<Transform>().position,radius);

        if (System.Array.Find(hitColliders, element => element.tag == "Trigger"))
        {
            press_plate();
           // Debug.Log("Activated Plate. Status: " + pressed);
        }
        else {
            depress_plate();
           //Debug.Log("Deactivated Plate. Status: "+pressed);
        }

    }

    private void press_plate() {

        if (!pressed) {
            pressed = true;
            door.increase_count();
            debug_information();
        }
    }

    private void depress_plate()
    {
        if (pressed)
        {
            pressed = false;
            door.decrease_count();
            debug_information();
        }
    }

    private void debug_information() {
        if (debug) {

            if (pressed) { Debug.Log("Plate " + plate_name + " is active. "); }
            else { Debug.Log("Plate " + plate_name + " is not active."); }

        }

        
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetComponent<Transform>().position, radius);
    }

}
