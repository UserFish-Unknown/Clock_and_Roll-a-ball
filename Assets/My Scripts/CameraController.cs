using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // distance between player and camera

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // calculates distance between player and camera at the start of the game
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        // maintains the distance between player and camera throughout the game
        transform.position = player.transform.position + offset;
    }
}
