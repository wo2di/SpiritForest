using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public GameStateManager gameStateManager;

    private void OnGUI()
    {
        GUI.Label(
            new Rect(10, 10, 300, 30),
            "State: " + gameStateManager.stateMachine.currentState);
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
