using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPuzzle : MonoBehaviour
{
    public Button nextPuzzleBtn;
    void Start()
    {
        nextPuzzleBtn.onClick.AddListener(delegate { OnClick(); });
    }

    private void OnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
