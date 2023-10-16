using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Element
{
    public Rocket(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       DailyGain = new Resources(0, 0, 2000);

       Name = "Rocket";
       Description = "Brings in a couple thousand people every year.";
    }
}