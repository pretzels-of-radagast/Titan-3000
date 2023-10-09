using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnBurger : Element
{
    public SaturnBurger(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 1000, 0);
        DieNextTurn = true;
       Name = "Saturn Burger";
       Description = "with saturns rings on it?? As onions??";
    }
}