using NUnit.Framework;
using System;
using System.Collections.Generic;

[Serializable]
public class InventorySlot
{
    public ItemData itemData;
    public int count;
    public int index;

    public bool IsEmpty()
    {
        return itemData == null || count <= 0;
    }

}
