using UnityEngine;
using UnityEngine.InputSystem;

public class Rebinding : MonoBehaviour
{
    //I asked AI for help on this one cuz I couldn't find any useful videos and it kept talking about InputActionRebindingExtensions,
    //this took brunt of my will to do, but I read the entire page on InputActionRebindingExtensions and can only pray this works right.
    [SerializeField] InputActionAsset inputActions;

    InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void LeftRebind()
    {
        Rebind("PlayerAction/Walk", GetWalkIndex("PlayerAction/Walk", "negative"));
    }

    public void RightRebind()
    {
        Rebind("PlayerAction/Walk", GetWalkIndex("PlayerAction/Walk", "positive"));
    }

    public void JumpRebind()
    {
        Rebind("PlayerAction/Walk", GetJumpIndex("PlayerAction/Jump"));
    }

    void Rebind(string actionName, int bindIndex)
    {
        if (rebindingOperation != null || bindIndex < 0)
        {
            return;
        }

        InputAction action = inputActions.FindAction(actionName);
        action.Disable();

        rebindingOperation = action.PerformInteractiveRebinding(bindIndex).WithCancelingThrough("<Keyboard>/backspace").OnComplete(operation =>
        {
            //cleanup
            action.Enable();
            operation.Dispose();
            rebindingOperation = null;
        }).OnCancel(operation =>
        {
            action.Enable();
            operation.Dispose();
            rebindingOperation = null;
        });
        rebindingOperation.Start();
    }

    //getting the key indexes for the Rebind method 
    int GetJumpIndex(string actionName)
    {
        InputAction action = inputActions.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            if (!action.bindings[i].isComposite)
            {
                return i;
            }
        }
        return -1;
    }
    int GetWalkIndex(string actionName, string direction)
    {
        InputAction action = inputActions.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            InputBinding binding = action.bindings[i];

            if (binding.isPartOfComposite && binding.name == direction)
            {
                return i;
            }
        }

        return -1;
    }
}
