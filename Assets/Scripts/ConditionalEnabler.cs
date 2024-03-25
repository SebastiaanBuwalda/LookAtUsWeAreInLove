using UnityEngine;

public class ConditionalEnabler : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToEnableIfTrue; // List of objects to enable if BROUGHT WEED is true
    [SerializeField] private GameObject[] objectsToEnableIfFalse; // List of objects to enable if BROUGHT WEED is false

    void Start()
    {
        // Check if BROUGHT WEED is true or false and enable/disable objects accordingly
        if (MakeDecisionsOnClick.BROUGHT_WEED)
        {
            EnableObjects(objectsToEnableIfTrue);
            DisableObjects(objectsToEnableIfFalse);
        }
        else
        {
            EnableObjects(objectsToEnableIfFalse);
            DisableObjects(objectsToEnableIfTrue);
        }
    }

    // Enable a list of GameObjects
    void EnableObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    // Disable a list of GameObjects
    void DisableObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
