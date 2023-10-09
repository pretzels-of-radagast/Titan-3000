using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Element
{
    public Rocket(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Rocket";
       Description = "Blast off! Explore new planets and worlds (Decorational)";
    }
}