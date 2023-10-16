using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Element
{
    public Flower(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Flower";
       Description = "An inefficient, but beautiful organism. :)";
    }

}
