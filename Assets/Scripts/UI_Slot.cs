using UnityEngine;
using UnityEngine.UI;

public class UI_Slot : MonoBehaviour
{
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
