using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : Element
{
    public Wheat(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 2, 0);
        DieNextTurn = true;
       Name = "Wheat";
       Description = "A standard crop; can be used to produce bread";
    }
}