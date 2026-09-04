using UnityEngine;


[CreateAssetMenu(fileName = "New Tool Item", menuName = "ScriptableObjects/ItemData_Tool")]
public class ItemData_Tool : ItemData
{

    public int power;
    public ToolType toolType;

    public override void Use(PlayerAction player)
    {
        player.HarvestResourceNode(this);
    }
}