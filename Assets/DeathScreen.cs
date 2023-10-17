using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI DateText;

    private float delay = 2f;

    public void Step() {
        if (!Sim.instance.Alive) {
            gameObject.SetActive(true);
        }
    }

    private void Update() {
        if (gameObject.activeSelf) {
            DateText.text = $"TERRA DATE: Cycle {Sim.instance.Cycle}, 3000";

            if (delay < 0 && Mouse.current.leftButton.isPressed) {
                SceneManager.LoadScene(0);
            }
            delay -= Time.deltaTime;
        }
    }
}
