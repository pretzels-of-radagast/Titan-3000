using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoMan : Element
{
    public TomatoMan(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Tomato Man";
       Description = "Ey its a me";
    }
}
