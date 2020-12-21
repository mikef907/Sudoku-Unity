using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public Timer timer;
    public TMP_Text stats;
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
