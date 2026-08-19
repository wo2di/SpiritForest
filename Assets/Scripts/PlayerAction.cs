using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    public ToolbarUI toolbarUI;
    public Inventory playerInventory;

    public void UseTool()
    {
        InventorySlot slot = playerInventory.GetSlotByIndex(toolbarUI.index);
        slot?.itemData.Use(this);
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
