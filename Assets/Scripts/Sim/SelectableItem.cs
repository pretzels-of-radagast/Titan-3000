using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public abstract class SelectableItem : MonoBehaviour
{
    public ElementType ElementType;
    [HideInInspector] public Element element;

    public RectTransform rectTransform;
    protected Image CardPanel;
    protected bool Tinted;
    public bool IsMouseOnCard => RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, Camera.main);

    
    public abstract void Spawn(Vector3 screenSpacePoint);
    public abstract bool IsLegibleCost();
    public abstract bool IsLegiblePlacement(Vector3 screenPoint);


    protected virtual void Awake() { CardPanel = GetComponent<Image>(); rectTransform = GetComponent<RectTransform>(); }
    public void SelectCard() { if (MousePointer.instance.SelectedItem == null) { MousePointer.instance.SelectItem(this); }  }
    public bool IsValidSetLocation(Vector3 screenSpacePoint) { return Sim.instance.IsValidSetLocation(ElementType, screenSpacePoint); }


    protected virtual void Update() {
        bool isPressed = IsMouseOnCard && Mouse.current.leftButton.isPressed;
        if (! MousePointer.instance.IsSelected(this) && IsLegibleCost() && isPressed) {
            SelectCard();
        }
    }


    /* 
    Lerps 
    */

    [HideInInspector] protected Vector3 DefaultPosition;
    [HideInInspector] protected Coroutine LerpCorountine;
    [HideInInspector] protected bool isLerpingToDefault;

    public void SetDefaultPosition(Vector3 worldPoint) { DefaultPosition = worldPoint; }

    public void LerpDefault(float duration) {
        if (LerpCorountine != null) { StopMovement(); }
        isLerpingToDefault = true;
        LerpCorountine = StartCoroutine(LerpPositionCoroutine(DefaultPosition, duration));
    }

    public void LerpPosition(Vector3 targetPosition, float duration) {
        if (LerpCorountine != null) {  StopMovement(); }
        isLerpingToDefault = false;
        LerpCorountine = StartCoroutine(LerpPositionCoroutine(targetPosition, duration));
    }

    public void StopMovement() {
        if (LerpCorountine != null) {
            StopCoroutine(LerpCorountine);
        }
        
    }

    protected IEnumerator LerpPositionCoroutine(Vector3 targetPosition, float duration) {
        float time = 0;
        Vector3 startPosition = rectTransform.localPosition;

        while (time < duration)
        {
            rectTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null; // wait until next frame
        }

        rectTransform.localPosition = targetPosition; // snap in case of any floating point errors

        LerpCorountine = null;
    }

    /*

    VISUALS

    */

    public void Tint() {
        if (!Tinted) {
            Debug.Log("tinted");
            CardPanel.color = Color.gray;
            Tinted = true;
        }
    }

    public void UnTint() {
        if (Tinted) {
            Debug.Log("untinted");
            CardPanel.color = Color.white;
            Tinted = false;
        }
    }

}
