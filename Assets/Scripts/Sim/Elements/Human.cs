using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Element
{
    public Human(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 1, 0);
        Gain = new Resources(0, 0, 1);
        DestructionCost = new Resources(0, 1, 0);
        cardBehaviour = CardBehaviour.Permanent;
    }
    
}
