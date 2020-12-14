using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class EntryInput : MonoBehaviour
{
    public TMP_InputField inputField;

    GBSquare parent;
    GM _gamemaster;

    private void Start()
    {
        parent = GetComponentInParent<GBSquare>();
        _gamemaster = FindObjectOfType<GM>();

        inputField.enabled = parent.Data.Editable;

        if (!parent.Data.Editable)
            inputField.GetComponentsInChildren<TMP_Text>().ToList().ForEach(_ => _.fontStyle = FontStyles.Bold);
        
        
        inputField.text = parent.Data.Value.ToString();

    }

    private void OnEnable()
    {
        inputField.onEndEdit.AddListener(delegate { OnEndEdit(); });
        inputField.onValueChanged.AddListener(delegate { OnValueChanged(); });
        inputField.onSelect.AddListener(delegate { OnSelect(); });
    }

    private void OnValueChanged()
    {

    }

    private void OnSelect()
    {
        parent.SetAsCurrent();
    }

    private void OnEndEdit()
    {
        int entry;

        if (string.IsNullOrEmpty(inputField.text))
        {
            setValue(null);
        }
        else if (int.TryParse(inputField.text, out entry) && entry > 0)
        {
            setValue(entry);
        }
        else
        {
            setValue(null);
        }
    }

    private void setValue(int? value)
    {
        parent.Data.Value = value;
        inputField.text = value?.ToString();
    }
}
