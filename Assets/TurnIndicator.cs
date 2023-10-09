using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour {
    
    public Image[] indicators;
    public Sprite empty;
    public Sprite filled;

    private void Start() {
        Sim.instance.OnSpawn += UpdateIndicators;
        UpdateIndicators();
    }

    private void UpdateIndicators() {
        int i = 0;
        foreach (Image indicator in indicators) {
            if (i < Sim.instance.CardsPlayedThisTurn) { indicator.sprite = filled;
            } else { indicator.sprite = empty; }
            i++;
        }
    }

}
