using Sudoku_Lib;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GBSquare : MonoBehaviour, IPointerClickHandler
{
    public GBSquare square;
    public TMP_InputField input;
    public TMP_Text notes;
    private GameService gameService;

    public SudokuCellData Data { get; private set; }

    private void Start()
    {
        gameService = FindObjectOfType<GameService>();

        if (Data != null)
            UpdateNotes();
    }

    public void SetAsCurrent()
    {
        gameService.SetCurrent(this);
        Debug.Log(gameService.Current.name);
    }

    public void InitSudokuCellData(SudokuCellData data)
    {
        Data = data;
    }

    public void UpdateNotes()
    {
        Data.Data.Sort();
        notes.text = string.Join("", Data.Data);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var entry = GetComponentInChildren<TMP_InputField>();
        entry.Select();
    }
}
