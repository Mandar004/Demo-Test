using UnityEngine;

public class DragObjectUniversal : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;

    void Update()
    {
        // For touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(touchPos);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform == transform)
                        {
                            StartDragging(touchPos);
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Dragging(touchPos);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }
        // For mouse
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    StartDragging(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Dragging(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void StartDragging(Vector3 screenPos)
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetWorldPosition(screenPos);
        isDragging = true;
    }

    void Dragging(Vector3 screenPos)
    {
        transform.position = GetWorldPosition(screenPos) + offset;
    }

    Vector3 GetWorldPosition(Vector3 screenPos)
    {
        screenPos.z = zCoord;
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}
