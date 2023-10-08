using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour {
    public ElementType ElementType;
    public RectTransform rectTransform;

    private Image CardPanel;
    private bool Tinted;


    // properties
    public bool IsMouseOnCard => RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, Camera.main);
    public bool IsLegible => ElementInstance.Cost.IsLess(Sim.instance.celluarMatrix.resources);

    // cached values
    [HideInInspector] private Element ElementInstance;
    [HideInInspector] private Vector3 DefaultPosition;
    [HideInInspector] private Coroutine LerpCorountine;
    [HideInInspector] private bool isLerpingToDefault;

    public void SelectCard() { MousePointer.instance.SelectItem(this); }
    public void Spawn(Vector3 screenSpacePoint) {
        Sim.instance.SpawnElement(ElementType, screenSpacePoint);
        
        if (ElementInstance.cardBehaviour == CardBehaviour.OneUse) {
            HandHolder.instance.RemoveCard(this);
        }
    }

    public bool IsValidSpawnLocation(Vector3 screenSpacePoint) {
        return Sim.instance.IsValidSpawnLocation(ElementType, screenSpacePoint);
    }

    private void Awake() {
        CardPanel = GetComponent<Image>(); 
    }

    private void Start() {
        ElementInstance = Sim.instance.elementLibrary.NewElementInstance(0, 0, ElementType, null, false);
    }

    protected void Update() {
        if (IsLegible) {
            bool StartHovering = IsMouseOnCard && LerpCorountine == null;
            bool isPressed = IsMouseOnCard && Mouse.current.leftButton.isPressed;

            if (StartHovering) { LerpPosition(DefaultPosition + Vector3.up * 4, 0.2f); }
            if (isPressed) { SelectCard(); }

            UnTint();
        } else {
            Tint();
        }
        
        
        if (!IsMouseOnCard && !isLerpingToDefault) { LerpDefault(0.2f); }
    }

    protected void Step() {
        if (ElementInstance.cardBehaviour == CardBehaviour.Discards) {
            HandHolder.instance.RemoveCard(this);
        }
    }

    /* 
    Lerps 
    */

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
        StopCoroutine(LerpCorountine);
    }

    protected IEnumerator LerpPositionCoroutine(Vector3 targetPosition, float duration)
    {
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
            CardPanel.color = Color.gray;
            Tinted = true;
        }
    }

    public void UnTint() {
        if (Tinted) {
            CardPanel.color = Color.white;
            Tinted = false;
        }
    }

}
