using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Element
{
    public Tree(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        DailyGain = new Resources(2,0,0);

       Name = "Tree";
        Description = "Produces large quantities of oxygen.";      
    }
}