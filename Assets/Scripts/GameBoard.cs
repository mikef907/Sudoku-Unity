using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public GBSquare prefab;
    private GameService gameService;

    private IEnumerator Start()
    {
        yield return null;

        var rect = GetComponent<RectTransform>();

        var size = rect.rect.width / 9;

        var gridlayout = GetComponent<GridLayoutGroup>();

        gridlayout.cellSize = new Vector2(size, size);

        gameService = GameService.Instance;

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
            {
                var square = Instantiate(prefab, transform, false);
                gameService.InitCellData(square, i, j);
                square.GetComponent<Image>().color = gameService.GetBGAccent(i, j);
            }

        Debug.Log("Gameboard Setup");
    }
}
