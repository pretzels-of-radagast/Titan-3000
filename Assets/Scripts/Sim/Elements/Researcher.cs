using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher : Element
{
    public Researcher(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Researcher";
       Description = "Key to new technologies, and always hard at work on a project or paper";
    }
}