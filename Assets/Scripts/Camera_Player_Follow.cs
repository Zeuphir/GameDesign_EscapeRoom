using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player_Follow : MonoBehaviour
{
    public Transform player;

    // Smoothness factor should be 0<x<=10
    public float smooth_speed = 1.1f;
    public Vector3 camera_offset;
    void LateUpdate()
    {

        Vector3 target_position = player.position + camera_offset;
        Vector3 smoothed_position = Vector3.Lerp(transform.position, target_position, smooth_speed * Time.deltaTime);
        transform.position = smoothed_position;

    }




}
