using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CelluarMatrix {
    private Element[][] matrix;
    private int matrixWidth;
    private int matrixHeight;
    private Sim simulation;

    private ElementLibrary elementLibrary;

    /* 
    World Behaviour
    */
    public Resources resources;
    public int Cycle;
    public bool Alive;

    /*
    Cheats
    */
    private bool doPeopleEat;
    private float StarvePercent;


    /*
    
    INITIALISATION

    */
    public CelluarMatrix(int width, int height, Sim simulation, Resources startingResources, ElementLibrary elementLibrary) {
        this.simulation = simulation;
        this.resources = startingResources;
        this.elementLibrary = elementLibrary;

        matrixWidth = width;
        matrixHeight = height;

        this.Cycle = 0;
        this.Alive = true;

        matrix = GenerateMatrix();
    }

    public void SetCheats(bool doPeopleEat) {
        this.doPeopleEat = doPeopleEat;
    }

    public Element[][] GenerateMatrix() {
        Debug.Log($"width:{matrixWidth} height:{matrixHeight}");

        Element[][] newMatrix = new Element[matrixHeight][];
        for (int y = 0; y < matrixHeight; y++) {
            Element[] row = new Element[matrixWidth];
            for (int x = 0; x < matrixWidth; x++) {
                row[x] = elementLibrary.NewElementInstance(x, y, ElementType.Air, this, false);
            }
            newMatrix[y] = row;
        }

        matrix = newMatrix;

        return newMatrix;
    }


    /*
    
    AUTOMATA

    */

    public void StepAll() {
        for (int y = 0; y < matrixHeight; y++) {
            Element[] row = getRow(y);

            for (int x = 0; x < matrixWidth; x++) {
                Element element = row[x];

                if (element != null) {
                    element.Step(this);
                }
            }
        }

        bool Starving = resources.Human > resources.Food;
        if (doPeopleEat) {
            DeductResources(new Resources(0, resources.Human, 0));
        }
        if (Starving) {
            DeductResources(new Resources(0, 0, (int) Mathf.Max(resources.Human * StarvePercent, 1)));
        }
        if (resources.Human == 0) {
            Alive = false;
        }

        Cycle += 1;
        
    }

    /*

    RESOURCE MANIPULATION

    */

    public void AddResources(Resources other) {
        resources = resources.Add(other);
    }

    public void DeductResources(Resources other) {
        resources = resources.Subtract(other);
    }

    public void AddCard(ElementType elementType) {
        elementLibrary.NewCardInstance(elementType);
    }

    /*
    
    REFERENCE TOOLS

    */

    public Element get(int x, int y) { return !isWithinBounds(x, y) ? null : matrix[y][x]; }
    public Element[] getRow(int y) { return !isWithinBounds(0, y) ? null : matrix[y]; }

    public bool set(int x, int y, Element element, bool deleteFlag=true) {
        if (!isWithinBounds(x, y)) { return false; }

        Element newElement = element;
        Element original = matrix[y][x];
        
        if (original != Air.getInstance()) {
            
            Debug.Log(elementLibrary.IsAugmentationRegistered(newElement.elementType, original.elementType));

            if (elementLibrary.IsFusionRegistered(original.elementType, newElement.elementType)) {
                newElement = elementLibrary.NewFusionInstance(original.elementType, newElement.elementType, x, y, this);
                element.Delete();
            }
            else if (elementLibrary.IsAugmentationRegistered(original.elementType, newElement.elementType)) {
                elementLibrary.NewAugmentationCardInstance(original.elementType, newElement.elementType);
                element.Delete();
                return true;
            }
        }

        if (deleteFlag) { matrix[y][x].Delete(); } 
        matrix[y][x] = newElement;

        newElement.SetCoordinates(x, y);

        return true;
    }

    public bool DeleteElement(int matrixX, int matrixY) {
        return set(matrixX, matrixY, elementLibrary.NewElementInstance(matrixX, matrixY, ElementType.Air, this, false));
    }
    
    public bool isWithinBounds(int x, int y) { return x >= 0 && y >= 0 && x < matrixWidth && y < matrixHeight; }
    public Vector2 BoundCoordinates(int x, int y) { return new Vector2(Mathf.Clamp(x, 0, matrixWidth - 1), Mathf.Clamp(y, 0, matrixHeight - 1)); }
    public int BoundX(int x) { return Mathf.Clamp(x, 0, matrixWidth - 1); }
    public int BoundY(int y) { return Mathf.Clamp(y, 0, matrixHeight - 1); }

    /* 

    GAMEPLAY TOOLS

    */

    public bool IsValidSetLocation(Vector2 screenSpacePoint, RectTransform spriteRect, Camera camera, ElementType elementType) {
        Vector2 matrixCoordinates = GetMatrixCoordinates(screenSpacePoint, spriteRect, camera);
        if (!isWithinBounds((int) matrixCoordinates.x, (int) matrixCoordinates.y)) { return false; }

        Element original = get((int) matrixCoordinates.x, (int) matrixCoordinates.y);

        if (original == Air.getInstance()) { return true; }
        
        if (elementLibrary.IsFusionRegistered(original.elementType, elementType)) { return true; }

        if (elementLibrary.IsAugmentationRegistered(original.elementType, elementType)) { return true; }

        return false;
    }

    public bool SpawnElement(Vector2 screenSpacePoint, RectTransform spriteRect, Camera camera, ElementType elementType) {
        Vector2 matrixCoordinates = GetMatrixCoordinates(screenSpacePoint, spriteRect, camera);
        if (!isWithinBounds((int) matrixCoordinates.x, (int) matrixCoordinates.y)) { return false; }

        set((int) matrixCoordinates.x, (int) matrixCoordinates.y, elementLibrary.NewElementInstance(0, 0, elementType, this));
        return true;
    }

    public bool DeleteElement(Vector2 screenSpacePoint, RectTransform spriteRect, Camera camera) {
        Vector2 matrixCoordinates = GetMatrixCoordinates(screenSpacePoint, spriteRect, camera);
        if (!isWithinBounds((int) matrixCoordinates.x, (int) matrixCoordinates.y)) { return false; }

        DeleteElement((int) matrixCoordinates.x, (int) matrixCoordinates.y);
        return true;
    }

    public Vector2 GetMatrixCoordinates(Vector2 screenSpacePoint, RectTransform spriteRect, Camera camera) {
        Vector2 RectSpacePoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(spriteRect, screenSpacePoint, camera, out RectSpacePoint);
        Vector2 RectFractionalPoint = RectSpacePoint / spriteRect.sizeDelta;
        Vector2 MatrixPoint = new Vector2(
            Mathf.RoundToInt(RectFractionalPoint.x * matrixWidth), 
            Mathf.RoundToInt(RectFractionalPoint.y * matrixHeight)
        );
        return MatrixPoint;
    }

    public Vector2 MatrixToWorldCoordinates(RectTransform spriteRect, int matrixX, int matrixY) {
        Vector2 WorldSpacePoint = spriteRect.anchoredPosition + new Vector2((float) matrixX / matrixWidth, (float) matrixY / matrixHeight) * spriteRect.sizeDelta;
        return WorldSpacePoint;
    }

}

