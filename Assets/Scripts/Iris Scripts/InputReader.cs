using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InputReader : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputRoot inputData { get; set; }
    public List<InputRoot> inputRecording = new List<InputRoot>();
    bool isRecording;
    bool isPlayback;
    int frameCount = 0;

    void Awake()
    {
        walkAction = inputActions.FindAction("PlayerAction/Walk");
        jumpAction = inputActions.FindAction("PlayerAction/Jump");
        SceneChanger sceneChanger = Object.FindFirstObjectByType<SceneChanger>().GetComponent<SceneChanger>();
        if (sceneChanger.isReplay)
        {
            isRecording = false;
            isPlayback = true;
            inputRecording = sceneChanger.inputRecording;
        }
        else
        {
            isRecording = true;
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
        }
        frameCount++;
    }
}