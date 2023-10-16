using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPlant : Element
{
    public SuperPlant(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(0, 250, 0);
        DieNextTurn = true;
       Name = "Super Plant";
       Description = "Extremly nutrish and delish! A staple for the titan burger.";
    }
}