using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element {

    /* MATRIX */
    public int matrixX { get; private set; }
    public int matrixY { get; private set; }
    public CelluarMatrix matrix;
    public ElementType elementType;

    /* VALUES */
    public Resources Cost;
    public Resources Gain;
    public Resources DailyGain;
    public Resources DailyCost;
    public List<ElementType> DailyCreatedElementCards;
    public Resources DestructionCost;

    public bool DieNextTurn;
    

    /* EVENTS */
    public delegate void OnPositionChangedHandler(); public event OnPositionChangedHandler OnPositionChanged = delegate{};
    public delegate void OnDeletedHandler(); public event OnDeletedHandler OnDelete = delegate{};


    public Element(int x, int y, CelluarMatrix celluarMatrix) {
        matrixX = x;
        matrixY = y;
        matrix = celluarMatrix;
        
        // set default values
        Cost = new Resources(0, 0, 0);
        Gain = new Resources(0, 0, 0);
        DailyGain = new Resources(0, 0, 0);
        DailyCost = new Resources(0, 0, 0);
        DailyCreatedElementCards = new List<ElementType>();
        DestructionCost = new Resources(0, 0, 0);
        DieNextTurn = false;
    }

    public void Start() {
        Deduct(Cost);
        Add(Gain);
    }

    public virtual void Step(CelluarMatrix celluarMatrix) {
        matrix.AddResources(DailyGain);
        AddDailyCards();

        if (DieNextTurn) {
            matrix.DeleteElement(matrixX, matrixY);
        }

    }
    

    /*

    AUTOMATA

    */

    public void Deduct(Resources resources) {
        if (matrix == null) { return; }
        matrix.DeductResources(resources);
    }

    public void Add(Resources resources) {
        if (matrix == null) { return; }
        matrix.AddResources(resources);
    }

    public void AddDailyCards() {
        if (matrix == null) { return; }
        foreach (ElementType elementType in DailyCreatedElementCards) {
            matrix.AddCard(elementType);
        }
    }

    /*
    
    TOOLS

    */

    public void AddCardToPool(ElementType elementType) {
        DailyCreatedElementCards.Add(elementType);
    }

    /*

    MATRIX MANIPULATION

    */

    public virtual void SetCoordinates(int x, int y) {
        this.matrixX = x;
        this.matrixY = y;
        OnPositionChanged();
    }

    public virtual void Delete() {
        matrix.DeductResources(DestructionCost);
        OnDelete();
    }

    public virtual bool Swap(CelluarMatrix celluarMatrix, Element other) {
        return Swap(celluarMatrix, other, other.matrixX, other.matrixY);
    }

    public virtual bool Swap(CelluarMatrix celluarMatrix, Element other, int otherX, int otherY) { // neat, readable, way to store otherX, otherY vals
        if (this == other) { return false; }

        celluarMatrix.set(matrixX, matrixY, other);
        celluarMatrix.set(otherX, otherY, this);
        return true;
    }

}
