using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenGenerator : Element
{
    public OxygenGenerator(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(3,0,0);

       Name = "Oxygen Generator";
       Description = "A Moxie Box in the shape of a cylinder.";
    }
}
