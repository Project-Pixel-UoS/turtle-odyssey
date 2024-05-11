using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Button : MonoBehaviour
{
    public string levelSceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
