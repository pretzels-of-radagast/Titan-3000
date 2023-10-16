using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Element
{
      public Factory(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Name = "Factory";
        Description = "An industrialized building part of many mordern cities. produces shirts.";
    }
}