using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPlantFarm : Element
{
    public SuperPlantFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        AddCardToPool(ElementType.SuperPlant);
       Name = "Super Plant Farm";
       Description = "A farm for super plants. Feed the masses";
    }
}