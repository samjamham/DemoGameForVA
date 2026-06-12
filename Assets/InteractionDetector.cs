using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private Iinteractable interactableInRange = null;

    [SerializeField] 
    GameObject InteractionIcon;
    
    InputAction InteractAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionIcon.SetActive(false);
        InteractAction = InputSystem.actions.FindAction("Interact");
    }
    private void Update()
    {
        if(InteractAction.WasPressedThisFrame())
        {
            interactableInRange?.interact();
        }
    }

    /*public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactableInRange?.interact();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Iinteractable interactable) && interactable.canInteract())
        {
            interactableInRange = interactable;
            InteractionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    { 
        if (other.TryGetComponent(out Iinteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            InteractionIcon.SetActive(false);
        }
    }
}
