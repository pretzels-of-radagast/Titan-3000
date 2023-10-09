using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCity : Element
{
    public FlyingCity(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0,0,10000);
        DailyCost = new Resources(10000,0,0);


       Name = "Flying City";
       Description = "A flying city, which can transport people from one planet to another. Greatly increases population";
    }
}