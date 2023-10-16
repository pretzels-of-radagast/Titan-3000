using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Element
{
    public Drill(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       AddCardToPool(ElementType.RawOre);
       
       Name = "Drill";
       Description = "Elevates raw ore from Titan's deep mantle.";
    }

}
