using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Element
{
    public Garbage(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Garbage (Calvin)";
       Description = "A pile of garbage. Does nothing.";
    }
}