using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher : Element
{
    public Researcher(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
       Name = "Researcher";
       Description = "Researches new tech - give one a house!";
    }
}