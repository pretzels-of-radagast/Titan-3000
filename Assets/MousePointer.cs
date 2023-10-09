using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : Singleton<MousePointer>
{

    public Canvas parentCanvas;

    public SelectableItem SelectedItem;
    private bool IsLegiblePlacement;

    public RectTransform cardHolder;
    public RectTransform rendererHolder;


    [Header("Audioclips")]
    public AudioClip PopInAudioClip;
    public AudioClip PopOutAudioClip;
    
    // private bool PreviouslyOnCancelRegion;
    // public RectTransform CancelRegion;

    public void Update() {
        MoveToMousePoint();
        UpdateLegibility();
        UpdateUse();
    }

    public void MoveToMousePoint() {
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);
        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }

    public void UpdateLegibility() {
        if (SelectedItem == null) return;
        
        IsLegiblePlacement = SelectedItem.IsLegiblePlacement(Input.mousePosition);
        if (IsLegiblePlacement) {
            SelectedItem.UnTint();
        } else {
            SelectedItem.Tint();
        }
    }

    public void UpdateUse() {
        bool use = !Mouse.current.leftButton.isPressed;
        if (SelectedItem != null && use) {
            if (SelectedItem.IsLegibleCost() && IsLegiblePlacement) {
                SelectedItem.Spawn(Input.mousePosition);

                SFXSystem.instance.PlayVariatedSFX(PopInAudioClip);
            }
            DeSelectCard();
        }
    }

    public void SelectItem(SelectableItem item) {
        if (item == SelectedItem) { return; }
        if (SelectedItem != null) { DeSelectCard(); }

        item.transform.SetParent(transform);
        item.StopMovement();
        SelectedItem = item;

        if (SelectedItem.GetType() == typeof(ElementRenderer)) {
            SFXSystem.instance.PlayVariatedSFX(PopOutAudioClip);
        }
    }

    public void DeSelectCard() {
        if (SelectedItem == null) { return; }
        
        SelectedItem.UnTint();
        if (SelectedItem.GetType() == typeof(Card)) {
            SelectedItem.transform.SetParent(cardHolder, true);
            SelectedItem.LerpDefault(0.1f);
            SelectedItem = null;
        } else if (SelectedItem.GetType() == typeof(ElementRenderer)) {
            SelectedItem.transform.SetParent(rendererHolder, true);
            (SelectedItem as ElementRenderer).UpdatePosition();
            SelectedItem = null;
        } else if (SelectedItem.GetType() == typeof(HammerCard)) {
            SelectedItem.transform.SetParent(cardHolder, true);
            SelectedItem.LerpDefault(0.1f);
            SelectedItem = null;
        }
    }

    public bool IsSelected(SelectableItem item) {
        return SelectedItem == item;
    }
}
