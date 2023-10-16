using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoFarm : Element
{
    public PotatoFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        AddCardToPool(ElementType.Potato);

        Name = "Potato Farm";
        Description = "A farm to cultivate Potatoes.";
    }

}
