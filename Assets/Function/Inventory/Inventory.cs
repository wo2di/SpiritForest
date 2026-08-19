using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlots;
    public int capacity;

    private void Awake()
    {
        inventorySlots = new List<InventorySlot>(capacity);
    }

    public InventorySlot GetSlotByIndex(int index)
    {
        return inventorySlots.Find(slot => slot.index == index);
    }


    public void AddItem(FieldItem fieldItem)
    {
        int remainingCount = TryAddItem(fieldItem.itemData, fieldItem.count);
        if ( remainingCount == 0)
        {
            fieldItem.Collect();
        }
        else
        {
            fieldItem.count = remainingCount;
        }

    }

    public int TryAddItem(ItemData itemData, int count)
    {
        int maxStackSize = itemData.maxStackSize;

        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.itemData.itemName == itemData.itemName)
            {
                if (slot.count + count <= maxStackSize)
                {
                    slot.count += count;
                    return 0;
                }
                else
                {
                    int canadd = maxStackSize - slot.count;
                    count -= canadd;
                    slot.count += canadd;
                }
                
            }
        }

        if (count > 0)
        {
            if(inventorySlots.Count >= capacity)
            {
                Debug.Log("Inventory is full");
                return count;
            }
            else
            {
                // 여기서 maxStackSize 보다 커도 그냥 넣는 오류가 있음 그리고 다음에 같은 아이템 넣을때도 이상해짐
                InventorySlot newSlot = new InventorySlot();
                newSlot.itemData = itemData;
                newSlot.count = count;

                for (int i = 0; i < capacity; i++)
                {
                    if( !inventorySlots.Any(slot => slot.index == i))
                    {
                        newSlot.index = i;
                        break;
                    }
                }

                inventorySlots.Add(newSlot);
            }
            
        }

        return 0;

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
