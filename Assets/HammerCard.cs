using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HammerCard : Card
{
    public override bool IsLegibleCost() { return true; }
    public override bool IsLegiblePlacement(Vector3 screenPoint) {
        Element elementToHammer = Sim.instance.GetElement(screenPoint);
        return elementToHammer != null && elementToHammer.cardBehaviour != CardBehaviour.Permanent;
    }

    public override void Spawn(Vector3 screenSpacePoint) {
        Debug.Log("HAMMER TIME!");
        Sim.instance.DeleteElement(screenSpacePoint);
    }

    protected override void NewElementInstance() { if (element == null) {element = new Hammer(0, 0);} }
}
