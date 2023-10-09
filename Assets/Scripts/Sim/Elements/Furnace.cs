using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Element
{
    public Furnace(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {

       Name = "Furnace";
        Description = "Able to smelt iron and other minerals. Also able to bake bread!";

    }
}