using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InputReader : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] GameObject player;
    [SerializeField] GameManager gameManager;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputRoot inputData { get; set; }
    public List<InputRoot> inputRecording = new List<InputRoot>();
    bool isPlayback;
    int frameCount = 0;

    private ICommandPlus jumpCommand = new JumpCommand();
    private ICommandPlus leftCommand = new MoveLeftCommand();
    private ICommandPlus rightCommand = new MoveRightCommand();
    private ICommandPlus nonCommand = new NonCommand();

    //private Dictionary<KeyCode, ICommandPlus> keyBindings = new Dictionary<KeyCode, ICommandPlus>();
    //private ICommand pauseCommand = new PauseCommand(gameManager);

    //private const string RebindsKey = "CommandInputRebinds";
    ////the depths I scoured to find this 
    //private InputActionRebindingExtensions.RebindingOperation rebind;


    void Awake()
    {
        walkAction = inputActions.FindAction("PlayerAction/Walk");
        jumpAction = inputActions.FindAction("PlayerAction/Jump");
        SceneChanger sceneChanger = Object.FindFirstObjectByType<SceneChanger>().GetComponent<SceneChanger>();
        if (sceneChanger.isReplay)
        {
            isPlayback = true;
            inputRecording = sceneChanger.inputRecording;
        }
        else
        {
            isPlayback = false;
        }
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

        if (isPlayback)
        {
            if (jumpAction.WasPressedThisFrame())
            {
                Object.FindFirstObjectByType<SceneChanger>().GetComponent<SceneChanger>().LoadReplayScene();
            }
            if (frameCount < inputRecording.Count)
            {
                inputData = inputRecording[frameCount];

                ProcessData(inputData);
            }
        }
        else
        {
            inputData = new InputRoot
            {
                walkInput = walkAction.ReadValue<float>(),
                jumpPressed = jumpAction.WasPressedThisFrame()
            };
            inputRecording.Add(inputData);
            Debug.Log(inputData.walkInput);
            ProcessData(inputData);
        }
        frameCount++;
    }

    private void ProcessData(InputRoot data)
    {
        //Debug.Log("it's doing something");
        if (data.walkInput > 0.1f)
        {
            Debug.Log("it's doing Right");
            rightCommand.Execute(player);
        }
        else if (data.walkInput < -0.1f)
        {
            Debug.Log("it's doing Left");
            leftCommand.Execute(player);
        }
        else if (data.walkInput == 0)
        {
            Debug.Log("it's doing Nothing");
            nonCommand.Execute(player);
        }

        if (data.jumpPressed)
        {
            jumpCommand.Execute(player);
        }
    }
}