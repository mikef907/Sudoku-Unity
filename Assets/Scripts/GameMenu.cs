using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void Awake()
    {
        using (var dataService = new DataService())
        {
            dataService.CreateTable<SudokuGame>();
            dataService.CreateTable<CurrentGame>();
        }
    }

    public void NewGame()
    {
        using (var dataService = new DataService())
        {
            var current = dataService.ReadCurrentGame();
            
            if(current != null)
            {
                dataService.Create(new SudokuGame
                {
                    Seed = current.Seed,
                    Solved = false,
                    Time = current.Timer,
                    Attempt = dataService.GetAttemptCount(current.Seed) + 1
                });

                dataService.ClearCurrent();
            }
        }

        SceneManager.LoadScene("Game");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayedPuzzles()
    {
        SceneManager.LoadScene("PuzzleList");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }
}
