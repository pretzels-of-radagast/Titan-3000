using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Element
{
    public Human(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 1, 0);
    }
    
}
