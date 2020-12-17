using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TMP_Text timeDisplay;
    private TimeSpan timer;
    private double tick = 0.02;
    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = GetComponent<TMP_Text>();
    }



    private void FixedUpdate()
    {
        timer = timer.Add(TimeSpan.FromSeconds(tick));
        timeDisplay.text = timer.ToString(@"hh\:mm\:ss\:ff");
    }
}
