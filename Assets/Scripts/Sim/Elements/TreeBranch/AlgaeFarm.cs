using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgaeFarm : Element
{
    public AlgaeFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        AddCardToPool(ElementType.Algae);

        Name = "Algae Farm";
        Description = "A farm to cultivate algae. Gain 1 Algae card on next cycle.";
    }

}
