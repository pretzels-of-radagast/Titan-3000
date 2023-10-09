using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatFarm : Element
{
    public WheatFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Wheat Farm";
       Description = "A farm used to cultivate wheat";
    }
}