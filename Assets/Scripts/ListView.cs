using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListView : MonoBehaviour
{
    public ListItem prefab;
    private void Awake()
    {
        using (var dataService = new DataService())
        {
            var games = dataService.ReadSudokuGames();

            foreach (var game in games)
            { 
                var item = Instantiate(prefab, transform, false);
                item.SetContent(game);
                
            }
        }
    }
}
