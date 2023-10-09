using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Element
{
    public Bread(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 40, 0);
        DieNextTurn = true;
        Name = "Bread";
        Description = "A house hold classic; create many recipes from this!";
    }
}
