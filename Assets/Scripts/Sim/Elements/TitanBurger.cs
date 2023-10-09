using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanBurger : Element
{
    public TitanBurger(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 10000, 0);
        DieNextTurn = true;
       Name = "Titan Burger";
       Description = "A staple for the people of Titan. A burger made from the meat of aliens, cheese, and two slices of tomato as buns";
    }
}