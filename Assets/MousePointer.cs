using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : Singleton<MousePointer>
{

    public Canvas parentCanvas;
    public RectTransform TrashRect;

    public SelectableItem SelectedItem;
    private bool IsLegiblePlacement;

    public RectTransform cardHolder;
    public RectTransform rendererHolder;


    [Header("Audioclips")]
    public AudioClip PopInAudioClip;
    public AudioClip PopOutAudioClip;
    public AudioClip HammerAudioClip;
    public AudioClip TrashAudioClip;
    
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
            bool isOnTrash = RectTransformUtility.RectangleContainsScreenPoint(TrashRect, Input.mousePosition, Camera.main);
            if (isOnTrash) {
                if (TrashItem()) {
                    SFXSystem.instance.PlayVariatedSFX(TrashAudioClip);
                }
            }
            else if (SelectedItem.IsLegibleCost() && IsLegiblePlacement) {
                SelectedItem.Spawn(Input.mousePosition);

                if (SelectedItem.GetType() == typeof(HammerCard)) {
                    SFXSystem.instance.PlayVariatedSFX(HammerAudioClip);
                } else {
                    SFXSystem.instance.PlayVariatedSFX(PopInAudioClip);
                }
                
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

    public bool TrashItem() {
        if (SelectedItem == null) { return false; }

        bool isTrashLegible = SelectedItem.GetType() == typeof(ElementRenderer) || (SelectedItem as Card).element.cardBehaviour != CardBehaviour.Permanent;
        if (!isTrashLegible) { return false; }

        if (SelectedItem.GetType() == typeof(Card)) {
            HandHolder.instance.RemoveCard(SelectedItem as Card, true);
            SelectedItem = null;
        } else if (SelectedItem.GetType() == typeof(ElementRenderer)) {
            (SelectedItem as ElementRenderer).element.Trash();
            SelectedItem = null;
        }
        return true;
    }

    public bool IsSelected(SelectableItem item) {
        return SelectedItem == item;
    }
}

