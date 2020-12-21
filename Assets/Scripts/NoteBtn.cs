using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteBtn : MonoBehaviour
{
    private GameService gameService;
    public Button btn;
    private int value;

    void Start()
    {
        gameService = FindObjectOfType<GameService>();
        value = int.Parse(btn.GetComponentInChildren<TMP_Text>().text);
        btn.onClick.AddListener(delegate { OnClick(); });
    }

    public void SetState()
    {
        if (gameService.Current.Data.Data.Contains(value))
            btn.image.color = gameService.BTN_SELECTED;
        else
            btn.image.color = gameService.BTN_DEFAULT;
    }

    private void OnClick()
    {
        if (gameService.Current != null)
        {
            if (gameService.Current.Data.Data.Contains(value))
                gameService.Current.Data.Data.Remove(value);
            else
                gameService.Current.Data.Data.Add(value);

            SetState();
            gameService.Current.UpdateNotes();    
        }

    }
}
