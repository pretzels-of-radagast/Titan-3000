using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageFarm : Element
{
    public CabbageFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        AddCardToPool(ElementType.Cabbage);
        Name = "Cabbage Farm";
        Description = "A farm to cultivate cabbage.";
    }
}
