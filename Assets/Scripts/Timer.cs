using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TMP_Text timeDisplay;
    public TimeSpan time { get; private set; }
    private double tick = 0.02;

    private bool _paused = false;
    // Start is called before the first frame update
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
