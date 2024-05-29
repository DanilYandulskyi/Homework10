using UnityEngine;
using System.Collections.Generic;

public class ColorSeter : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;

    private void Awake()
    {
        SetColor();
    }

    private void SetColor()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            Color color = _colors[Random.Range(0, _colors.Count)];

            renderer.material.color = color;
        }
    }
}
