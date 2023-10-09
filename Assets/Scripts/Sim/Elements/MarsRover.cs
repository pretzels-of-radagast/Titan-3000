using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRover : Element
{
    public MarsRover(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Mars Rover";
       Description = "With this technology, explore the world! Find new species and resources (Decorational)";
    }
}