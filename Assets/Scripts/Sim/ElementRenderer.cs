using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementRenderer : MonoBehaviour
{
    public static Vector2 MatrixOffset = new Vector2(0.625f, 0.625f);

    public Element element;
    public Sim simulation;

    public int matrixX;
    public int matrixY;

    public void AssignElement(Element element) {
        this.element = element;
        this.simulation = Sim.instance;

        element.OnPositionChanged += UpdatePosition;
        element.OnDelete += Delete;
        UpdatePosition();
    }

    private void Delete() {
        Destroy(this.gameObject);
    }

    private void UpdatePosition() {
        matrixX = element.matrixX;
        matrixY = element.matrixY;

        Vector2 newPosition = simulation.MatrixToWorldCoordinates(element.matrixX, element.matrixY); // + MatrixOffset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

}
