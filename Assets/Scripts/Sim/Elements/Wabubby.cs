using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wabubby : Element
{
    public Wabubby(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Name = "KEvin";
        Description = "Coolest guy around";
        Gain = new Resources(1000, 1000, 1000);
    }

}
