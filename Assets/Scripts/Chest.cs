using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour, IInteractable, IInteractButton
{
    public UIDisplayManager uiDisplayManager;
    public Inventory chestInventory;
    [SerializeField] private GameObject interactButton;

    [SerializeField] private List<InventorySlot> itemsInChest;
    public void Interact()
    {
        uiDisplayManager.ToggleChestUI(chestInventory);
    }

    public void SetInteractButtonActive(bool active)
    {
        interactButton.SetActive(active);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (InventorySlot slot in itemsInChest)
        {
            chestInventory.AddItem(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
