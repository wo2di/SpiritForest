using System;
using UnityEngine;

public enum ToolType
{
    Axe,
    Pickaxe
}

public class ResourceNode : MonoBehaviour
{
    public ToolType requiredTool;
    public int health;
    public void takeDamage(int power)
    {
        health -= power;
        if (health <= 0)
        {
            Destroy(gameObject);
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
