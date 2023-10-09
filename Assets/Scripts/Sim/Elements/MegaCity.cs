using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCity : Element
{
    public MegaCity(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Mega City";
       Description = "A huge city, suitable for a large human population";
    }
}

