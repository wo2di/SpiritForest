using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    public ToolbarUI toolbarUI;
    public Inventory playerInventory;

    public PlayerMethods playerMethods;

    public void UseTool()
    {
        InventorySlot slot = playerInventory.GetSlotByIndex(toolbarUI.index);
        slot?.itemData.Use(this);
    }

    public void HarvestResourceNode(ItemData_Tool itemData)
    {
        GameObject resourceObject = playerMethods.FindObjectNearby(LayerMask.GetMask("ResourceNode"));
        if (resourceObject != null)
        {
            ResourceNode resourceNode = resourceObject.GetComponent<ResourceNode>();
            if(resourceNode.requiredTool == itemData.toolType)
            {
                resourceNode.takeDamage(itemData.power);
            }
        }
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
