using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    // https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
    public GameObject player;       //Public variable to store a reference to the player game object
    public Transform target;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
        
    }
}
