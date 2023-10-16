using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : Element
{
    public Salad(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 60, 0);
        DieNextTurn = true;
        Name = "Salad";
        Description = "The second most basic combination of food.";
    }

}
