using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    public string levelSceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
