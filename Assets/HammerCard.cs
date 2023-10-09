using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HammerCard : SelectableItem
{
    public override bool IsLegibleCost() { return true; }
    public override bool IsLegiblePlacement(Vector3 screenPoint) { return true; }
    public bool IsValidSetLocation(Vector3 screenSpacePoint) { return true; }

    private void Start() { NewElementInstance(); }

    private void NewElementInstance() { if (element == null) {element = new Hammer(0, 0);} }

    public override void Spawn(Vector3 screenSpacePoint) {
        Debug.Log("bruh");
        Sim.instance.DeleteElement(screenSpacePoint);
    }

    protected override void Update() { HoverStuff(); }
    private void HoverStuff() {
        if (!MousePointer.instance.IsSelected(this)) {
            if (IsLegibleCost()) {
                UnTint();

                bool StartHovering = IsMouseOnCard && LerpCorountine == null;
                bool isPressed = IsMouseOnCard && Mouse.current.leftButton.isPressed;

                if (StartHovering) { LerpPosition(DefaultPosition + Vector3.up * 4, 0.2f); }
                if (isPressed) { SelectCard(); }
            } else {
                Tint();
            }
        }
        if (!IsMouseOnCard && !isLerpingToDefault) { LerpDefault(0.2f); }
    }
}
