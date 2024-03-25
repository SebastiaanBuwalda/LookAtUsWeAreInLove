using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float disableTime = 3f; 
    [SerializeField]
    private bool useMusicTimeInstead = false;

    void Start()
    {
    if(useMusicTimeInstead)
        {
            //TODO add the usage of music time
        }
        Invoke("DisableObject", disableTime); 

        // TODO Invoke the method DisableObject after disableTime seconds
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
