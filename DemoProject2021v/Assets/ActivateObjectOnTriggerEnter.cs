using UnityEngine;

public class ActivateObjectOnTriggerEnter : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            Debug.Log("Activated: " + objectToActivate.name);
        }
        else
        {
            Debug.LogWarning("objectToActivate not assigned!");
        }
    }
}
