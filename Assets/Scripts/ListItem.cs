using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ListItem : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Seed;
    public TMP_Text Time;
    public TMP_Text Attempt;
    public TMP_Text Completed;

    public void OnPointerClick(PointerEventData eventData)
    {
        var controller = FindObjectOfType<PuzzleListController>();
        controller.SetSelected(this);
    }

    public void SetContent(SudokuGame game)
    {
        Seed.text = game.Seed.ToString();
        Time.text = game.Time.ToString(@"hh\:mm\:ss\:ff");
        Attempt.text = game.Attempt.ToString();
        Completed.text = game.Solved ? "Yes" : "No";
    }


}
