using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : Element
{
    public Salad(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 55, 0);
        DieNextTurn = true;
        Name = "Salad";
        Description = "Earth's Bounty: very healthy and tasty!";
    }

}
