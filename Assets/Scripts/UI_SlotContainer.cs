using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UI_SlotContainer : MonoBehaviour
{

    public List<ItemData> data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplaySlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplaySlots()
    {
        for(int i = 0; i < data.Capacity; i++)
        {
            Sprite sprite = data[i].iconSprite;
            transform.GetChild(i).GetComponent<UI_Slot>().SetImage(sprite);
        }

        //foreach (Transform child in transform)
        //{
        //    Sprite sprite = data[child.transform.GetSiblingIndex()].iconSprite;
        //    child.GetComponent<UI_Slot>().SetImage(sprite);
        //}
    }

}
