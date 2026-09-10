using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI_SlotContainer : MonoBehaviour
{

    public CursorItemUI cursorItemUI;
    public InventoryController inventoryController;

    public InventoryUI inventoryUI;

    public EventSO eventInventoryChanged;

    public void DrawInventory(Inventory inventory)
    {
        ClearInventoryDraw();
        foreach(InventorySlot slot in inventory.inventorySlots)
        {
            if(!slot.IsEmpty())
            {
                InventoryUI_Slot inventoryUI_Slot = transform.GetChild(slot.index).GetComponent<InventoryUI_Slot>();
                inventoryUI_Slot.SetActive(true);
                inventoryUI_Slot.SetSlot(slot.itemData.iconSprite, slot.count.ToString());
                inventoryUI_Slot.SetDataSlot(slot);
            }
            
        }

    }

    public void ClearInventoryDraw()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<InventoryUI_Slot>().ClearSlot();
        }
    }

    public void SetCursorItemUI(InventoryUI_Slot slot)
    {
        cursorItemUI.gameObject.SetActive(true);
        cursorItemUI.SetImage(slot.GetImage());
        cursorItemUI.SetText(slot.GetText());
    }

    public void OnSlotClick(InventoryUI_Slot slot)
    {
        //click on item wihtout cursor -> pick up
        if (!slot.IsEmpty() && !cursorItemUI.IsActive())
        {
            SetCursorItemUI(slot);
            slot.SetActive(false);
            
            inventoryController.slotOnCursor = slot.dataSlot;
            inventoryController.inventoryCursorIsFrom = inventoryUI.displayingInventory;
        }

        // click on empty slot with cursor -> drop
        else if (slot.IsEmpty() && cursorItemUI.IsActive())
        {
            slot.SetActive(true);
            slot.SetSlot(cursorItemUI.GetImage(), cursorItemUI.GetText());
            cursorItemUI.SetActive(false);
            //Debug.Log(slot.transform.GetSiblingIndex());

            inventoryController.MoveCurrentCursorTo(inventoryUI.displayingInventory, slot.transform.GetSiblingIndex());
            eventInventoryChanged.Raise();
        }
    }
}
