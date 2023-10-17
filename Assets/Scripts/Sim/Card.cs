using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Card : SelectableItem {
    
    // cache
    private bool playedThisTurn = false;

    public override bool IsLegibleCost() { return (element.cardBehaviour != CardBehaviour.Recharge || !playedThisTurn) && 
        element.Cost.IsLess(Sim.instance.celluarMatrix.resources) && Sim.instance.CanPlay; }
    public override bool IsLegiblePlacement(Vector3 screenPoint) { return IsValidSetLocation(screenPoint); }

    public override void Spawn(Vector3 screenSpacePoint) {
        Debug.Log("spawn");
        playedThisTurn = true;
        Sim.instance.SpawnElement(ElementType, screenSpacePoint);

        if (element.cardBehaviour == CardBehaviour.OneUse || element.cardBehaviour == CardBehaviour.Discards) {
            HandHolder.instance.RemoveCard(this);
        }
    }

    public virtual void Step() {
        playedThisTurn = false;
        NewElementInstance();
        if (element.cardBehaviour == CardBehaviour.Discards) {
            HandHolder.instance.RemoveCard(this);
        }
    }

    public virtual void Start() { NewElementInstance(); }

    protected virtual void NewElementInstance() { if (element == null) {element = Sim.instance.elementLibrary.NewElementInstance(0, 0, ElementType, null, false, false);} }

    protected override void Update() { HoverStuff(); }
    protected virtual void HoverStuff() {
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