[System.Serializable]
public struct ElementTypeRendererPair {
    public ElementType type;
    public ElementRenderer renderer;
}

public class Sim : Singleton<Sim> {
    public Vector2 Size = new Vector2(5f, 5f);
    public CelluarMatrix celluarMatrix;
    public ElementLibrary elementLibrary;

    public Resources PreviousResources;
    public Resources Resources => celluarMatrix.resources;
    public bool Alive => celluarMatrix.Alive;
    public int Cycle => celluarMatrix.Cycle;


    [Header("Steppables")]
    public CardUnlocker cardUnlocker;
    public CycleSummaryDisplay cycleSummary;
    public DeathScreen deathScreen;
    public Transform CardHolder;

    [HideInInspector] public int CardsPlayedThisTurn;
    public bool CanPlay => CardsPlayedThisTurn < 6;
    
    // cache
    [SerializeField] private Camera ViewCamera;
    [SerializeField] private RectTransform simBounds;
    [SerializeField] private Resources startingResources;
    [SerializeField] private bool doPeopleEat = true;

    public delegate void OnSpawnHandler(); public event OnSpawnHandler OnSpawn = delegate{};


    private void Awake() {
        base.Awake();
    }

    private void Start() {
        celluarMatrix = new CelluarMatrix((int) Size.x, (int) Size.y, this, startingResources, elementLibrary);
        celluarMatrix.SetCheats(doPeopleEat);

        cycleSummary.OnFinished += cardUnlocker.Step;
    }

    /*
    HELPER FUNCTIONS
    */

    public Element GetElement(Vector2 screenPoint) {
        Vector2 matrixCoordinates = celluarMatrix.GetMatrixCoordinates(screenPoint, simBounds, ViewCamera);
        return celluarMatrix.get((int) matrixCoordinates.x, (int) matrixCoordinates.y);
    }

    public Vector2 GetMatrixCoordinates(Vector2 screenPoint) {
        return celluarMatrix.GetMatrixCoordinates(screenPoint, simBounds, ViewCamera);
    }

    public Vector2 MatrixToWorldCoordinates(int matrixX, int matrixY) {
        return celluarMatrix.MatrixToWorldCoordinates(simBounds, matrixX, matrixY);
    }

    public bool SpawnElement(ElementType elementType, Vector2 screenSpacePoint) {
        CardsPlayedThisTurn += 1;
        OnSpawn();
        return celluarMatrix.SpawnElement(screenSpacePoint, simBounds, ViewCamera, elementType);
    }

    public bool IsValidSetLocation(ElementType elementType, Vector2 screenSpacePoint) {
        return celluarMatrix.IsValidSetLocation(screenSpacePoint, simBounds, ViewCamera, elementType);
    }

    public bool DeleteElement(Vector2 screenSpacePoint) {
        return celluarMatrix.DeleteElement(screenSpacePoint, simBounds, ViewCamera);
    }

    /*
    TESTS
    */
    
    public void Step() {
        PreviousResources = celluarMatrix.resources.Copy();

        celluarMatrix.StepAll();
        foreach (Card card in CardHolder.GetComponentsInChildren<Card>()) {
            card.Step();
        }
        cycleSummary.Step();
        deathScreen.Step();
        //cardUnlocker.Step();

        CardsPlayedThisTurn = 0;
        OnSpawn();
    }

}
