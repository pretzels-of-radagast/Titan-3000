using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : Element
{
    public Sandwich(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 100, 0);
        DieNextTurn = true;
        
        Name = "Sandwich";
        Description = "A hearty meal that feature an assortment of different foods";
    }

}
