using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Element
{
    public City(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyCost = new Resources(0, 100, 0);
        DailyGain = new Resources(0, 0, 100);

        Name = "City";
        Description = "A bustling economic centre for human activity";
    }
}
