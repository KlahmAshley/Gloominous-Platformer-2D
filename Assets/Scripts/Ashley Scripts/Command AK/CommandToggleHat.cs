using UnityEngine;

public class CommandToggleHat : MonoBehaviour
{
    public ToggleFunnyHat toggleFunnyHat;

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            ICommand command = new HatCommand(toggleFunnyHat);
            Invoker.ExecuteCommand(command); //making the hat show uppp

        }

        if (Input.GetKey(KeyCode.H))
        {
            Invoker.UndoCommand();
        }
    }

}
