using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMousePointer : MonoBehaviour
{
    public Canvas parentCanvas;

    public float Offset;

    public void Update() {
        MoveToMousePoint();
    }

    public void MoveToMousePoint() {
        Vector3 movePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);
        transform.position = movePos + Vector3.up * Offset;
    }
}
