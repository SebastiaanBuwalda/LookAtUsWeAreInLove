using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableDisableOnClick : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDisable;

    [SerializeField]
    private List<GameObject> objectsToEnable;

    [SerializeField]
    private bool useFadeEffect = false;

    [SerializeField]
    private float fadeDuration = 1.0f;

    private Dictionary<GameObject, TextMeshPro> textMeshMap = new Dictionary<GameObject, TextMeshPro>();
    private TextMeshPro clickableTextMeshPro;

    void Start()
    {
        // Store TextMeshPro components of objects to enable/disable for fading
        foreach (var obj in objectsToEnable)
        {
            var textMeshPro = obj.GetComponent<TextMeshPro>();
            if (textMeshPro != null)
                textMeshMap.Add(obj, textMeshPro);
        }

        foreach (var obj in objectsToDisable)
        {
            var textMeshPro = obj.GetComponent<TextMeshPro>();
            if (textMeshPro != null)
                textMeshMap.Add(obj, textMeshPro);
        }

        // Get TextMeshPro component of the clickable object
        clickableTextMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        // Check if alpha of clickable object is fully filled
        if (clickableTextMeshPro.color.a == 1.0f)
        {
            // Only proceed with click if the alpha is fully filled
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
    }

    private void OnClick()
    {
        foreach (var obj in objectsToDisable)
        {
            if (useFadeEffect)
                FadeOut(obj);
            else
                obj.SetActive(false);
        }

        foreach (var obj in objectsToEnable)
        {
            if (useFadeEffect)
                FadeIn(obj);
            else
                obj.SetActive(true);
        }
    }

    private void FadeOut(GameObject obj)
    {
        TextMeshPro textMeshPro;
        if (textMeshMap.TryGetValue(obj, out textMeshPro))
        {
            StartCoroutine(FadeTextToZeroAlpha(textMeshPro, fadeDuration));
        }
    }

    private void FadeIn(GameObject obj)
    {
        TextMeshPro textMeshPro;
        if (textMeshMap.TryGetValue(obj, out textMeshPro))
        {
            StartCoroutine(FadeTextToFullAlpha(textMeshPro, fadeDuration));
        }
    }

    IEnumerator FadeTextToZeroAlpha(TextMeshPro textMeshPro, float duration)
    {
        float elapsedTime = 0;
        Color color = textMeshPro.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(color.a, 0, elapsedTime / duration);
            textMeshPro.color = new Color(color.r, color.g, color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is exactly 0 and make the object disappear
        textMeshPro.color = new Color(color.r, color.g, color.b, 0);
        textMeshPro.gameObject.SetActive(false);
    }

    IEnumerator FadeTextToFullAlpha(TextMeshPro textMeshPro, float duration)
    {
        float elapsedTime = 0;
        Color color = textMeshPro.color;

        textMeshPro.gameObject.SetActive(true);

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(color.a, 1, elapsedTime / duration);
            textMeshPro.color = new Color(color.r, color.g, color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is exactly 1
        textMeshPro.color = new Color(color.r, color.g, color.b, 1);
    }
}
