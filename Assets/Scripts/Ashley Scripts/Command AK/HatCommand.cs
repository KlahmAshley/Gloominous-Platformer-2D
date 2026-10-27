using UnityEngine;

public class HatCommand : ICommand
{//hat command is like move command 
    ////THIS CODE IS FROM UNITY Level up your code with design patterns and SOLID
    private ToggleFunnyHat toggleFunnyHat;
    private bool IsHatOn;
  
   public HatCommand(ToggleFunnyHat funnyHat)
    {
        this.toggleFunnyHat = funnyHat;  
    }

    public void Execute()
    {
        toggleFunnyHat.Toggle(IsHatOn);
    }

    public void Undo()
    {
        toggleFunnyHat.Toggle(!IsHatOn);
    }



}
