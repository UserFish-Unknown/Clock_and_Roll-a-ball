using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xRotationSpeed = 10f; // Rotation speed around the X-axis
    public float yRotationSpeed = 25f; // Rotation speed around the Y-axis
    public float zRotationSpeed = 35f; // Rotation speed around the Z-axis
    
    // Update is called once per frame
    void Update()
    {
        // Rotate the object on X, Y, and Z axes by specified amounts, adjusted for frame rate.
        transform.Rotate(new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed) * Time.deltaTime);
    }
}
