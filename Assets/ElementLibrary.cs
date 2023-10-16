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
    Tomato,
    Wabubby,
    AlgaeSandwich,
    Bread,
    Burger, 
    Bush, 
    BusinessMan, 
    DemonicFace, 
    Dog, 
    DogFarm, 
    Meat, 
    Drill, 
    Engineer, 
    Factory, 
    FlyingCity, 
    Forest, 
    Furnace, 
    Garbage, 
    Hospital, 
    Ingot, 
    Rover, 
    MegaCity, 
    OxygenGenerator, 
    Pizza, 
    RawOre, 
    Researcher, 
    Rocket, 
    SaturnBurger, 
    School, 
    SuperPlant, 
    SuperPlantFarm, 
    TitanBurger, 
    TomatoMan, 
    Tree, 
    Salad, 
    House,
    Doge,
    Flower
}

public class ElementLibrary : Singleton<ElementLibrary> {

    [SerializeField] public List<ElementRegistry> ElementBook;
    [SerializeField] public List<FusionRegistry> FusionBook;
    [SerializeField] public List<StringFusionRegistry> StringFusionBook;
    [SerializeField] public List<AugmentationRegistry> AugmentationBook;

    public Transform RendererHolder;

    private Dictionary<ElementType, ElementRegistry> ElementDictionary;

    public bool[] DiscoveredElements;

