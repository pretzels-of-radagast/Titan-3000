using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType {
    Air,
    Human,
    AlgaeFarm,
    Algae,
    Cabbage,
    CabbageFarm,
    Village,
    City,
    Potato,
    Sandwich
}

public class ElementLibrary : Singleton<ElementLibrary> {

    [SerializeField] public List<ElementRegistry> ElementBook;
    [SerializeField] public List<FusionRegistry> FusionBook;

    private Dictionary<ElementType, ElementRegistry> ElementDictionary;

    public Element NewElementInstance(int matrixX, int matrixY, ElementType elementType, CelluarMatrix matrix, bool rendererFlag=true) {
        Element element = Air.getInstance();

        if (elementType == ElementType.Air) {
            element =  Air.getInstance();
        } else if (elementType == ElementType.Human) {
            Debug.Log("creating human");
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.AlgaeFarm) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Algae) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Cabbage) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.CabbageFarm) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Village) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.City) {
            element = new Human(matrixX, matrixY, matrix);
        }  else if (elementType == ElementType.Potato) {
            element = new Potato(matrixX, matrixY, matrix);
        }  else if (elementType == ElementType.Sandwich) {
            element = new Sandwich(matrixX, matrixY, matrix);
        }

        if (rendererFlag) {
            NewRendererInstance(elementType, element);
        }
        
        
        return element;
    }

    private void Awake() { CreateElementDictionary(); }

    private void CreateElementDictionary() {
        ElementDictionary = new Dictionary<ElementType, ElementRegistry>();
        foreach (ElementRegistry registry in ElementBook) {
            ElementDictionary.Add(registry.type, registry);
        }
    }

    public Card NewCardInstance(ElementType elementType, Element assignee) {
        if (!IsElementRegistered(elementType)) { return null; }

        GameObject baseObject = ElementDictionary[elementType].card.gameObject;
        Card card = Instantiate(baseObject, HandHolder.instance.transform).GetComponent<Card>();
        HandHolder.instance.AddCard(card);

        return card;
    }

    public ElementRenderer NewRendererInstance(ElementType elementType, Element assignee) {
        if (!IsElementRegistered(elementType)) { return null; }

        GameObject baseObject = ElementDictionary[elementType].renderer.gameObject;
        ElementRenderer elementRenderer = Instantiate(baseObject).GetComponent<ElementRenderer>();
        elementRenderer.AssignElement(assignee);

        return elementRenderer;
    }

    public bool IsElementRegistered(ElementType elementType) { return ElementDictionary.ContainsKey(elementType); }


    public bool IsFusionRegistered(Element a, Element b) { return true; }
    public Element GetFusionType(Element a, Element b) { return NewElementInstance(0, 0, ElementType.Air, null); }

}


[System.Serializable]
public struct ElementRegistry {
    public ElementType type;
    public ElementRenderer renderer;
    public Card card;
}

[System.Serializable]
public struct FusionRegistry {
    public Element a;
    public Element b;

    public Element result;
}