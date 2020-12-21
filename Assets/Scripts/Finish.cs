using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    GameService _gameService;
    public Timer timer;
    public TMP_Text stats;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        //enabled = false;
        //GetComponent<Canvas>().enabled = false;
        GetComponent<Canvas>().enabled = false;
    }

    private void OnEnable()
    {
        _gameService = GameService.Instance;
        stats.text = $"Your time for puzzle {_gameService.Seed} is {timer.time}";
    }
}
