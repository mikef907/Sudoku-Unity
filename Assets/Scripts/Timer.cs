using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text timeDisplay;
    public TimeSpan time { get; set; }
    private double tick = 0.02;

    private bool _paused = false;

    void Start()
    {
        timeDisplay = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        if (!_paused)
        { 
            time = time.Add(TimeSpan.FromSeconds(tick));
            timeDisplay.text = time.ToString(@"hh\:mm\:ss\:ff");
        }
    }

    public void TogglePause(bool state)
    {
        _paused = state;
    }
}
