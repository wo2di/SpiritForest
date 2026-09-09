using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UI_SlotContainer : MonoBehaviour
{

    public List<ItemData> data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplaySlots()
    {
        foreach (Transform child in transform)
        {
            
            child.GetComponent<UI_Slot>().SetImage(null);
        }
    }

}
