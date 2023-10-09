using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawOre : Element
{
    public RawOre(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Raw Ore";
       Description = "Mined from a drill. But how do you use it?";
    }
}