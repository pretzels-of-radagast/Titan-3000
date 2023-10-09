using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Element
{
    public Pizza(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Pizza";
       Description = "A healthy, nutritous meal";
    }
}