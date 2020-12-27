using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    public Button shareBtn;
    public GameService gameService;
    void Start()
    {
        shareBtn.onClick.AddListener(delegate { OnClick(); });
        gameService = FindObjectOfType<GameService>();
    }

    private void OnClick()
    {
        new NativeShare()
        .SetText($"Check out this Sudoku puzzle! https://playsudoku.app/seed/{gameService.Seed}")
        .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
        .Share();
    }
}
