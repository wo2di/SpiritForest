using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameStateManager : MonoBehaviour
{

    public static GameStateManager Instance { get; private set; }
    
    public StateMachine stateMachine { get; private set;  }
    public PlayState playState;
    public UIState_Tab UIState_tab;
    public UIState_Esc UIState_esc;
    public UIState_Chest UIState_chest;
    public UIState_Dialogue UIState_dialogue;
    

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        stateMachine = new StateMachine();
        playState = new PlayState();
        UIState_tab = new UIState_Tab();
        UIState_esc = new UIState_Esc();
        UIState_chest = new UIState_Chest();
        UIState_dialogue = new UIState_Dialogue();
    }

    private void Start()
    {
        ChangeState(playState);
    }

    private void Update()
    {
        stateMachine.Update();
        
    }

    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }

}


public class PlayState : IState
{
    public void Enter() 
    {
        InputManager.Instance.SetMoveInputActive(true);
        InputManager.Instance.SetInteractInputActive(true);
        InputManager.Instance.SetTabInputActive(true);
        InputManager.Instance.SetEscInputActive(true);
    }
    public void Update() { }
    public void Exit() { }
}

public class UIState_Tab : IState
{

    public void Enter()
    {
        InputManager.Instance.SetMoveInputActive(false);
        InputManager.Instance.SetInteractInputActive(false);
        InputManager.Instance.SetTabInputActive(true);
        InputManager.Instance.SetEscInputActive(true);
    }
    public void Update() { }
    public void Exit() { }

}

public class UIState_Esc : IState
{

    public void Enter() 
    {
        InputManager.Instance.SetMoveInputActive(false);
        InputManager.Instance.SetInteractInputActive(false);
        InputManager.Instance.SetTabInputActive(false);
        InputManager.Instance.SetEscInputActive(true);
    }
    public void Update() { }
    public void Exit() { }
}


public class UIState_Chest : IState
{

    public void Enter() 
    {
        InputManager.Instance.SetMoveInputActive(false);
        InputManager.Instance.SetInteractInputActive(true);
        InputManager.Instance.SetTabInputActive(false);
        InputManager.Instance.SetEscInputActive(true);
    }
    public void Update() { }
    public void Exit() { }

}

public class UIState_Dialogue : IState
{

    public void Enter()
    {
        InputManager.Instance.SetMoveInputActive(false);
        InputManager.Instance.SetInteractInputActive(true);
        InputManager.Instance.SetTabInputActive(false);
        InputManager.Instance.SetEscInputActive(false);
    }
    public void Update() { }
    public void Exit() { }

}