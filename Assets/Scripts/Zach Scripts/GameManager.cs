using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver = false; //dead
    public bool isGamePaused = false; //game paused state
    public bool MainMenu = true; //disable controls when in main menu


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isGamePaused = false;
            Time.timeScale = 1;
        }
    }

}
