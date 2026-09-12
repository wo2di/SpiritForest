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

        if (transform.childCount < inventory.inventorySlots.Count)
        {
            Debug.Log("Not enough slots in the UI to display the inventory");
        }

        for(int i = 0; i< Mathf.Min(inventory.inventorySlots.Count, transform.childCount); i ++)
        {
            InventorySlot slot = inventory.inventorySlots[i];
            //if( !slot.IsEmpty() )
            //{ 
                InventoryUI_Slot UI_Slot = transform.GetChild(i).GetComponent<InventoryUI_Slot>();
                //UI_Slot.SetActive(true);
                UI_Slot.SetSlotData(slot);
            //}
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
            cursorItemUI.SetSlotData(slot.dataSlot);
            //inventoryController.inventoryCursorIsFrom = inventoryUI.displayingInventory;
        }

        // click on empty slot with cursor -> drop
        else if (slot.IsEmpty() && cursorItemUI.IsActive())
        {

            int newIndex = slot.transform.GetSiblingIndex();
            slot.dataSlot.inventory.inventorySlots[newIndex] = cursorItemUI.slotData;

            int oldIndex = cursorItemUI.slotData.inventory.inventorySlots.IndexOf(cursorItemUI.slotData);
            cursorItemUI.slotData.inventory.inventorySlots[oldIndex] = new InventorySlot(cursorItemUI.slotData.inventory);

            slot.SetActive(true);
            slot.SetSlotData(cursorItemUI.slotData);
            //slot.SetSlot(cursorItemUI.GetImage(), cursorItemUI.GetText());
            cursorItemUI.SetActive(false);
            //Debug.Log(slot.transform.GetSiblingIndex());


            //inventoryController.MoveCurrentCursorTo(inventoryUI.displayingInventory, slot.transform.GetSiblingIndex());
            eventInventoryChanged.Raise();
        }
    }
}
