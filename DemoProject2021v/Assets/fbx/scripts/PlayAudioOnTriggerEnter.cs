using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioSource audioSource; // Drag your AudioSource here
    public AudioClip audioClip;     // Drag the AudioClip you want to play

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
            Debug.Log("Playing collision audio!");
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned!");
        }
    }
}
