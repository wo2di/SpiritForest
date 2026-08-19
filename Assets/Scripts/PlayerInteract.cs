using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private IInteractable currentInteractable;
    [SerializeField] GameObject currentInteractableObject;
    [SerializeField] GameObject previousInteractableObject;

    private void Awake()
    {
        currentInteractableObject = null;
        previousInteractableObject = null;
    }

    private void Update()
    {
        FindInteractableObjectNearby();
        UpdateInteractButton();

    }


    public void TryInteract()
    {
        //FindInteractableObjectNearby();
        currentInteractable?.Interact();
    }

    

    public void FindInteractableObjectNearby()
    {
        previousInteractableObject = currentInteractableObject;
        currentInteractableObject = null;
        currentInteractable = null;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, interactableLayer);
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {

            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currentInteractable = interactable;
                    currentInteractableObject = collider.gameObject;
                }
            }
        }

    }

    public void UpdateInteractButton()
    {

        if(currentInteractableObject != previousInteractableObject)
        {
            if(previousInteractableObject != null)
            {
                if (previousInteractableObject.TryGetComponent<IInteractButton>(out IInteractButton previousInteractButton))
                {
                    previousInteractButton.SetInteractButtonActive(false);
                }
            }

            if (currentInteractableObject != null)
            {
                if (currentInteractableObject.TryGetComponent<IInteractButton>(out IInteractButton currentInteractButton))
                {
                    currentInteractButton.SetInteractButtonActive(true);
                }
            }
        }
        
    }

    
}
