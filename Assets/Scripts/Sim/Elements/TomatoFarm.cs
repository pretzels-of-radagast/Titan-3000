using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoFarm : Element
{
    public TomatoFarm(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Tomato Farm";
       Description = "A farm for cultivating tomatoes";
    }
}