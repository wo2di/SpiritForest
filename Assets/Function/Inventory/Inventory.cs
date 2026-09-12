using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlots;
    public int capacity;

    private void Awake()
    {
        inventorySlots = new List<InventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {   
            inventorySlots.Add(new InventorySlot(this));
        }
    }

    public List<InventorySlot> FindSlotsOfItem(ItemData itemData)
    {
        return inventorySlots.FindAll(slot => slot.itemData == itemData);
    }

    public void AddItem(InventorySlot add)
    {
        List<InventorySlot> sameSlots = FindSlotsOfItem(add.itemData);

        if(sameSlots.Count > 0)
        {
            foreach (InventorySlot slot in sameSlots)
            {
                if (slot.count + add.count <= add.itemData.maxStackSize)
                {
                    slot.count += add.count;
                    add.count = 0;
                    break;
                }
                else
                {
                    int canAdd = add.itemData.maxStackSize - slot.count;
                    slot.count += canAdd;
                    add.count -= canAdd;
                }
            }
        }

        if(add.count > 0)
        {
            List<InventorySlot> emptySlots = FindSlotsOfItem(null);

            if(emptySlots.Count > 0)
            {
                foreach (InventorySlot slot in emptySlots)
                {
                    if (add.count <= add.itemData.maxStackSize)
                    {
                        slot.itemData = add.itemData;
                        slot.count = add.count;
                        add.count = 0;
                        break;
                    }
                    else
                    {
                        slot.itemData = add.itemData;
                        slot.count = add.itemData.maxStackSize;
                        add.count -= add.itemData.maxStackSize;
                    }
                }
            }
        }

    }

    

    public InventorySlot GetSlotByIndex(int index)
    {
        return inventorySlots.Find(slot => slot.index == index);
    }


    //public void AddItem(Collectable fieldItem)
    //{
    //    int remainingCount = TryAddItem(fieldItem.itemData, fieldItem.count);
    //    if ( remainingCount == 0)
    //    {
    //        fieldItem.Collect();
    //    }
    //    else
    //    {
    //        fieldItem.count = remainingCount;
    //    }

    //}

    //public int TryAddItem(ItemData itemData, int count)
    //{
    //    int maxStackSize = itemData.maxStackSize;

    //    foreach (InventorySlot slot in inventorySlots)
    //    {
    //        if (slot.itemData.itemName == itemData.itemName)
    //        {
    //            if (slot.count + count <= maxStackSize)
    //            {
    //                slot.count += count;
    //                return 0;
    //            }
    //            else
    //            {
    //                int canadd = maxStackSize - slot.count;
    //                count -= canadd;
    //                slot.count += canadd;
    //            }
                
    //        }
    //    }

    //    if (count > 0)
    //    {
    //        if(inventorySlots.Count >= capacity)
    //        {
    //            Debug.Log("Inventory is full");
    //            return count;
    //        }
    //        else
    //        {
    //            // 여기서 maxStackSize 보다 커도 그냥 넣는 오류가 있음 그리고 다음에 같은 아이템 넣을때도 이상해짐
    //            InventorySlot newSlot = new InventorySlot();
    //            newSlot.itemData = itemData;
    //            newSlot.count = count;

    //            for (int i = 0; i < capacity; i++)
    //            {
    //                if( !inventorySlots.Any(slot => slot.index == i))
    //                {
    //                    newSlot.index = i;
    //                    break;
    //                }
    //            }

    //            inventorySlots.Add(newSlot);
    //        }
            
    //    }

    //    return 0;

    //}



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
