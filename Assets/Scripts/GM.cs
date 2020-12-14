using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using Sudoku_Lib;
using TMPro;

public class GM : MonoBehaviour
{
    Sudoku sudoku;
    public GBSquare prefab;
    public GBSquare Current { get; set; }
    public int Seed { get; set; }

    public readonly Color32 CELL_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 CELL_DEFAULT_ALT = new Color32(178, 190, 195, 255);
    public readonly Color32 CELL_CURRENT = new Color32(85, 239, 196, 255);

    public readonly Color32 BTN_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 BTN_SELECTED = new Color32(178, 190, 195, 255);

    private async void Start()
    {
        sudoku = new Sudoku();
        Seed = new System.Random().Next();
        await sudoku.Init(Seed);

        var gameboard = GameObject.FindWithTag("GameBoard");

        var rect = gameboard.GetComponent<RectTransform>();

        var size = rect.rect.width / 9;

        var gridlayout = gameboard.GetComponent<GridLayoutGroup>();

        gridlayout.cellSize = new Vector2(size, size);

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
            {
                var square = Instantiate(prefab, gameboard.transform, false);
                square.initSudokuCellData(sudoku.PuzzleBoard[i, j]);
                square.GetComponent<Image>().color = GetBGAccent(i, j);
            }
    }

    public void SetCurrent(GBSquare square)
    {
        if (Current != null)
            Current.GetComponent<Image>().color = GetBGAccent(Current.Data.Row, Current.Data.Col);
        
        Current = square;
        Current.GetComponent<Image>().color = CELL_CURRENT;
    }

    private Color GetBGAccent(int row, int col)
    {
        var evenRow = row / 3 == 0 || row / 3 == 2;
        var evenCol = col / 3 == 0 || col / 3 == 2;
        var center = row / 3 == 1 && col / 3 == 1;
        return (evenRow && evenCol) || center ? CELL_DEFAULT : CELL_DEFAULT_ALT;
    }
}
