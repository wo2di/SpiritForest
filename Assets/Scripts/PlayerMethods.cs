using UnityEngine;

public class PlayerMethods : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindObjectNearby(LayerMask layer)
    {
        GameObject objectFound = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, layer);
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {

            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                objectFound = collider.gameObject;
            }
        }

        return objectFound;
    }
}
