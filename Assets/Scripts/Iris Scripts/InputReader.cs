using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputRoot inputData { get; set; }
    //public List<InputAction> inputRecording { get; }

    void Awake()
    {
        walkAction = inputActions.FindAction("PlayerAction/Walk");
        jumpAction = inputActions.FindAction("PlayerAction/Jump");
    }

    void BeginRecording()
    {
        
    }

    void OnEnable()
    {
        inputActions.FindAction("PlayerAction/Walk").Enable();
        inputActions.FindAction("PlayerAction/Jump").Enable();
    }

    void OnDisable()
    {
        walkAction.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {
        inputData = new InputRoot
        {
            walkInput = walkAction.ReadValue<float>(),
            jumpPressed = jumpAction.WasPressedThisFrame()
        };
    }
}