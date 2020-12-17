using Sudoku_Lib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    public List<GBSquare> GameSquares = new List<GBSquare>();
    public GBSquare Current { get; private set; }
    public int Seed { get; private set; }

    public readonly Color32 CELL_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 CELL_DEFAULT_ALT = new Color32(178, 190, 195, 255);
    public readonly Color32 CELL_CURRENT = new Color32(85, 239, 196, 255);
    public readonly Color32 CELL_ADJ = new Color32(0, 184, 148, 255);

    public readonly Color32 BTN_DEFAULT = new Color32(223, 230, 233, 255);
    public readonly Color32 BTN_SELECTED = new Color32(178, 190, 195, 255);

    private Sudoku sudoku;
    private List<NoteBtn> noteBtns = new List<NoteBtn>();

    private GameService() { }

    private async void Init()
    {
        sudoku = new Sudoku();
        Seed = new System.Random().Next();
        await sudoku.Init(Seed);

        if (noteBtns.Count == 0)
            foreach (var _ in GameObject.FindGameObjectsWithTag("NoteBtn"))
                noteBtns.Add(_.GetComponent<NoteBtn>());
    }


    public void SetCurrent(GBSquare square)
    {
        if (Current != null)
            ResetHighlight();
            //Current.GetComponent<Image>().color = GetBGAccent(Current.Data.Row, Current.Data.Col);
        
        Current = square;
        Current.GetComponent<Image>().color = CELL_CURRENT;
        HighlightAdj();
        SetNoteButtonsState();
    }

    private void ResetHighlight()
    {
        foreach (var square in GameSquares.Where(s =>
         (s.Data.Row == Current.Data.Row || s.Data.Col == Current.Data.Col) ||
         (Current.Data.Value.HasValue && s.Data.Value == Current.Data.Value)))
            square.GetComponent<Image>().color = GetBGAccent(square.Data.Row, square.Data.Col);
    }

    private void HighlightAdj()
    {
        foreach (var square in GameSquares.Where(s => s != Current &&
             ((s.Data.Row == Current.Data.Row || s.Data.Col == Current.Data.Col) ||
             (Current.Data.Value.HasValue && s.Data.Value == Current.Data.Value))))
            square.GetComponent<Image>().color = CELL_ADJ;
    }

    public void HighlightSameValues(int? oldValue)
    { 
        if(oldValue.HasValue)
            foreach(var square in GameSquares.Where(s => 
                s != Current && 
                s.Data.Row != Current.Data.Row && 
                s.Data.Col != Current.Data.Col && 
                s.Data.Value == oldValue))
                square.GetComponent<Image>().color = GetBGAccent(square.Data.Row, square.Data.Col);

        if(Current.Data.Value.HasValue)
            foreach(var square in GameSquares.Where(s => s != Current && s.Data.Value == Current.Data.Value))
                square.GetComponent<Image>().color = CELL_ADJ;
    }

    public void InitCellData(GBSquare square, int row, int col) 
    {
        square.InitSudokuCellData(sudoku.PuzzleBoard[row, col]);
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
        foreach (var btn in noteBtns)
            btn.SetState();
    }
}
