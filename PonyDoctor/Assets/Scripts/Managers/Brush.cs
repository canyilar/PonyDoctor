using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField]
    Color _color;
    public void SetCurrentColor()
    {
        ColorSelector.SetColor(_color);

    }

}
