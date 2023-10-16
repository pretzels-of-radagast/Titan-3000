using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineer : Element
{
    public Engineer(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Name = "Engineer";
        Description = "A math-oriented individual with a sharp mind to innovate - give one a house!";
    }
}
