using UnityEngine;
using UnityEngine.SceneManagement;

public class SeneHelper : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
