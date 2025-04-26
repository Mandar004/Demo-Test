using System.Collections;
using UnityEngine;

public class PlayAnimationOnTriggerEnter : MonoBehaviour
{
    public Animator animator;          // Drag your Animator here
    public string animationTriggerName; // The Trigger name in Animator
    public AudioSource audioSource; // Drag your AudioSource here
    public AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Triggered Animation: ");
        if (other.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
                Debug.Log("Triggered Animation: " + animationTriggerName);
                StartCoroutine(AddDelay());

            }
            else
            {
                Debug.LogWarning("Animator is not assigned!");
            }
        }
    }

    public IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(audioClip);
    }
}
