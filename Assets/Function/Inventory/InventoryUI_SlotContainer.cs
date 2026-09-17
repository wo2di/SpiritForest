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
        // pick up
        if (!cursorItemUI.IsActive())
        {
            slot.SetActive(false);
            cursorItemUI.SetSlotData(slot.dataSlot);
        }

        // drop
        else
        {
            int oldIndex = cursorItemUI.slotData.inventory.inventorySlots.IndexOf(cursorItemUI.slotData);
            int newIndex = slot.transform.GetSiblingIndex();

            Inventory oldInventory = cursorItemUI.slotData.inventory;
            Inventory newInventory = slot.dataSlot.inventory;

            //InventorySlot temp = slot.dataSlot;

            Debug.Log($"Moving item from {oldInventory.name} index {oldIndex} to {newInventory.name} index {newIndex}");

            oldInventory.inventorySlots[oldIndex] = newInventory.inventorySlots[newIndex];
            newInventory.inventorySlots[newIndex] = cursorItemUI.slotData;

            oldInventory.inventorySlots[oldIndex].ChangeInventory(oldInventory);
            newInventory.inventorySlots[newIndex].ChangeInventory(newInventory);

            cursorItemUI.SetActive(false);

            //cursorItemUI.slotData.ChangeInventory(newInventory);
            //cursorItemUI.SetSlotData(temp);
            
            eventInventoryChanged.Raise();
        }
    }
}
