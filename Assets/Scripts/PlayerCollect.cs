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
            collider.TryGetComponent<Collectable>(out Collectable collectable);
            if (collectable != null)
            {
                playerInventory.AddItem(collectable.slot);
                if(collectable.slot.IsEmpty())
                {
                    collectable.Collect();
                }
            }
        }
    }
}
