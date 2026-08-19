using UnityEngine;
using UnityEngine.UI;

public class ToolbarUI : MonoBehaviour
{
    public int index {get; private set;}
    public Transform slotParent;
    public RectTransform highlightRect;

    [ContextMenu("set")]
    public void SetHighlight(int i)
    {
        index = i;
        RectTransform indexRect = slotParent.GetChild(i).GetComponent<RectTransform>();
        highlightRect.anchoredPosition = indexRect.anchoredPosition;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(slotParent.GetComponent<RectTransform>());
        SetHighlight(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
