using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{

    private ItemData itemData;
    private int count;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Add Item to Inventory", EditorStyles.boldLabel);


        itemData = EditorGUILayout.ObjectField("Item Data", itemData, typeof(ItemData), false) as ItemData;
        count = EditorGUILayout.IntField("Count", count);

        if(GUILayout.Button("Add"))
        {
            Inventory inventory = (Inventory)target;
            inventory.AddItem(new InventorySlot(inventory) { itemData = itemData, count = count });
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
