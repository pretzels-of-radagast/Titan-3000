using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenActivator : MonoBehaviour
{
    public GameObject EndScreen;
    public float HumanWinThreshold = 100000;

    // cache
    private bool hasWon = false;

    private void Update() {
        if (!hasWon && Sim.instance.Resources.Human >= HumanWinThreshold) {
            EndScreen.SetActive(true);
            hasWon = true;
        }
    }

}
