using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance { get; private set; }


    public DialogueData_SO currentDialogue;
    public int currentIndex;
    public DialogueUI dialogueUI;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void StartDialogue(DialogueData_SO dialogue)
    {
        currentDialogue = dialogue;
        currentIndex = 0;
        
        //dialogue UI
        dialogueUI.gameObject.SetActive(true);
        ShowCurrentLine();

        //game state
        GameStateManager.Instance.ChangeState(GameStateManager.Instance.UIState_dialogue);

    }

    public void ShowCurrentLine()
    {
        dialogueUI.SetDialgueUI(currentDialogue.lines[currentIndex]);
    }

    public void Next()
    {
        currentIndex++;
        if(currentIndex >= currentDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    public void EndDialogue()
    {
        currentDialogue = null;
        currentIndex = 0;

        dialogueUI.gameObject.SetActive(false);

        GameStateManager.Instance.ChangeState(GameStateManager.Instance.playState);
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
