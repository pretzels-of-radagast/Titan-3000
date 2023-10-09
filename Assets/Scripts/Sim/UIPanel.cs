using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIPanel : MonoBehaviour{
    [SerializeField] private  Transform RendererHolder;


    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI typeText;

    [Header("Cost")]
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image costIcon;

    [Header("Gain")]
    [SerializeField] private TextMeshProUGUI gainText;
    [SerializeField] private Image gainIcon;

    [Header("Icons")]
    [SerializeField] private Sprite oxygen;
    [SerializeField] private Sprite food;
    [SerializeField] private Sprite human;

    private void Update(){
        Element element = LocateHoveredElement();
        if (element != null) { DisplayInformation(element); }
    }
    
    private Element LocateHoveredElement() {
        if (MousePointer.instance.SelectedItem != null) {
            return MousePointer.instance.SelectedItem.element;
        }
        foreach (Card card in HandHolder.instance.Hand) {
            if (card.IsMouseOnCard) { return card.element; }
        }

        foreach (ElementRenderer elementRenderer in RendererHolder.GetComponentsInChildren<ElementRenderer>()) {
            if (elementRenderer.IsMouseOnCard) { return elementRenderer.element; }
        }

        return null;
    }

    private void DisplayInformation(Element element){
        titleText.text = element.Name;
        descText.text = element.Description;
        typeText.text = GetBehaviourText(element.cardBehaviour);

        Resources displayGain = element.Gain.IsLess(element.DailyGain) ? element.DailyGain : element.Gain;
        Resources displayCost = element.Cost.IsLess(element.DailyCost) ? element.DailyCost : element.Cost;
        SetImageNumber(displayGain, gainIcon, gainText);
        SetImageNumber(displayCost, costIcon, costText);
    }

    private string GetBehaviourText(CardBehaviour behaviour) {
        if (behaviour == CardBehaviour.Permanent){
            return "Permanent.";
        } else if(behaviour == CardBehaviour.Discards){
            return "Discards This Turn.";
        } else if(behaviour == CardBehaviour.OneUse){
            return "One-Time Use.";
        } else{
            return "";
        }
    }

    private void SetImageNumber(Resources resources, Image image, TextMeshProUGUI text) {
        float max = Mathf.Max(resources.Oxygen, resources.Food, resources.Human);

        if (max == resources.Oxygen) {
            image.sprite = oxygen;
        } else if (max == resources.Food) {
            image.sprite = food;
        } else if (max == resources.Human) {
            image.sprite = human;
        }

        text.text = $"{(int) max}";
    }

}
