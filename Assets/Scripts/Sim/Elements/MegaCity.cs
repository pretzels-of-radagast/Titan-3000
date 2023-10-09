using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCity : Element
{
    public MegaCity(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 1000, 0);
        DailyGain = new Resources(0, 0, 1000);

       Name = "Mega City";
       Description = "A huge city, suitable for a large human population";
    }
}

