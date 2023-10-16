using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Element
{
    public Hospital(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Hostpital";
       Description = "Filled with doctors, nurses, and other medical help";
    }
}