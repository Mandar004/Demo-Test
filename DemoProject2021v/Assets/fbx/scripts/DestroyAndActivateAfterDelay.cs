using System.Collections;
using UnityEngine;

public class DestroyAndActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate;  // Object to activate after delay
    public float delayBeforeHide = 1f;    // Time to wait before hiding scissors
    public float delayBeforeActivate = 2f; // Time after collision to activate next object
    public GameObject scissorVisual;      // Visual part of scissors (optional)

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(HandleDestroyAndActivate());
    }

    private IEnumerator HandleDestroyAndActivate()
    {
        Debug.Log("Collision detected, starting sequence!");

        // 🕐 Wait BEFORE hiding scissors
        yield return new WaitForSeconds(delayBeforeHide);

        // 🔥 Hide visuals
        if (scissorVisual != null)
        {
            scissorVisual.SetActive(false);
        }
        
        // 🔥 Disable collider immediately after hide
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // 🔥 Freeze Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }

        // 🕐 Wait more until activation
        float extraWait = delayBeforeActivate - delayBeforeHide;
        if (extraWait > 0f)
        {
            yield return new WaitForSeconds(extraWait);
        }

        // 🎯 Activate the next object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            Debug.Log("Activated: " + objectToActivate.name);
        }
        else
        {
            Debug.LogWarning("No object assigned to activate!");
        }

        // 🧹 Finally destroy the scissors object
        Destroy(gameObject);
        Debug.Log("Scissors destroyed completely!");
    }
}
