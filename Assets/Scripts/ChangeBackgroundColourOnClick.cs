using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeBackgroundColorOnClick : MonoBehaviour
{
    [SerializeField] private Color targetColor;
    [SerializeField] private bool useFadeEffect = false;
    [SerializeField] private float fadeDuration = 1.0f;

    private Camera mainCamera;
    private TextMeshPro clickableTextMeshPro;

    private void Start()
    {
        mainCamera = Camera.main;
        clickableTextMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (clickableTextMeshPro.color.a == 1.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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
    }

    private void OnClick()
    {
        if (useFadeEffect)
        {
            StartCoroutine(FadeBackgroundColor(targetColor, fadeDuration));
        }
        else
        {
            SetBackgroundColor(targetColor);
        }
    }

    private void SetBackgroundColor(Color color)
    {
        mainCamera.backgroundColor = color;
    }

    private IEnumerator FadeBackgroundColor(Color targetColor, float duration)
    {
        Color initialColor = mainCamera.backgroundColor;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            mainCamera.backgroundColor = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.backgroundColor = targetColor;
    }
}
