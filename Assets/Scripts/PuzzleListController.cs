using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleListController : MonoBehaviour
{
    private ListItem selected;
    private readonly Color32 BASE = new Color32(45, 52, 54, 0);
    private readonly Color32 SELECTED = new Color32(99, 110, 114, 100);

    public void MainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShareClick()
    {
        if (selected != null)
        {
            new NativeShare()
                .SetText($"Check out this Sudoku puzzle! https://playsudoku.app/seed/{selected.Seed.text}")
                .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                .Share();
        }
    }

    public void SetSelected(ListItem listItem)
    {
        if (selected != null)
            selected.GetComponent<Image>().color = BASE;

        selected = listItem;
        selected.GetComponent<Image>().color = SELECTED;
    }
}
