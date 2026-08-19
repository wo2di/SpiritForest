using UnityEngine;

public class Skull : MonoBehaviour, IInteractable, IInteractButton
{
    [SerializeField] private GameObject interactButton;

    public DialogueData_SO dialogueData;

    public void Interact()
    {
        switch(GameStateManager.Instance.stateMachine.currentState)
        {
            case PlayState:
                DialogueManager.instance.StartDialogue(dialogueData);
                break;

            case UIState_Dialogue:
                DialogueManager.instance.Next();
                break; 
        }

    }

    public void SetInteractButtonActive(bool active)
    {
        // Implement logic to show or hide the interact button UI element
        interactButton.SetActive(active);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
