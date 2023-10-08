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
    Sandwich,
    PotatoFarm,
    WheatFarm,
    Wheat,
    TomatoFarm,
    Tomato
}

public class ElementLibrary : Singleton<ElementLibrary> {

    [SerializeField] public List<ElementRegistry> ElementBook;
    [SerializeField] public List<FusionRegistry> FusionBook;

    public Transform RendererHolder;

    private Dictionary<ElementType, ElementRegistry> ElementDictionary;

    public Element NewElementInstance(int matrixX, int matrixY, ElementType elementType, CelluarMatrix matrix, bool rendererFlag=true) {
        Element element = Air.getInstance();

        Debug.Log("making an element");

        if (elementType == ElementType.Air) {
            element = Air.getInstance();
        } else if (elementType == ElementType.Human) {
            element = new Human(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.AlgaeFarm) {
            element = new AlgaeFarm(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Algae) {
            element = new Algae(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Cabbage) {
            element = new Cabbage(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.CabbageFarm) {
            element = new CabbageFarm(matrixX, matrixY, matrix);
        }/*  else if (elementType == ElementType.Wheat) {
            element = new Wheat(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.WheatFarm) {
            element = new WheatFarm(matrixX, matrixY, matrix);
        }*/ else if (elementType == ElementType.Potato) {
            element = new Potato(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.PotatoFarm) {
            Debug.Log("making a potato farm");
            element = new PotatoFarm(matrixX, matrixY, matrix);
        }/* else if (elementType == ElementType.Tomato) {
            element = new Tomato(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.TomatoFarm) {
            element = new TomatoFarm(matrixX, matrixY, matrix);
        } */else if (elementType == ElementType.Village) {
            element = new Village(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.City) {
            element = new City(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Sandwich) {
            element = new Sandwich(matrixX, matrixY, matrix);
        }
        element.elementType = elementType;

        if (rendererFlag) {
            NewRendererInstance(elementType, element);
        }
        
        
        return element;
    }

    private void Awake() { base.Awake(); CreateElementDictionary(); }

    private void CreateElementDictionary() {
        ElementDictionary = new Dictionary<ElementType, ElementRegistry>();
        foreach (ElementRegistry registry in ElementBook) {
            ElementDictionary.Add(registry.type, registry);
        }
    }

    public Card NewCardInstance(ElementType elementType) {
        if (!IsElementRegistered(elementType)) { return null; }

        GameObject baseObject = ElementDictionary[elementType].card.gameObject;
        Card card = Instantiate(baseObject, HandHolder.instance.transform).GetComponent<Card>();
        HandHolder.instance.AddCard(card);

        return card;
    }

    public ElementRenderer NewRendererInstance(ElementType elementType, Element assignee) {
        if (!IsElementRegistered(elementType)) { return null; }

        GameObject baseObject = ElementDictionary[elementType].renderer.gameObject;
        ElementRenderer elementRenderer = Instantiate(baseObject, RendererHolder).GetComponent<ElementRenderer>();
        elementRenderer.AssignElement(assignee);
        elementRenderer.ElementType = elementType;

        return elementRenderer;
    }

    public bool IsElementRegistered(ElementType elementType) { return ElementDictionary.ContainsKey(elementType); }


    public bool IsFusionRegistered(ElementType a, ElementType b) {
        foreach (FusionRegistry fusionRegistry in FusionBook) {
            bool isMatch = (fusionRegistry.a == a && fusionRegistry.b == b) || (fusionRegistry.a == b && fusionRegistry.b == a);
            if (isMatch) {
                return true;
            }
        }

        return false;
    }

    public Element NewFusionInstance(ElementType a, ElementType b, int matrixX, int matrixY, CelluarMatrix matrix, bool rendererFlag=true) {
        foreach (FusionRegistry fusionRegistry in FusionBook) {
            bool isMatch = (fusionRegistry.a == a && fusionRegistry.b == b) || (fusionRegistry.a == b && fusionRegistry.b == a);
            if (isMatch) {
                return NewElementInstance(matrixX, matrixY, fusionRegistry.result, matrix, rendererFlag);
            }
        }

        return null;
    }

}


[System.Serializable]
public struct ElementRegistry {
    public ElementType type;
    public ElementRenderer renderer;
    public Card card;
}

[System.Serializable]
public struct FusionRegistry {
    public ElementType a;
    public ElementType b;

    public ElementType result;
}