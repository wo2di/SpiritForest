using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI_Slot : MonoBehaviour, IPointerClickHandler
{

    public InventoryUI_SlotContainer inventoryUI_SlotContainer;

    public InventorySlot dataSlot;
    public Image image;
    public TMP_Text text;

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryUI_SlotContainer.OnSlotClick(this);
    }

    public void ClearSlot()
    {
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        dataSlot = null;
    }

    public Sprite GetImage()
    {
        return image.sprite;
    }

    public string GetText()
    {
        return text.text;
    }

    public void SetSlot(Sprite sprite, string text)
    {
        this.image.sprite = sprite;
        this.text.text = text;
    }

    public bool IsEmpty()
    {
        return !transform.GetChild(0).gameObject.activeSelf;
    }

    public void SetActive(bool active)
    {
        image.gameObject.SetActive(active);
        text.gameObject.SetActive(active);
    }

    public void SetDataSlot(InventorySlot slot)
    {
        dataSlot = slot;
    }

    private void Awake()
    {
        inventoryUI_SlotContainer = GetComponentInParent<InventoryUI_SlotContainer>();
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
