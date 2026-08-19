using System.Threading;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public ItemData itemData;
    public int count;

    //public InventorySlot ToSlot => new InventorySlot { itemData = itemData, count = count };

    public void Collect()
    {
        Destroy(gameObject);
        //return ToSlot;
    }

    
}
