using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public TMP_Text speakerTmp;
    public TMP_Text contentTmp;


    public void SetDialgueUI(DialogueLine line)
    {
        speakerTmp.text = line.speaker;
        contentTmp.text = line.content;
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
