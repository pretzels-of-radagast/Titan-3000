using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenGenerator : Element
{
    public OxygenGenerator(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Oxygen Generator";
       Description = "An oxygen generator. Produces oxygen for the people of Titan to breathe in";
    }
}
