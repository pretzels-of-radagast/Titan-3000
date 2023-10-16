using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class EndScreen : MonoBehaviour {

    public TextMeshProUGUI DateText;

    private float delay = 2f;

    private void Update() {
        if (gameObject.activeSelf) {
            DateText.text = $"TERRA DATE: Cycle {Sim.instance.Cycle}, 3000";

            if (delay < 0 && Mouse.current.leftButton.isPressed) {
                Destroy(gameObject);
            }
            delay -= Time.deltaTime;
        }
    }


}
