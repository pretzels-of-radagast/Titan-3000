using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element {

    private static Element emptyInstance;

    public static Element getInstance() {
        if (emptyInstance == null) { emptyInstance = new Air(-1, -1); }
        return emptyInstance;
    }

    public Air(int x, int y) : base(x, y, null)
    {
    }

    public override void Step(CelluarMatrix celluarMatrix) {
        return;
    }

    public override void Delete() { }

    public override void SetCoordinates(int x, int y) { }

    public override bool Swap(CelluarMatrix celluarMatrix, Element other) { return false; }

    public override bool Swap(CelluarMatrix celluarMatrix, Element other, int otherX, int otherY) { return false; }

}
