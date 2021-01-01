using System.Linq;
using TMPro;
using UnityEngine;

public class EntryInput : MonoBehaviour
{
    public TMP_InputField inputField;
    private Color32 UNEDITABLE = new Color32(214, 48, 49, 255);
    GBSquare parent;
    GameService gameService;
    int? curr;

    private void Start()
    {
        gameService = FindObjectOfType<GameService>();

        parent = GetComponentInParent<GBSquare>();

        inputField.readOnly = !parent.Data.Editable;

        if (!parent.Data.Editable)
            inputField.GetComponentsInChildren<TMP_Text>().ToList().ForEach(_ => _.color = UNEDITABLE);
        
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
        gameService.HighlightSameValues(curr);
        curr = value;

        gameService.CheckCompleted();
    }
}
