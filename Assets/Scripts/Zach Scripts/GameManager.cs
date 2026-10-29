using UnityEngine;
using DLLTimer;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver = false; //dead
    public bool isGamePaused = false; //game paused state
    public bool MainMenu = true; //disable controls when in main menu
    Timer timer = new Timer();
    public float timeRemaining;

    void Start()
    {
        timer.TimesUp += TimerRanOut;
        timer.StartTimer(30);
    }

    void OnLevelWasLoaded()
    {
        timer.StartTimer(30);
    }

    void TimerRanOut()
    {
        FindFirstObjectByType<PlayerMovement>().GetComponent<PlayerMovement>().Die();
    }

    void Update()
    {
        timeRemaining = timer.ReduceTimer(Time.deltaTime);
    }

    public void OrbCollected()
    {
        timer.RaiseTimer(10.0f);
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
