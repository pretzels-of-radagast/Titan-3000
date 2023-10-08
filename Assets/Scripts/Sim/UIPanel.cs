using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class UIPanel : MonoBehaviour{
    public GameObject hand;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI descText;
    private TextMeshProUGUI typeText;

    // Start is called before the first frame update
    private void Start(){
        titleText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        descText = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        typeText = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update(){
        DisplayInformation(hand.transform.GetChild(0).gameObject.GetComponent<Card>().element);
    }

    private void DisplayInformation(Element element){
        titleText.text = element.Name;
        descText.text = element.Description;

        if(element.cardBehaviour == CardBehaviour.Permanent){
            typeText.text = "Permanant";
        }else if(element.cardBehaviour == CardBehaviour.Discards){
            typeText.text = "Discards This Turn";
        }else if(element.cardBehaviour == CardBehaviour.OneUse){
            typeText.text = "One-Time Use";
        }else{
            typeText.text = "";
        }
    }

}
