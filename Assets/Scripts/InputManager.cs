using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputActions = new InputSystem_Actions();
    }

    public Movement PlayerCharacterMovement;
    public PlayerInteract PlayerInteract;
    public CharacterAnimationController PlayerCharacterAnimationController;
    public UIDisplayManager UIDisplayManager;
    public Inventory PlayerInventory;
    public Transform PlayerInventoryUISlotParent;
    public ToolbarUI ToolbarUI;
    public PlayerAction playerAction;

    private InputSystem_Actions inputActions;

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMovePerformed;
        inputActions.Player.Move.canceled += OnMoveCancled;
        inputActions.Player.Interact.performed += OnInteractPerformed;
        inputActions.Player.Tab.performed += OnTabPerformed;
        inputActions.Player.Esc.performed += OnEscPerformed;
        inputActions.Player.Toolbar.performed += OnToolbarPerformed;
        inputActions.Player.Attack.performed += OnAttackPerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        Vector3 dir3d = new Vector3(dir.x, dir.y, 0);
        PlayerCharacterMovement.StartMoving(dir3d);

        PlayerCharacterAnimationController.SetIdleDirection(dir);
        PlayerCharacterAnimationController.SetMoveDirection(dir);

    }


    private void OnMoveCancled(InputAction.CallbackContext ctx)
    {
        PlayerCharacterMovement.StopMoving();

        PlayerCharacterAnimationController.SetMoveDirection(Vector2.zero);
    }

    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {

        PlayerInteract.TryInteract();
    }

    private void OnTabPerformed(InputAction.CallbackContext ctx)
    {

        UIDisplayManager.ToggleTabUI();

    }

    private void OnEscPerformed(InputAction.CallbackContext ctx)
    {

        UIDisplayManager.OffAllUI();
    }

    private void OnToolbarPerformed(InputAction.CallbackContext ctx)
    {

        ToolbarUI.SetHighlight((int.Parse(ctx.control.name)+9)%10);

    }

    private void OnAttackPerformed(InputAction.CallbackContext ctx)
    {
        playerAction.UseTool();
    }

    public void SetMoveInputActive(bool active)
    {
        if(active) inputActions.Player.Move.Enable();
        else inputActions.Player.Move.Disable();

    }

    public void SetInteractInputActive(bool active)
    {
        if (active) inputActions.Player.Interact.Enable();
        else inputActions.Player.Interact.Disable();

    }

    public void SetTabInputActive(bool active)
    {
        if (active) inputActions.Player.Tab.Enable();
        else inputActions.Player.Tab.Disable();
    }

    public void SetEscInputActive(bool active)
    {
        if (active) inputActions.Player.Esc.Enable();
        else inputActions.Player.Esc.Disable();
    }
}
