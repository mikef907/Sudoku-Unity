using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListItem : MonoBehaviour
{
    public TMP_Text Seed;
    public TMP_Text Time;
    public TMP_Text Attempt;
    public TMP_Text Completed;

    public void SetContent(SudokuGame game)
    {
        Seed.text = game.Seed.ToString();
        Time.text = game.Time.ToString(@"hh\:mm\:ss\:ff");
        Attempt.text = game.Attempt.ToString();
        Completed.text = game.Solved ? "Yes" : "No";
    }
}
