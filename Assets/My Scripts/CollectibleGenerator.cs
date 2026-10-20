using UnityEngine;

public class CollectibleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab; // Prefab of the collectible object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        for (int i = 0; i < 9; i++) // Generate 9 collectibles
        {
            // Generate random positions for the collectibles within a specified range
            float randomX = Random.Range(-18.0f, 18.0f);
            float randomZ = Random.Range(-18.0f, 18.0f);
            Vector3 randomPosition = new Vector3(randomX, 2f, randomZ); // Set Y position to 2f for visibility

            // Instantiate the collectible at the random position with no rotation
            Instantiate(collectiblePrefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
