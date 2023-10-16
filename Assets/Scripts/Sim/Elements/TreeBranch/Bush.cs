using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Element
{
    public Bush(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(1, 0, 0);
        Name = "Bush";
        Description = "Produces oxygen more effectively." ;
    }
}
