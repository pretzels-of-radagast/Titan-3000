using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgaeSandwich : Element
{
    public AlgaeSandwich(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 15, 0);
        DieNextTurn = true;
        
        Name = "Cabbage Sandwich";
        Description = "The most basic food combo.";
    }
   
}
