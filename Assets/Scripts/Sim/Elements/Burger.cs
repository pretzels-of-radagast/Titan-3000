using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : Element
{
    public Burger(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 150, 0);
        DieNextTurn = true;
        Name = "Burger";
        Description = "A delicious staple that probably isn't nutritious";
    }

}
