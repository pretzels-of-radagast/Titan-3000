using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingot : Element
{
    public Ingot(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Gain = new Resources(0, 0, 0, 1);
       DieNextTurn = true;

       Name = "Ingot";
       Description = "Smelted from iron ore. Useful in the creation of rovers and many other technologies";
       
    }
}