using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    public void MainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LinkClick()
    {
        Application.OpenURL("https://beaubastic.com");
    }
}
