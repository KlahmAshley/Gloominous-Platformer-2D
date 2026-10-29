using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = gameManager.timeRemaining.ToString();
    }
}
