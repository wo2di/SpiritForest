using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable Item", menuName = "ScriptableObjects/ItemData_Placeable")]
public class ItemData_Placeable : ItemData
{

    public override void Use(PlayerAction player)
    {
        Debug.Log("place item");
    }

}