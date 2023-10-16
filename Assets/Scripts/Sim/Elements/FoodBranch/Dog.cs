using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Element
{
    public Dog(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Name = "Doog";
        Description = "Edible alien. If only there was some way to cook it...";
    }
}
