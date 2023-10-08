using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Element {

    public Factory(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 0, 0);

        Deduct(Cost);
    }

}
