using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public Inventory playerInventory;
    public LayerMask collectableLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindCollectableObjectNearby();
    }

    public void FindCollectableObjectNearby()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, collectableLayer);
        foreach (Collider2D collider in colliders)
        {
            collider.TryGetComponent<FieldItem>(out FieldItem fieldItem);
            if (fieldItem != null)
            {
                playerInventory.AddItem(fieldItem);
            }
        }
    }
}
