using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCity : Element
{
    public MegaCity(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Gain = new Resources(0, 0, 5000);
        DestructionCost = new Resources(0, 0, 5000);

       Name = "Mega City";
       Description = "A huge city, suitable for a large human population";
    }
}

