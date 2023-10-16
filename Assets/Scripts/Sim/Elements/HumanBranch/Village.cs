using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Element
{
    public Village(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Gain = new Resources(0, 0, 50);
        DestructionCost = new Resources(0, 0, 50);

        Name = "Village";
        Description = "A \"traditional\" village.";
    }
}
