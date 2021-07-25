using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class GridBackground : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] GridLayoutGroup grid;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void Scale() {
        float w = grid.constraintCount * (grid.cellSize.x + grid.spacing.x + 2);
        float h = grid.transform.childCount % grid.constraintCount;
        if (h == 0)
            h = grid.transform.childCount / grid.constraintCount;
        h = h * (grid.cellSize.y + grid.spacing.y + 2);
        rect.sizeDelta = new Vector2(w, h);
    }

}
