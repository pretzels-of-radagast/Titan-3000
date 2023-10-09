using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenGenerator : Element
{
    public OxygenGenerator(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(5,0,0);

       Name = "Oxygen Generator";
       Description = "An oxygen generator. Produces oxygen for the people of Titan to breathe in";
    }
}
