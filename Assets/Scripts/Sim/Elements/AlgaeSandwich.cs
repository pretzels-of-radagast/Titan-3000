using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgaeSandwich : Element
{
    public AlgaeSandwich(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 50, 0);
        DieNextTurn = true;
        Name = "AlgaeSandwich";
        Description = "Slimy, and gross, but probably nutritious";
    }
   
}
