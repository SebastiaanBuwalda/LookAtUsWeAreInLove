using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeDecisionsOnClick : MonoBehaviour
{
    public static bool BROUGHT_WEED = false; // Changed variable name to follow convention
    [SerializeField]
    private string nextScene; // Scene to load if variable is false

    [SerializeField]
    private bool setToThis;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnClick();
                }
            }
        }
    }

    private void OnClick()
    {
        // Change the static variables here based on your condition
        BROUGHT_WEED = setToThis; // Example: Set BROUGHT_WEED to true when clicked
        SceneManager.LoadScene(nextScene);
    
    }
}
