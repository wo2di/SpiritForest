using UnityEngine;
using UnityEngine.Rendering.Universal;



public class WorldLightTransition : MonoBehaviour
{
    public Light2D light2d;
    public LightValue_SO lightValue;

    public void ChangeLight()
    {
        light2d.color = lightValue.color;
        light2d.intensity = lightValue.intensity;
    }

    private void Awake()
    {
        light2d = GetComponent<Light2D>();
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
