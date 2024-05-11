using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour
{
    public string levelSceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelSceneName);
    }
}
