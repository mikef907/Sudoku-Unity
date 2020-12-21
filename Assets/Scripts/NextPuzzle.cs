using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPuzzle : MonoBehaviour
{
    public Button nextPuzzleBtn;
    // Start is called before the first frame update
    void Start()
    {
        nextPuzzleBtn.onClick.AddListener(delegate { OnClick(); });
    }

    private void OnClick()
    {
        //GameService.Instance.NewPuzzle();
        SceneManager.LoadScene("Game");
        GameService.Instance.NewPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
