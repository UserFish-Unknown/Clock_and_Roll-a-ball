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
    public GameObject timerObject;
    public float timer;

    // retrieves the Rigidbody component attached to the player object
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        timerObject.SetActive(true);
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

        // check if the player has collected 10 pickups and display the win text if so
        if (count >= 10)
        {
            winTextObject.SetActive(true);
            // destroy all enemies objects in the scene when the player wins
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
        }
    }

    void SetTimerText(float time)
    {
        // sets timer that decreases over time and displays it on the screen
        timerObject.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F0");
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            // sets the lose text when the timer reaches 0
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            Destroy(gameObject);
        }
    }

    // called once per fixed frame-rate frame
    void FixedUpdate()
    {   
        // create a new Vector3 for movement based on the input values
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        // apply a force to the Rigidbody to move the player
        rb.AddForce(movement * speed);

        // update the timer text every frame
        if (winTextObject.activeSelf == false)
        {
            SetTimerText(timer);
        }
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
