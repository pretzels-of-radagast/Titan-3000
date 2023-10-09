using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : Element
{
    public School(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "School";
       Description = "providing education to the masses. Allows for new humans: engineer, and researcher.";
    }
}