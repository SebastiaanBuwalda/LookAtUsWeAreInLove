using UnityEngine;

public class BackgroundColorMorph : MonoBehaviour
{
    public Color targetColor = Color.blue; // Change this to the desired target color
    public float transitionTime = 2.0f; // Change this to the desired transition time in seconds

    private Camera mainCamera;
    private Color initialColor;
    private float transitionTimer;
    private bool transitioning = false;

    void Start()
    {
        mainCamera = Camera.main;
        initialColor = mainCamera.backgroundColor;
    }

    void OnEnable()
    {
        StartTransition();
    }

    void Update()
    {
        if (transitioning)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionTime);
            mainCamera.backgroundColor = Color.Lerp(initialColor, targetColor, t);

            if (transitionTimer >= transitionTime)
            {
                transitioning = false;
            }
        }
    }

    void StartTransition()
    {
        transitioning = true;
        transitionTimer = 0f;
    }
}
