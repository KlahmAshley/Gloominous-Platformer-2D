using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Singleton<SceneChanger>
{
    int currentScene = 0;

    public void setScene(int scene)
    {
        currentScene = scene;
        SceneManager.LoadScene(scene);
    }
}
