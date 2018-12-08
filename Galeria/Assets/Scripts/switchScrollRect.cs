using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class switchScrollRect : MonoBehaviour
{
    [SerializeField]
    private RectTransform vertical;
    [SerializeField]
    private float MinLimit;

    private Vector2 position;
    private bool drag;
    private float variation;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
            variation = position.y;
            drag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }

        if (drag)
        {
            if (position.y > Input.mousePosition.y + 5 || position.y < Input.mousePosition.y - 5)
            {
                float posY = Mathf.Clamp(vertical.anchoredPosition.y + (Input.mousePosition.y - variation), 0, MinLimit);
                vertical.anchoredPosition = new Vector2(vertical.anchoredPosition.x, posY);
                variation = Input.mousePosition.y;
            }
        }
    }

}
