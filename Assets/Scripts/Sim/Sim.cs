using System.Collections;
using System.Collections.Generic;
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

        matrix = GenerateMatrix();
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

    public bool set(int x, int y, Element element) {
        if (!isWithinBounds(x, y)) { return false; }

        matrix[y][x].Delete();

        matrix[y][x] = element;
        element.SetCoordinates(x, y);

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

    Given a the starting and ending points of a line, return a list of the points in between.

    */
    public Vector2[] GetInterpolatedPoints(int prevx, int prevy, int currx, int curry) {
        
        // return the only point if there is no change
        if (prevx == currx && prevy == curry) { return new Vector2[]{ new Vector2(currx, curry) }; }

        int diffx = currx - prevx;
        int diffy = curry - prevy;

        // the number of points is whichever axis has more difference
        Vector2[] points;

        if (Mathf.Abs(diffx) >= Mathf.Abs(diffy)) { // going along the x-axis
            // points are added starting from the previous to the current point
            points = new Vector2[Mathf.Abs(diffx) + 1];

            int minX = Mathf.Min(prevx, currx);
            int maxX = Mathf.Max(prevx, currx);
            for (int x=minX; x<=maxX; x+=1) {
                int y = Mathf.RoundToInt(((diffx == 0) ? 0 : (float)diffy / diffx) * (x - prevx) + prevy); // y value = mx + b
                points[Mathf.Abs(x - prevx)] = new Vector2(x, y);
            }

        } else { // going along the y-axis
            points = new Vector2[Mathf.Abs(diffy) + 1];

            int minY = Mathf.Min(prevy, curry);
            int maxY = Mathf.Max(prevy, curry);
            for (int y=minY; y<=maxY; y+=1) {
                int x = Mathf.RoundToInt(((diffx == 0) ? 0 : (float)diffx / diffy) * (y - prevy) + prevx); // y value = mx + b
                points[Mathf.Abs(y - prevy)] = new Vector2(x, y);
            }
        }


        return points;

    }

    /* 

    GAMEPLAY TOOLS

    */

    public bool SpawnRandom(Element elementType) {
        Vector2 matrixCoordinates = new Vector2(Random.Range(0, matrixWidth), Random.Range(0, matrixHeight));

        set((int) matrixCoordinates.x, (int) matrixCoordinates.y, elementType);
        return true;
    }

    public bool SpawnElement(Vector2 screenSpacePoint, RectTransform spriteRect, Camera camera, ElementType elementType) {
        Vector2 matrixCoordinates = GetMatrixCoordinates(screenSpacePoint, spriteRect, camera);
        Debug.Log($"{(int) matrixCoordinates.x} {(int) matrixCoordinates.y}");
        if (!isWithinBounds((int) matrixCoordinates.x, (int) matrixCoordinates.y)) { return false; }

        set((int) matrixCoordinates.x, (int) matrixCoordinates.y, elementLibrary.NewElementInstance(0, 0, elementType, this));
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

    public Resources Resources => celluarMatrix.resources;
    public int Cycle => celluarMatrix.Cycle;
    
    // cache
    [SerializeField] private Camera ViewCamera;
    [SerializeField] private RectTransform simBounds;
    [SerializeField] private Resources startingResources;


    private void Awake() {
        base.Awake();

        celluarMatrix = new CelluarMatrix((int) Size.x, (int) Size.y, this, startingResources, elementLibrary);
    }

    /*
    HELPER FUNCTIONS
    */

    public Vector2 MatrixToWorldCoordinates(int matrixX, int matrixY) {
        return celluarMatrix.MatrixToWorldCoordinates(simBounds, matrixX, matrixY);
    }

    public bool SpawnElement(ElementType elementType, Vector2 screenSpacePoint) {
        return celluarMatrix.SpawnElement(screenSpacePoint, simBounds, ViewCamera, elementType);
    }

    /*
    TESTS
    */
    
    public void Step() {
        celluarMatrix.StepAll();
    }

}
