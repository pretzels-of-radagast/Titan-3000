using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : Element
{
    public Cabbage(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 1, 0);
        DieNextTurn = true;
    }
}
