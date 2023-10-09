using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessMan : Element
{
    public BusinessMan(int x, int y, CelluarMatrix celluarMatrix) : base(x, y, celluarMatrix) {
        Name = "Business Man";
        Description = "A well-dressed human with an expertise in all things business" ;
    }

}
