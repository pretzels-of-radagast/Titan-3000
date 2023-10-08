using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : Singleton<MousePointer>
{
    public Canvas parentCanvas;
    private Card SelectedCard;
    
    // private bool PreviouslyOnCancelRegion;
    // public RectTransform CancelRegion;

    public void Update() {
        MoveToMousePoint();
        UpdateDeselect();
    }

    public void MoveToMousePoint() {
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);
        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }

    public void UpdateDeselect() {
        bool isMouseUp = !Mouse.current.leftButton.isPressed;
        if (isMouseUp) {
            if (SelectedCard != null && SelectedCard.IsLegible) {
                SelectedCard.Spawn(Input.mousePosition);
            }
            DeSelectCard();
        }
        
        /*
        bool MouseOnCancelRegion = RectTransformUtility.RectangleContainsScreenPoint(CancelRegion, Input.mousePosition, Camera.main);
        bool EnteredCancelRegion = !PreviouslyOnCancelRegion && MouseOnCancelRegion;
        if (EnteredCancelRegion) { DeSelectCard(); }
        PreviouslyOnCancelRegion = MouseOnCancelRegion;
        */
    }

    public void SelectItem(Card card) {
        if (card == SelectedCard) { return; }
        if (SelectedCard != null) { DeSelectCard(); }

        card.transform.SetParent(transform);
        card.StopMovement();
        SelectedCard = card;
    }

    public void DeSelectCard() {
        if (SelectedCard == null) { return; }

        SelectedCard.transform.SetParent(HandHolder.instance.transform, true);
        SelectedCard.LerpDefault(0.1f);
        SelectedCard = null;
    }
}
