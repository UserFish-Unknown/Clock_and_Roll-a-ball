using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    // movement along X & Y axis
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // retrieves the Rigidbody component attached to the player object
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // called when the player moves
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    // called once per fixed frame-rate frame
    void FixedUpdate()
    {   
        // create a new Vector3 for movement based on the input values
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        // apply a force to the Rigidbody to move the player
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the player has collided with a "PickUp" object
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if the player has collided with a "Enemy" object
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            // sets the lose text when the player collides with an enemy
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
