using UnityEngine;
using TMPro;

public class MoveTMPro : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;
    public Vector3 moveDirection = Vector3.forward;
    public Vector3 rotationAxis = Vector3.up;
   private float increasePercentage = 40f; // Percentage increase when left mouse button is held
    private float decreasePercentage = 40f; // Percentage decrease when right mouse button is held

    private float speedModifier = 1;

    void Update()
    {
        // Check for input from left mouse button
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            // Increase speed by the given percentage
            speedModifier = (100 + increasePercentage)/100;
        }

        // Check for input from right mouse button
        else if (Input.GetMouseButton(1)) // Right mouse button
        {
            // Decrease speed by the given percentage
            speedModifier = (100 - decreasePercentage)/100;
        }
        else
        {
            speedModifier = 1;
        }

        // Apply movement and rotation
        transform.Translate(moveDirection * moveSpeed * speedModifier * Time.deltaTime);
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
