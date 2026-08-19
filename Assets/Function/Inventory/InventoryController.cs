using JetBrains.Annotations;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public InventorySlot slotOnCursor;
    public Inventory inventoryCursorIsFrom;
    //public Inventory inventoryCursorGoTo;
    //public Inventory playerInventory;

    public void MoveCurrentCursorTo(Inventory to, int toIndex)
    {
        if(inventoryCursorIsFrom == to)
        {
            slotOnCursor.index = toIndex;
        }
        else
        {
            slotOnCursor.index = toIndex;
            to.inventorySlots.Add(slotOnCursor);
            inventoryCursorIsFrom.inventorySlots.Remove(slotOnCursor);
        }
    }

}
