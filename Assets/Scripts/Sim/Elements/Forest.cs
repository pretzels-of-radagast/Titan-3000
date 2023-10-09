using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Forest : Element
{
    public Forest(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(5,0,0);

        Name = "Forest";
        Description = "Forests are a great producer of oxygen through photosynthesis. A forest, with mature trees, allows for a huge increase in oxygen on the planet";
    }
}