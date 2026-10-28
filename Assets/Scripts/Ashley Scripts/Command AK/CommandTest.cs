using UnityEngine;

public class CommandTest : MonoBehaviour
{//THIS CODE IS FROM UNITY Level up your code with design patterns and SOLID
    public ToggleFunnyHat toggleFunnyHat;

    void Update()
    {
        if(Input.GetKey(KeyCode.L))
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
