using TMPro;
using DLLTimer;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    TextMeshProUGUI achieveText;
    string bufferedText = "";
    Timer timer = new Timer();

    private void Start()
    {
        timer.TimesUp += TextVanish;
        OrbCollision.LevelOver += CheckTimerChallenge;
    }

    void OnLevelWasLoaded()
    {
        RenderAchievements();
    }

    void CheckTimerChallenge()
    {
        float timeLeft = Object.FindFirstObjectByType<GameManager>().timeRemaining;
        if (timeLeft >= 90)
        {
            AddBufferedAchievement("Gold Medalist");
        }
        if (timeLeft >= 80)
        {
            AddBufferedAchievement("Silver Medalist");
        }
        if (timeLeft >= 70)
        {
            AddBufferedAchievement("Bronze Medalist");
        }
    }

    void AddBufferedAchievement(string achieveName)
    {
        bufferedText = bufferedText + "\n" + achieveName;
    }

    void RenderAchievements()
    {
        achieveText = GameObject.Find("Achievements").GetComponent<TextMeshProUGUI>();
        achieveText.text = bufferedText;
        bufferedText = "";
        timer.StartTimer(5.0f);
    }

    void TextVanish()
    {
        achieveText.text = "";
    }

    void Update()
    {
        if (timer.timeLeft > 0)
        {
            timer.ReduceTimer(Time.deltaTime);
        }
    }
}
