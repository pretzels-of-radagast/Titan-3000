using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : Element
{
    public Doge(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(10,10,10);
        Name = "Doge";
        Description = "Dog but better";
    }

}
