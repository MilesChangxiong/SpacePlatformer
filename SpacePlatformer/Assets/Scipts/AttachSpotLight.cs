using UnityEngine;

public class AttachSpotlight : MonoBehaviour
{
    public Transform player;        // Reference to the player's Transform component.
    public Light spotlight;         // Reference to the spotlight's Light component.

    void Start()
    {
        // Check if the player and spotlight references are set.
        if (player == null)
        {
            Debug.LogError("Player reference not set in AttachSpotlight script.");
            return;
        }

        if (spotlight == null)
        {
            Debug.LogError("Spotlight reference not set in AttachSpotlight script.");
            return;
        }
    }

    void Update()
    {
        if (player != null && spotlight != null)
        {
            // Match the spotlight's position to the player's position.
            spotlight.transform.position = player.position;
        }
    }
}
