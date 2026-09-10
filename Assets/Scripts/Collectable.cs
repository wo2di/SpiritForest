using System.Threading;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public InventorySlot slot;

    public void Collect()
    {
        Destroy(gameObject);

    }



    
}
