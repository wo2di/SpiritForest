using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public InventoryUI_SlotContainer slotContainer;
    public Inventory displayingInventory;

    public void SetInventoryUI(Inventory inventory)
    {
        displayingInventory = inventory;
        slotContainer.DrawInventory(displayingInventory);
    }

    public void RefreshInventoryUI()
    {
        slotContainer.DrawInventory(displayingInventory);
    }


    private void Start()
    {
        if (gameObject.activeSelf&& displayingInventory != null) { RefreshInventoryUI(); }
    }
}
