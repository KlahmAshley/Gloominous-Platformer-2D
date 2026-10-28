using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : Singleton<SceneChanger>
{
    public bool isReplay = false;
    public List<InputRoot> inputRecording = new List<InputRoot>();

    public void SetSceneByInt(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SetSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadReplayScene()
    {
        isReplay = !isReplay;
        InputReader inputReader = FindFirstObjectByType<InputReader>().GetComponent<InputReader>();
        inputRecording = inputReader.inputRecording;
        ReloadScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
