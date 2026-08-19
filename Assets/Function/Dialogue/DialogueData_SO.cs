using UnityEngine;

[CreateAssetMenu(fileName ="new dialogue", menuName ="ScriptableObjects/DialogueData")]
public class DialogueData_SO : ScriptableObject
{

    public DialogueLine[] lines;

}

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea]
    public string content;
}