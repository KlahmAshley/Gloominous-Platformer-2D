using UnityEngine;

public interface ICommandPlus
{
    void Execute(GameObject obj);
}

public class MoveRightCommand : ICommandPlus
{
    //public KeyCode defaultKey = KeyCode.RightArrow;
    public void Execute(GameObject obj)
    {
        if (obj.TryGetComponent(out PlayerMovement p))
        {
            p.SetHorizontal(1f);
        }
    }
}

public class MoveLeftCommand : ICommandPlus
{
    //public KeyCode defaultKey = KeyCode.LeftArrow;
    public void Execute(GameObject obj)
    {
        if (obj.TryGetComponent(out PlayerMovement p))
        {
            p.SetHorizontal(-1f);
        }
    }
}
public class JumpCommand : ICommandPlus
{
    //public KeyCode defaultKey = KeyCode.Space;
    public void Execute(GameObject obj)
    {
        if (obj.TryGetComponent(out PlayerMovement p))
        {
            p.ExecuteJump();
        }
    }
}
public class NonCommand : ICommandPlus
{
    public void Execute(GameObject obj)
    {
        if (obj.TryGetComponent(out PlayerMovement p))
        {
            p.SetHorizontal(0f);
        }
    }
}
public class PauseCommand : ICommandPlus
{
    //public KeyCode defaultKey = KeyCode.Escape;
    public void Execute(GameObject obj)
    {
        if (obj.TryGetComponent(out GameManager g))
        g.PauseGame();
    }
}