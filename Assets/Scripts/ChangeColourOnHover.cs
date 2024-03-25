using UnityEngine;
using TMPro;

public class ChangeColourOnHover : MonoBehaviour
{
    [SerializeField] private Color hoverColor = Color.red; // Color to change to when hovered
    private Color originalColor; // Original color of the text
    private TextMeshPro textMesh; // Reference to the TextMeshPro component
    private BoxCollider boxCollider; // Reference to the BoxCollider component

    void Start()
    {
        // Get reference to TextMeshPro component
        textMesh = GetComponent<TextMeshPro>();

        // Store the original color of the text
        originalColor = textMesh.color;

        // Get reference to BoxCollider component
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnMouseEnter()
    {
        textMesh.color = hoverColor;
        // Check if the mouse is over the BoxCollider
    }

    void OnMouseExit()
    {
        // Change text color back to original color
        textMesh.color = originalColor;
    }
}
