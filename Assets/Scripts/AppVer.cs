using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppVer : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<TMP_Text>().text = $"Version: {Application.version} Build: 18";
    }
}
