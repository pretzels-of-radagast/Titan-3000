using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicFace : Element
{
    public DemonicFace(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 0, 1000);

        DieNextTurn = false;
        Name = "DemonicFace";
        Description = "How did we get here?";
    }
}
