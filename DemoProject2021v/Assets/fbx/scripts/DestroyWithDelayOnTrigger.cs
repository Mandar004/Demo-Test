using System.Collections;
using UnityEngine;

public class DestroyWithDelayOnTrigger : MonoBehaviour
{
    public float delayBeforeDestroy = 2f; // Delay in seconds before destroying

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.name);

        // Start the coroutine to destroy after delay
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        Debug.Log("Waiting for " + delayBeforeDestroy + " seconds before destroy...");

        yield return new WaitForSeconds(delayBeforeDestroy);

        Destroy(gameObject);
        Debug.Log("Scissors destroyed after delay!");
    }
}
