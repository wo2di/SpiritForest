using UnityEngine;

[CreateAssetMenu(fileName = "LightValue", menuName = "ScriptableObjects/LightValue_SO", order = 1)]
public class LightValue_SO : ScriptableObject
{
    public Color color;
    public float intensity;

}
