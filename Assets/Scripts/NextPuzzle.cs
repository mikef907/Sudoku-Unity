using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPuzzle : MonoBehaviour
{
    public Button nextPuzzleBtn;
    private GameService gameService;
    private Timer timer;

    void Start()
    {
        nextPuzzleBtn.onClick.AddListener(delegate { OnClick(); });
        gameService = FindObjectOfType<GameService>();
        timer = FindObjectOfType<Timer>();
    }

    private void OnClick()
    {
        using (var dataService = new DataService())
        {
            dataService.Create(new SudokuGame
            {
                Seed = gameService.Seed,
                Solved = true,
                Time = timer.time,
                Attempt = dataService.GetAttemptCount(gameService.Seed)
            });

            dataService.ClearCurrent();
        }

        SceneManager.LoadScene("Game");
    }
}
