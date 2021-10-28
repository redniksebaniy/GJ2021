using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivate : MonoBehaviour
{
    public GameObject canvas;

    public void CanvasOn()
    {
        canvas.SetActive(true);
    }
    public void CanvasOFF()
    {
        canvas.SetActive(false);
    }
}
