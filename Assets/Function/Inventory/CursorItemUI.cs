using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CursorItemUI : MonoBehaviour
{
    public RectTransform cursorItem;
    public Canvas canvas;
    public Image image;
    public TMP_Text text;

    public InventorySlot slotData;
    public void SetSlotData(InventorySlot slot)
    {
        slotData = slot;
        SetImage(slot?.itemData.iconSprite);
        SetText(slot?.count.ToString());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Mouse.current.position.ReadValue(),
            canvas.worldCamera,
            out Vector2 localPoint );

        cursorItem.localPosition = localPoint;
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public Sprite GetImage()
    {
        return image.sprite;
    }

    public string GetText()
    {
        return text.text;
    }

    public void SetImage(Sprite sprite)
    {
        cursorItem.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }

    public void SetText(string text)
    {
        cursorItem.GetChild(1).GetComponent<TMPro.TMP_Text>().text = text;
    }

    public void SetActive(bool active)
    {
        if(!active)
        {
            SetSlotData(null);
        }
        gameObject.SetActive(active);
    }
}
