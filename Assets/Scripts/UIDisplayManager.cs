using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayManager : MonoBehaviour
{
    public Inventory playerInventory;
    public InventoryUI playerInventoryUI;
    public InventoryUI chestInventoryUI;
    public InventoryUI toolbarUI;
    public CursorItemUI cursorItemUI;
    

    //public GameObject inventoryUI_Player;
    //public GameObject inventoryUI_Chest;


    public void RefreshInventoryUI()
    {
        if(toolbarUI.isActiveAndEnabled) toolbarUI.RefreshInventoryUI();
        if(playerInventoryUI.isActiveAndEnabled) playerInventoryUI.RefreshInventoryUI();
        if(chestInventoryUI.isActiveAndEnabled) chestInventoryUI.RefreshInventoryUI();
    }

    public void ToggleTabUI()
    {
        if (!playerInventoryUI.gameObject.activeSelf)
        {
            playerInventoryUI.gameObject.SetActive(true);
            playerInventoryUI.RefreshInventoryUI();
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.UIState_tab);
        }
        else
        {
            playerInventoryUI.gameObject.SetActive(false);
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.playState);
        }
    }

    public void ToggleChestUI(Inventory chest)
    {
        if (!chestInventoryUI.gameObject.activeSelf)
        {
            playerInventoryUI.gameObject.SetActive(true);
            playerInventoryUI.RefreshInventoryUI();
            chestInventoryUI.gameObject.SetActive(true);
            chestInventoryUI.SetInventoryUI(chest);
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.UIState_chest);
        }
        else
        {
            playerInventoryUI.gameObject.SetActive(false);
            chestInventoryUI.gameObject.SetActive(false);
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.playState);
        }

    }

    public void OffAllUI()
    {
        playerInventoryUI.gameObject.SetActive(false);
        chestInventoryUI.gameObject.SetActive(false);
        cursorItemUI.gameObject.SetActive(false);

        GameStateManager.Instance.ChangeState(GameStateManager.Instance.playState);
    }

    public void TurnOnPlayerInventoryUI()
    {
        //inventoryUI_Player.SetActive(true);
        playerInventoryUI.gameObject.SetActive(true);
        playerInventoryUI.slotContainer.DrawInventory(playerInventory);
    }

    public void TurnOnChestInventoryUI(Inventory chestInventory)
    {
        //inventoryUI_Chest.SetActive(true);
        //chestInventoryUI.gameObject.SetActive(true);
        //chestInventoryUI.slotContainer.DrawInventory(chestInventory);

        playerInventoryUI.gameObject.SetActive(true);
        playerInventoryUI.RefreshInventoryUI();
        chestInventoryUI.gameObject.SetActive(true);
        chestInventoryUI.SetInventoryUI(chestInventory);
    }



}
