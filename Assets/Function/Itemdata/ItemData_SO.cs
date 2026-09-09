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





