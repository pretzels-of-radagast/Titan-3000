using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Card : SelectableItem {

    public override bool IsLegibleCost() { return element.Cost.IsLess(Sim.instance.celluarMatrix.resources); }
    public override bool IsLegiblePlacement(Vector3 screenPoint) { return IsValidSetLocation(screenPoint); }

    public override void Spawn(Vector3 screenSpacePoint) {
        Debug.Log("spawn");
        Sim.instance.SpawnElement(ElementType, screenSpacePoint);
        
        if (element.cardBehaviour == CardBehaviour.OneUse) {
            HandHolder.instance.RemoveCard(this);
        }
    }

    public void Step() {
        NewElementInstance();
        if (element.cardBehaviour == CardBehaviour.Discards) {
            HandHolder.instance.RemoveCard(this);
        }
    }


    private void Start() { NewElementInstance(); }

    private void NewElementInstance() { if (element == null) {element = Sim.instance.elementLibrary.NewElementInstance(0, 0, ElementType, null, false);} }

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
