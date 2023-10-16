using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRover : Element
{
    public MarsRover(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Titan Rover";
       Description = "A cute little relic to Earth a thousand years ago.";
    }
}