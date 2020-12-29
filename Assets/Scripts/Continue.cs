using UnityEngine;

public class Continue : MonoBehaviour
{
    private void Awake()
    {
        using (var dataService = new DataService())
        {
            if (dataService.ReadCurrentGame() == null)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    }
}
