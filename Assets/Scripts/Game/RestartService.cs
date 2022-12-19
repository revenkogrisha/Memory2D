using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartService : MonoBehaviour
{
    public void Restart()
    {
        var activeScene = SceneManager.GetActiveScene();
        var index = activeScene.buildIndex;
        SceneManager.LoadScene(index);
    }
}