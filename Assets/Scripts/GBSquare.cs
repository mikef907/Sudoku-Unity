using Sudoku_Lib;
using TMPro;
using UnityEngine;

public class GBSquare : MonoBehaviour
{
    public GameService gameService;
    public GBSquare square;
    public TMP_InputField input;
    public TMP_Text notes;

    public SudokuCellData Data { get; private set; }

    private void Start()
    {
        gameService = GameService.Instance;
    }

    public void SetAsCurrent()
    {
        gameService.SetCurrent(this);
        Debug.Log(gameService.Current.name);
    }

    public void initSudokuCellData(SudokuCellData data)
    {
        Data = data;
    }

    public void UpdateNotes()
    {
        Data.Data.Sort();
        notes.text = string.Join(" ", Data.Data);
    }
}
