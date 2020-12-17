using Sudoku_Lib;
using UnityEngine;
using UnityEngine.UI;

public class GameService
{
    protected static GameService _instance;

    public static GameService Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new GameService();
                _instance.Init();
            }
            return _instance;
        }
    }

    public GBSquare Current { get; private set; }

    public int Seed { get; private set; }

    public readonly Color32 CELL_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 CELL_DEFAULT_ALT = new Color32(178, 190, 195, 255);
    public readonly Color32 CELL_CURRENT = new Color32(85, 239, 196, 255);

    public readonly Color32 BTN_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 BTN_SELECTED = new Color32(178, 190, 195, 255);

    private Sudoku sudoku;
    //private List<NoteBtn> noteBtns;

    private GameService() { }

    private void Init()
    {
        sudoku = new Sudoku();
        Seed = new System.Random().Next();
        sudoku.Init(Seed);
    }


    public void SetCurrent(GBSquare square)
    {
        if (Current != null)
            Current.GetComponent<Image>().color = GetBGAccent(Current.Data.Row, Current.Data.Col);
        
        Current = square;
        Current.GetComponent<Image>().color = CELL_CURRENT;
        SetNoteButtonsState();
    }

    public void InitCellData(GBSquare square, int row, int col) 
    {
        square.initSudokuCellData(sudoku.PuzzleBoard[row, col]);
    }

    public Color GetBGAccent(int row, int col)
    {
        var evenRow = row / 3 == 0 || row / 3 == 2;
        var evenCol = col / 3 == 0 || col / 3 == 2;
        var center = row / 3 == 1 && col / 3 == 1;
        return (evenRow && evenCol) || center ? CELL_DEFAULT : CELL_DEFAULT_ALT;
    }

    public void SetNoteButtonsState()
    {
        var btnCanvas = GameObject.FindGameObjectWithTag("BtnCanvas");
        foreach (var btn in btnCanvas.GetComponentsInChildren<NoteBtn>())
            btn.SetState();
    }
}
