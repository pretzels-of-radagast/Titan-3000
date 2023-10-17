using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ResourceDisplay : MonoBehaviour
{
    public enum Resource {
        Oxygen,
        Food,
        Human,
        Cycle,
        Research,
        Metal,
        SpecialResearch
    }

    public Resource resource;
    public TextMeshProUGUI textMesh;

    private void Update() {
        if (resource == Resource.Oxygen) {
            textMesh.text = $"{Sim.instance.Resources.Oxygen}%";
        } else if (resource == Resource.Food) {
            textMesh.text = $"{Sim.instance.Resources.Food}";
        } else if (resource == Resource.Human) {
            textMesh.text = $"{Sim.instance.Resources.Human}";
        } else if (resource == Resource.Metal) {
            textMesh.text = $"{Sim.instance.Resources.Metal}";
        } else if (resource == Resource.Cycle) {
            textMesh.text = $"CYCLE {Sim.instance.Cycle}";
        } else if (resource == Resource.Research) {
            textMesh.text = $"{ElementLibrary.instance.NumberDiscovered()} / {ElementLibrary.instance.DiscoveredElements.Length - ElementLibrary.instance.SpecialDiscoveries.Count}";
        } else if (resource == Resource.SpecialResearch) {
            textMesh.text = $"{ElementLibrary.instance.NumberSpecialDiscovered()} / {ElementLibrary.instance.SpecialDiscoveries.Count}";
        }
    }

}
