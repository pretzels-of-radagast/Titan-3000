using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Element
{
    public Village(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 10, 0);
        Gain = new Resources(0, 0, 10);
        DestructionCost = new Resources(0, 0, 10);
        Name = "Village";
        Description = "A small civilzation of humans";
    }
}
