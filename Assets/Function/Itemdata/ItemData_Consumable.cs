using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "ScriptableObjects/ItemData_Consumable")]
public class ItemData_Consumable : ItemData
{
    public override void Use(PlayerAction player)
    {
        Debug.Log("consume");
    }

}