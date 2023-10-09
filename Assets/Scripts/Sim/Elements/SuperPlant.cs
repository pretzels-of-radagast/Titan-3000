using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPlant : Element
{
    public SuperPlant(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Super Plant";
       Description = "A super plant! Greatly increases food";
    }
}