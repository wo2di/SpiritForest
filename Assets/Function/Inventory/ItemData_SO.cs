using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/ItemData_SO")]
public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public int maxStackSize;
    public Sprite objectSprite;
    public Sprite iconSprite;

    public abstract void Use(PlayerAction player);

}

[CreateAssetMenu(fileName = "New Axe Item", menuName = "ScriptableObjects/AxeItemData")]
public class AxeData : ItemData
{
    public override void Use(PlayerAction player)
    {
        Debug.Log("use axe");
    }
}

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "ScriptableObjects/ConsumableItemData")]
public class ConsumableData : ItemData
{
    public override void Use(PlayerAction player)
    {
        Debug.Log("consume");
    }

}

[CreateAssetMenu(fileName = "New Placeable Item", menuName = "ScriptableObjects/PlaceableItemData")]
public class PlaceableData : ItemData
{

    public override void Use(PlayerAction player)
    {
        Debug.Log("place item");
    }

}
