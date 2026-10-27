using System.Collections.Generic;
using UnityEngine;
using System.Linq;



class Invoker : MonoBehaviour
{
    //THIS CODE IS FROM UNITY Level up your code with design patterns and SOLID
    private static Stack<ICommand> undoStack = new Stack<ICommand>();
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }
    public static void UndoCommand()
    {
        if (undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Pop();
            activeCommand.Undo();
        }
    }
}


    // private bool isFunnyHatted;
    //   private float FunnyHatTime;


    //    public void Hat()
    //   {
    //       isFunnyHatted = true;
    //   }







   
       