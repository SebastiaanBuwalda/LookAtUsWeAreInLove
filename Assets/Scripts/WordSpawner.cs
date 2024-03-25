using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToEnable;
    private List<float> disableTimes;
    [SerializeField]
    private float initialTime;

    void Start()
    {
        disableTimes = new List<float>();
        disableTimes.Add(initialTime);
        foreach (GameObject obj in objectsToEnable)
        {
            DisableAfterTime disableScript = obj.GetComponent<DisableAfterTime>();
            if (disableScript != null)
            {
                disableTimes.Add(disableScript.disableTime);
            }
            else
            {
                Debug.LogError("DisableAfterTime script not found on GameObject: " + obj.name);
            }
        }
        
        StartCoroutine(EnableObjects());
    }

    IEnumerator EnableObjects()
    {
        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            yield return new WaitForSeconds(disableTimes[i]);
            objectsToEnable[i].SetActive(true);
        }
        
    }
}
