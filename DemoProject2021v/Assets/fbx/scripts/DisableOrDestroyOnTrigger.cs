using UnityEngine;

public class DisableOrDestroyOnTrigger : MonoBehaviour
{
    public bool destroyInsteadOfDisable = false; // Choose if you want to destroy or disable

    private void OnTriggerEnter(Collider other)
    {
        if (destroyInsteadOfDisable)
        {
            Destroy(gameObject, 3f); // Destroys permanently
            Debug.Log("Scissors destroyed!");
        }
        else
        {
            gameObject.SetActive(false); // Just disables (hides)
            Debug.Log("Scissors disabled!");
        }
    }
}
