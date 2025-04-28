using System.Collections;
using UnityEngine;

public class DestroyAndActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate;  
    public float delayBeforeHide = 1f;   
    public float delayBeforeActivate = 2f; 
    public GameObject scissorVisual;     

    public AudioSource audioSource; 
    public AudioClip audioClip;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(HandleDestroyAndActivate());
    }

    private IEnumerator HandleDestroyAndActivate()
    {
        Debug.Log("Collision detected, starting sequence!");

        yield return new WaitForSeconds(delayBeforeHide);

        if (scissorVisual != null)
        {
        Debug.Log("scissorVisual.SetActive(false)");
            scissorVisual.SetActive(false);
            audioSource.Play();
        }
        
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }

        float extraWait = delayBeforeActivate - delayBeforeHide;
        if (extraWait > 0f)
        {
            yield return new WaitForSeconds(extraWait);
        }

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            Debug.Log("Activated: " + objectToActivate.name);
        }
        else
        {
            Debug.LogWarning("No object assigned to activate!");
        }

        Destroy(gameObject);
        Debug.Log("Scissors destroyed completely!");
    }
}
