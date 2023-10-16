using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCity : Element
{
    public FlyingCity(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Gain = new Resources(0, 0, 50000);
        DestructionCost = new Resources(0, 0, 50000);


       Name = "Flying City";
       Description = "A flying city, which can transport people from one planet to another. Greatly increases population";
    }
}