    public Element NewElementInstance(int matrixX, int matrixY, ElementType elementType, CelluarMatrix matrix, bool rendererFlag=true, bool discoverFlag=true) {
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
        }  else if (elementType == ElementType.Wheat) {
            element = new Wheat(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.WheatFarm) {
            element = new WheatFarm(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Potato) {
            element = new Potato(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.PotatoFarm) {
            Debug.Log("making a potato farm");
            element = new PotatoFarm(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Tomato) {
            element = new Tomato(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.TomatoFarm) {
            element = new TomatoFarm(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Village) {
            element = new Village(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.City) {
            element = new City(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Sandwich) {
            element = new Sandwich(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Wabubby) {
            element = new Wabubby(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.AlgaeSandwich) {
            element = new AlgaeSandwich(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Bread) {
            element = new Bread(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Burger) {
            element = new Burger(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Bush) {
            element = new Bush(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.BusinessMan) {
            element = new BusinessMan(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.DemonicFace) {
            element = new DemonicFace(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Dog) {
            element = new Dog(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.DogFarm) {
            element = new DogFarm(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Meat) {
            element = new DogMeat(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Drill) {
            element = new Drill(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Engineer) {
            element = new Engineer(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Factory) {
            element = new Factory(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.FlyingCity) {
            element = new FlyingCity(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Forest) {
            element = new Forest(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Furnace) {
            element = new Furnace(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Garbage) {
            element = new Garbage(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Hospital) {
            element = new Hospital(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Ingot) {
            element = new Ingot(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Rover) {
            element = new MarsRover(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.MegaCity) {
            element = new MegaCity(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.OxygenGenerator) {
            element = new OxygenGenerator(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Pizza) {
            element = new Pizza(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.RawOre) {
            element = new RawOre(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Researcher) {
            element = new Researcher(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.Rocket) {
            element = new Rocket(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.SaturnBurger) {
            element = new SaturnBurger(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.School) {
            element = new School(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.SuperPlant) {
            element = new SuperPlant(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.SuperPlantFarm) {
            element = new SuperPlantFarm(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.TitanBurger) {
            element = new TitanBurger(matrixX, matrixY, matrix);
        }
        else if (elementType == ElementType.TomatoMan) {
            element = new TomatoMan(matrixX, matrixY, matrix);
        } else if (elementType == ElementType.Tree) {
            element = new Tree(matrixX, matrixY, matrix);
        }else if (elementType == ElementType.Salad) {
            element = new Salad(matrixX, matrixY, matrix);
        }else if (elementType == ElementType.Doge) {
            element = new Doge(matrixX, matrixY, matrix);
        }

        element.elementType = elementType;
        
        if (discoverFlag) {
            Discover(elementType);
        }

        if (rendererFlag) {
            NewRendererInstance(elementType, element);
        }
        
        
        return element;
    }

    private void Awake() { 
        base.Awake(); 
        CreateElementDictionary(); 
        CreateDiscoveredElementsArray(); 
        Debug.Log(UnregisteredLibraryElements(ElementBook)); 

        AddStringFusionRegistries();
    }

    private string UnregisteredLibraryElements(List<ElementRegistry> elementBook) {
        string[] elementNames = Enum.GetNames(typeof(ElementType));
        bool[] isElementRegistered = new bool[elementNames.Length];
        foreach (ElementRegistry registry in elementBook) {
            isElementRegistered[(int) registry.type] = true;
        }

        string final = "unregistered elements: ";

        for (int i=0; i<isElementRegistered.Length; i++) {
            if (!isElementRegistered[i]) {
                final += $"{elementNames[i]}, ";
            }
        }

        return final;
    }

    private void CreateElementDictionary() {
        ElementDictionary = new Dictionary<ElementType, ElementRegistry>();
        foreach (ElementRegistry registry in ElementBook) {
            ElementDictionary.Add(registry.type, registry);
        }
    }

    private void CreateDiscoveredElementsArray() {
        DiscoveredElements = new bool[ElementBook.Count];
    }

    private bool Discover(ElementType elementType) {
        int index = 0;
        foreach (ElementRegistry registry in ElementBook) {
            if (registry.type == elementType) {
                DiscoveredElements[index] = true;
            }
            index += 1;
        }
        return false;
    }

    public int NumberDiscovered() {
        int count = 0;
        foreach (bool discovered in DiscoveredElements) {
            if (discovered) count += 1;
        }
        return count;
    }

    public Card NewCardInstance(ElementType elementType, bool addFlag=true) {
        if (!IsElementRegistered(elementType)) { return null; }

        GameObject baseObject = ElementDictionary[elementType].card.gameObject;
        Card card = Instantiate(baseObject, HandHolder.instance.transform).GetComponent<Card>();
        if (addFlag ) {
            HandHolder.instance.AddCard(card);
        }
        

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


    public void AddStringFusionRegistries() {
        string[] elementNames = Enum.GetNames(typeof(ElementType));
        Dictionary<string, ElementType> elementHash = new Dictionary<string, ElementType>();
        for (int i=0; i<elementNames.Length; i++) {
            elementHash.Add(elementNames[i], (ElementType) i);
        }

        foreach (StringFusionRegistry stringRegistry in StringFusionBook) {
            FusionBook.Add(new FusionRegistry { // throws errors automatically with incorrect names :)
                a = elementHash[stringRegistry.a],
                b = elementHash[stringRegistry.b],
                result = elementHash[stringRegistry.result],
            });
        }

    }

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

    public bool IsAugmentationRegistered(ElementType reactant, ElementType reagent) {
        foreach (AugmentationRegistry augRegistry in AugmentationBook) {
            bool isMatch = augRegistry.reagent == reagent && augRegistry.reactant == reactant;
            if (isMatch) {
                return true;
            }
        }

        return false;
    }

    public Card NewAugmentationCardInstance(ElementType reactant, ElementType reagent) {
        foreach (AugmentationRegistry augRegistry in AugmentationBook) {
            bool isMatch = augRegistry.reagent == reagent && augRegistry.reactant == reactant;
            if (isMatch) {
                return NewCardInstance(augRegistry.result);
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

[System.Serializable]
public struct StringFusionRegistry {
    public string a;
    public string b;

    public string result;
}

[System.Serializable]
public struct AugmentationRegistry {
    public ElementType reagent;
    public ElementType reactant;

    public ElementType result;
}