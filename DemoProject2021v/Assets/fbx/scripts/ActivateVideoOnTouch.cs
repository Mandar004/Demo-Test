using UnityEngine;
using UnityEngine.Video;

public class ActivateVideoOnTouch : MonoBehaviour
{
    public GameObject videoPlayerObject; // Drag your VideoPlayer GameObject here

    private bool hasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Draggable"))
        {
            hasActivated = true;

            if (videoPlayerObject != null)
            {
                videoPlayerObject.SetActive(true); // Enable the VideoPlayer GameObject

                VideoPlayer vp = videoPlayerObject.GetComponent<VideoPlayer>();
                if (vp != null)
                {
                    vp.Play(); // Play the video
                }
                else
                {
                    Debug.LogWarning("No VideoPlayer component found on the assigned object!");
                }
            }
            else
            {
                Debug.LogWarning("VideoPlayer GameObject not assigned.");
            }
        }
    }
}
