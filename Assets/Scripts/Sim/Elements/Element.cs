using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element {

    /* MATRIX */
    public int matrixX { get; private set; }
    public int matrixY { get; private set; }
    public CelluarMatrix matrix;

    /* VALUES */
    public Resources Cost;
    public Resources DailyGain;
    public ElementType[] CreatedElementCards;
    

    /* EVENTS */
    public delegate void OnPositionChangedHandler(); public event OnPositionChangedHandler OnPositionChanged = delegate{};
    public delegate void OnDeletedHandler(); public event OnDeletedHandler OnDelete = delegate{};


    public Element(int x, int y, CelluarMatrix celluarMatrix) {
        matrixX = x;
        matrixY = y;
        matrix = celluarMatrix;

        Cost = new Resources(0, 0, 0);

        Deduct(Cost);
    }

    public abstract void Step(CelluarMatrix celluarMatrix);
    

    /*

    RESOURCE MANIPULATION

    */

    public void Deduct(Resources resources) {
        if (matrix == null) { return; }
        matrix.DeductResources(resources);
    }

    public void Add(Resources resources) {
        if (matrix == null) { return; }
        matrix.AddResources(resources);
    }

    public void AddCard() {

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
