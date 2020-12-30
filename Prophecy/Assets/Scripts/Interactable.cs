using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; // distance how close player needs to get to interact with object

    bool isFocus = false;
    Transform player;

    public Transform interactionTransform;

    bool hasInteracted = false;

    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // meant to be overridden
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                Debug.Log("Interactable component interacted");
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmos()
    {
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
