using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementRenderer : SelectableItem
{
    public static Vector2 MatrixOffset = new Vector2(0.625f, 0.625f);
    public Sim simulation;

    public int matrixX;
    public int matrixY;

    public override void Spawn(Vector3 screenSpacePoint) {
        Debug.Log("move");
        element.Move(simulation.celluarMatrix, screenSpacePoint);
        UpdatePosition();
    }
    public override bool IsLegibleCost() { return true; }
    public override bool IsLegiblePlacement(Vector3 screenPoint) { return IsValidSetLocation(screenPoint); }

    public void AssignElement(Element element) {
        this.element = element;
        this.simulation = Sim.instance;

        element.OnPositionChanged += UpdatePosition;
        element.OnDelete += Delete;
        element.OnGain += OnGain;
        UpdatePosition();
    }

    private void OnGain(Resources resources) {
        NumberParticleCreator.instance.CreateParticle(resources, transform.position);
    }

    private void Delete() {
        Destroy(this.gameObject);
    }

    public void UpdatePosition() {
        matrixX = element.matrixX;
        matrixY = element.matrixY;

        Vector2 newPosition = simulation.MatrixToWorldCoordinates(element.matrixX, element.matrixY); // + MatrixOffset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

}
