using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Element
{
    public House(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Gain = new Resources(0, 0, 5);
        DestructionCost = new Resources(0, 0, 5);

        Name = "House";
        Description = "A single nuclear family home.";
    }
}

