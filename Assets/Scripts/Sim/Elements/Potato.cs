using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Element
{
    public Potato(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 2, 0);
        DieNextTurn = true;
    }

}
