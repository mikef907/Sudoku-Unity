using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sudoku_Lib;
using TMPro;
using UnityEngine.UI;

public class GBSquare : MonoBehaviour
{
    public GM _gamemaster;
    public GBSquare square;
    public TMP_InputField input;
    public TMP_Text notes;

    public SudokuCellData Data { get; private set; }
    

    public void SetAsCurrent()
    {
        _gamemaster.SetCurrent(this);
        Debug.Log(_gamemaster.Current.name);
    }

    public void initSudokuCellData(SudokuCellData data)
    {
        Data = data;
    }

    private void Update()
    {
        Data.Data.Sort();
        notes.text = string.Join(" ", Data.Data);
    }
}
