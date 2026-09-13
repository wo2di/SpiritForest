using NUnit.Framework;
using System;
using System.Collections.Generic;

[Serializable]
public class InventorySlot
{
    public Inventory inventory;
    public ItemData itemData;
    public int count;
    public int index;

    public InventorySlot(Inventory inventory)
    {
        this.inventory = inventory;
        itemData = null;
        count = 0;
    }

    public bool IsEmpty()
    {
        return itemData == null || count <= 0;
    }

    public void ChangeInventory(Inventory newInventory)
    {
        inventory = newInventory;
    }

}
