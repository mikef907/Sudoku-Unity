using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class noteBtn : MonoBehaviour
{
    public GM gameMaster;
    public Button btn;
    private int value;
    // Start is called before the first frame update
    void Start()
    {
        value = int.Parse(btn.GetComponentInChildren<TMP_Text>().text);
        btn.onClick.AddListener(delegate { OnClick(); });
    }

    private void OnClick()
    {
        if(gameMaster.Current != null)
            if (gameMaster.Current.Data.Data.Contains(value))
                gameMaster.Current.Data.Data.Remove(value);
            else
                gameMaster.Current.Data.Data.Add(value);
    }



    // Update is called once per frame
    void Update()
    {
        if(gameMaster.Current != null)
            if (gameMaster.Current.Data.Data.Contains(value) && btn.image.color != gameMaster.BTN_SELECTED)
            {
                btn.image.color = gameMaster.BTN_SELECTED;
            }
            else if (!gameMaster.Current.Data.Data.Contains(value) && btn.image.color != gameMaster.BTN_DEFAULT)
            {
                btn.image.color = gameMaster.BTN_DEFAULT;
            }
    }

}
