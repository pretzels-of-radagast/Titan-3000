using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Element
{
    public City(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Gain = new Resources(0, 0, 500);
        DestructionCost = new Resources(0, 0, 500);

        Name = "City";
        Description = "A bustling economic centre for human activity.";
    }
}
